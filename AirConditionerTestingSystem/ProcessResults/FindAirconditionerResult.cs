namespace AirConditionerTestingSystem.ProcessResults
{
    using Models;
    using Models.AirConditioners;

    public class FindAirconditionerResult : BaseProcessResult
    {
        public FindAirconditionerResult(AirConditioner oldAirConditioner)
        {
            // Todo: if time move string processing from the airconditioner to this class
            this.Result = oldAirConditioner.ToString();
        }
    }
}