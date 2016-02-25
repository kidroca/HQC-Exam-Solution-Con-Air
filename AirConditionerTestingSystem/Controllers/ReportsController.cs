namespace AirConditionerTestingSystem.Controllers
{
    using Common;
    using Data.Protocols;
    using Models;
    using ProcessResults;
    using ProcessResults.Protocols;
    using Protocols;

    public class ReportsController : IReportsController
    {
        private readonly IAppDataContext dataContext;

        public ReportsController(IAppDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IProcessResult FindReport(string manufacturer, string model)
        {
            Report report = this.dataContext.GetReport(manufacturer, model);

            if (report == null)
            {
                return new ErrorResult(StatusMessages.Nonexist);
            }

            var result = new FindReportResult(report);
            return result;
        }

        public IProcessResult FindAllReportsByManufacturer(string manufacturer)
        {
            var reports = this.dataContext.GetReportsByManufacturer(manufacturer);
            var result = new FindReportResult(reports, manufacturer);
            return result;
        }

        public int GetReportsCount()
        {
            return this.dataContext.GetReportsCount();
        }
    }
}