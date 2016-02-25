namespace AirConditionerTestingSystem.Models.AirConditioners
{
    using System.Text;

    public abstract class AirConditioner : BaseProduct
    {
        protected AirConditioner(string manufacturer, string model) : base(manufacturer, model)
        {
        }

        public abstract bool Test();

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Air Conditioner")
                .AppendLine("====================")
                .AppendLine($"Manufacturer: {this.Manufacturer}")
                .AppendLine($"Model: {this.Model}");

            return stringBuilder.ToString();
        }
    }
}