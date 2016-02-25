namespace AirConditionerTestingSystem.Data.Protocols
{
    using System.Collections.Generic;
    using Models;
    using Models.AirConditioners;

    // A bit fatter interface, if I have time left I will either 
    // split it in two or try to make it generic...
    public interface IAppDataContext
    {
        void AddAirConditioner(AirConditioner airConditioner);
        bool RemoveAirConditioner(AirConditioner oldAirConditioner);
        AirConditioner GetAirConditioner(string manufacturer, string model);
        int GetAirConditionersCount();

        void AddReport(Report report);
        bool RemoveReport(Report report);
        Report GetReport(string manufacturer, string model);
        int GetReportsCount();
        IList<Report> GetReportsByManufacturer(string manufacturer);
    }
}