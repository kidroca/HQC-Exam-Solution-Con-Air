namespace AirConditionerTestingSystem.ProcessResults
{
    public class ErrorResult : BaseProcessResult
    {
        public ErrorResult(string message)
        {
            this.Result = message;
        }
    }
}