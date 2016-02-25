namespace AirConditionerTestingSystem.Core
{
    using System;
    using Commands;
    using Data.Protocols;
    using ProcessResults.Protocols;
    using Protocols;
    using UI;

    public class Engine : IEngine
    {
        private readonly ICommandDistributor commandDistributor;
        private readonly IAppDataContext data;

        public Engine(
            IUserInterface userInterface,
            ICommandDistributor commandDistributor,
            IAppDataContext dataContext)
        {
            this.commandDistributor = commandDistributor;
            this.UserInterface = userInterface;
            this.data = dataContext;
        }

        public ICommand Command { get; private set; }

        public IUserInterface UserInterface { get; }

        public void Run()
        {
            while (true)
            {
                string line = this.UserInterface.ReadLine();

                if (string.IsNullOrWhiteSpace(line) || string.IsNullOrEmpty(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    this.Command = new Command(line);
                    IProcessResult result = this.commandDistributor.Process(this.Command);
                    this.UserInterface.WriteLine(result.Result);
                }
                catch (Exception ex)
                {
                    this.UserInterface.WriteLine(ex.Message);
                }
            }
        }
    }
}
