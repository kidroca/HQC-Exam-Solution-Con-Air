namespace AirConditionerTestingSystem.AppConfig
{
    using Controllers;
    using Core;
    using Core.Protocols;
    using Data;
    using UI;

    public static class EngineConfig
    {
        /// <summary>
        /// Engine configuration and initialization 
        /// Decouples the engine from the userInterface and the command processor
        /// Previously the CommandDistributor was initialized inside the Engine Class
        /// </summary>
        /// <returns></returns>
        public static IEngine Initialize()
        {
            var userInterface = new ConsoleUserInterface();
            var dataContext = new AppDataContext();

            var airConditionersController = new AirConditionersController(dataContext);
            var reportsController = new ReportsController(dataContext);

            var commandProcessor = new CommandDistributor(
                airConditionersController,
                reportsController);

            var engine = new Engine(userInterface, commandProcessor, dataContext);

            return engine;
        }
    }
}