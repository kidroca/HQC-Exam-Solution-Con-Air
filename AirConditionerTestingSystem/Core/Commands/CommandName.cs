namespace AirConditionerTestingSystem.Core.Commands
{
    public enum CommandName
    {
        RegisterStationaryAirConditioner = 0,
        RegisterCarAirConditioner = 1,
        RegisterPlaneAirConditioner = 2,
        TestAirConditioner = 3,
        FindAirConditioner = 4,
        FindReport = 5,
        FindAllReportsByManufacturer = 6,
        Status = 7
    }
}