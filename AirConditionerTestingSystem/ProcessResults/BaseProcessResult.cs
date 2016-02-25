namespace AirConditionerTestingSystem.ProcessResults
{
    using ProcessResults.Protocols;

    public abstract class BaseProcessResult : IProcessResult
    {
        public string Result { get; protected set; }
    }
}