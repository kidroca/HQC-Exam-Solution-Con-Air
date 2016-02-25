namespace AirConditionerTestingSystem.ProcessResults
{
    using Common;
    using Models;
    using Models.AirConditioners;

    public class TestResult : BaseProcessResult
    {
        public TestResult(AirConditioner oldAirConditioner)
        {
            base.Result = string.Format(
                 StatusMessages.Test, oldAirConditioner.Model, oldAirConditioner.Manufacturer);
        }
    }
}