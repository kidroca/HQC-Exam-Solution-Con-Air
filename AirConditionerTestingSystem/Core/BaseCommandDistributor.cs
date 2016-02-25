namespace AirConditionerTestingSystem.Core
{
    using System;
    using System.Reflection;
    using Commands;
    using Common;

    public abstract class BaseCommandDistributor
    {
        protected void ValidateParametersCount(
            ICommand command, Type handlingControllerType)
        {
            MethodInfo info = handlingControllerType
                .GetMethod(command.Name.ToString());

            if (command.Parameters.Count != info.GetParameters().Length)
            {
                throw new InvalidOperationException(StatusMessages.InvalidCommand);
            }
        }
    }
}
