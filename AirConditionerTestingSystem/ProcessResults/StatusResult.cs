namespace AirConditionerTestingSystem.ProcessResults
{
    public class StatusResult : BaseProcessResult
    {
        public StatusResult(string message)
        {
            this.Result = message;
        }
    }
}