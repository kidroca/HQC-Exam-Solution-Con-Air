namespace AirConditionerTestingSystem.Controllers.Protocols
{
    using ProcessResults.Protocols;

    public interface IReportsController
    {
        IProcessResult FindReport(string manufacturer, string model);
        IProcessResult FindAllReportsByManufacturer(string manufacturer);
        int GetReportsCount();
    }
}