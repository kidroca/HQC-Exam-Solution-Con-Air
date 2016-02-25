namespace AirConditionerTestingSystem.Controllers.Protocols
{
    using ProcessResults.Protocols;

    public interface IAirConditionersController
    {
        IProcessResult RegisterStationaryAirConditioner(
            string manufacturer, string model, string energyEfficiencyRating, int powerUsage);

        IProcessResult RegisterCarAirConditioner(
            string model, string manufacturer, int volumeCoverage);

        IProcessResult RegisterPlaneAirConditioner(
            string manufacturer, string model, int volumeCoverage, int electricityUsed);

        IProcessResult TestAirConditioner(string manufacturer, string model);

        IProcessResult FindAirConditioner(string manufacturer, string model);

        int GetAirConditionersCount();
    }
}