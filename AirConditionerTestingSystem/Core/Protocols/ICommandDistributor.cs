namespace AirConditionerTestingSystem.Core.Protocols
{
    using Commands;
    using ProcessResults.Protocols;

    public interface ICommandDistributor
    {
        IProcessResult Process(ICommand command);
        IProcessResult Status();
    }
}