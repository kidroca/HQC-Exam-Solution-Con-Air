namespace AirConditionerTestingSystem.ProcessResults
{
    using Common;
    using Models;
    using Models.AirConditioners;

    public class RegisterResult : BaseProcessResult
    {
        public RegisterResult(AirConditioner oldAirConditioner)
        {
            base.Result = string.Format(
                 StatusMessages.Register, oldAirConditioner.Model, oldAirConditioner.Manufacturer);
        }
    }
}