namespace AirConditionerTestingSystem.Controllers
{
    using System;
    using Common;
    using Data.Protocols;
    using Models;
    using Models.AirConditioners;
    using ProcessResults;
    using ProcessResults.Protocols;
    using Protocols;

    public class AirConditionersController : BaseController, IAirConditionersController
    {
        private readonly IAppDataContext dataContext;

        public AirConditionersController(IAppDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IProcessResult RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            var efficiency = (EnergyEfficiencyRating)Enum
                .Parse(typeof(EnergyEfficiencyRating), energyEfficiencyRating);

            var airConditioner = new StationaryAirConditioner(
                manufacturer, model, efficiency, powerUsage);

            this.dataContext.AddAirConditioner(airConditioner);

            return new RegisterResult(airConditioner);
        }

        public IProcessResult RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            var airConditioner = new CarAirConditioner(
                manufacturer, model, volumeCoverage);

            this.dataContext.AddAirConditioner(airConditioner);

            return new RegisterResult(airConditioner);
        }

        public IProcessResult RegisterPlaneAirConditioner(
            string manufacturer, string model, int volumeCoverage, int electricityUsed)
        {
            var airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);

            this.dataContext.AddAirConditioner(airConditioner);

            return new RegisterResult(airConditioner);
        }

        public IProcessResult TestAirConditioner(string manufacturer, string model)
        {
            var airConditioner = this.dataContext
                .GetAirConditioner(manufacturer, model);

            if (airConditioner == null)
            {
                return new ErrorResult(StatusMessages.Nonexist);
            }

            var mark = airConditioner.Test();

            var report = new Report(
                airConditioner.Manufacturer, airConditioner.Model, mark);

            this.dataContext.AddReport(report);

            return new TestResult(airConditioner);
        }

        public IProcessResult FindAirConditioner(string manufacturer, string model)
        {
            var airConditioner = this.dataContext
                .GetAirConditioner(manufacturer, model);

            if (airConditioner == null)
            {
                return new ErrorResult(StatusMessages.Nonexist);
            }

            return new FindAirconditionerResult(airConditioner);
        }

        public int GetAirConditionersCount()
        {
            return this.dataContext.GetAirConditionersCount();
        }
    }
}