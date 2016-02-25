namespace AirConditionerTestingSystem.Core.Commands
{
    using System.Collections.Generic;

    public interface ICommand
    {
        CommandName Name { get; }
        IList<string> Parameters { get; }
    }
}