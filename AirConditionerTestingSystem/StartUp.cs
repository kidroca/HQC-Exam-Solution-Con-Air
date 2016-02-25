namespace AirConditionerTestingSystem
{
    using AppConfig;
    using Core.Protocols;

    public class StartUp
    {
        private static IEngine AppEngine;

        public static void Main()
        {
            AppEngine = EngineConfig.Initialize();

            AppEngine.Run();
        }
    }
}
