namespace AirConditionerTestingSystem.Core
{
    using System;
    using Commands;
    using Common;
    using Controllers.Protocols;
    using ProcessResults;
    using ProcessResults.Protocols;
    using Protocols;

    /* Bug there was a bug with the RegisterCarAirConditioner command:
    model and manufacturer parameters were had switched places */

    public class CommandDistributor : BaseCommandDistributor, ICommandDistributor
    {
        private readonly IAirConditionersController airConditionersController;
        private readonly IReportsController reportsController;

        public CommandDistributor(
            IAirConditionersController airConditionersController,
            IReportsController reportsController)
        {
            this.airConditionersController = airConditionersController;
            this.reportsController = reportsController;
        }

        public virtual IProcessResult Process(ICommand command)
        {
            try
            {
                IProcessResult result;

                switch (command.Name)
                {
                    case CommandName.RegisterStationaryAirConditioner:

                        base.ValidateParametersCount(command, typeof(IAirConditionersController));

                        result = this.airConditionersController
                            .RegisterStationaryAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            command.Parameters[2],
                            int.Parse(command.Parameters[3]));

                        return result;

                    case CommandName.RegisterCarAirConditioner:

                        base.ValidateParametersCount(command, typeof(IAirConditionersController));

                        result = this.airConditionersController
                            .RegisterCarAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]));

                        return result;

                    case CommandName.RegisterPlaneAirConditioner:

                        base.ValidateParametersCount(command, typeof(IAirConditionersController));

                        result = this.airConditionersController
                             .RegisterPlaneAirConditioner(
                             command.Parameters[0],
                             command.Parameters[1],
                             int.Parse(command.Parameters[2]),
                             int.Parse(command.Parameters[3]));

                        return result;

                    case CommandName.TestAirConditioner:

                        base.ValidateParametersCount(command, typeof(IAirConditionersController));

                        result = this.airConditionersController
                             .TestAirConditioner(
                             command.Parameters[0],
                             command.Parameters[1]);

                        return result;

                    case CommandName.FindAirConditioner:

                        base.ValidateParametersCount(command, typeof(IAirConditionersController));

                        result = this.airConditionersController
                            .FindAirConditioner(
                             command.Parameters[0],
                             command.Parameters[1]);

                        return result;

                    case CommandName.FindReport:

                        base.ValidateParametersCount(
                            command, typeof(IReportsController));

                        result = this.reportsController.FindReport(
                            command.Parameters[0],
                            command.Parameters[1]);

                        return result;

                    case CommandName.FindAllReportsByManufacturer:
                        base.ValidateParametersCount(
                            command, typeof(IReportsController));

                        result = this.reportsController
                            .FindAllReportsByManufacturer(
                            command.Parameters[0]);

                        return result;

                    case CommandName.Status:

                        return this.Status();

                    default:
                        throw new InvalidOperationException(StatusMessages.InvalidCommand);
                }
            }
            catch (InvalidOperationException)
            {
                IProcessResult result = new ErrorResult(StatusMessages.InvalidCommand);
                return result;
            }
        }

        public IProcessResult Status()
        {
            int reports = this.reportsController.GetReportsCount();

            double airConditioners =
                this.airConditionersController.GetAirConditionersCount();

            double percent = reports / airConditioners;

            percent = percent * 100;

            var result = new StatusResult(
                string.Format(StatusMessages.Status, percent));

            return result;
        }
    }
}
