namespace AirConditionerTestingSystem.Models.AirConditioners
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Common;

    public class StationaryAirConditioner : AirConditioner
    {
        private int powerUsage;

        public StationaryAirConditioner(
            string manufacturer,
            string model,
            EnergyEfficiencyRating rating,
            int powerUsage) : base(manufacturer, model)
        {
            this.EnergyEfficiencyRating = rating;
            this.PowerUsage = powerUsage;
        }

        public EnergyEfficiencyRating EnergyEfficiencyRating { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = StatusMessages.NonPositive)]
        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }
            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.PowerUsage)
                });

                this.powerUsage = value;
            }
        }

        public override bool Test()
        {
            return this.PowerUsage <= (int)this.EnergyEfficiencyRating;
        }

        public override string ToString()
        {
            // Todo check if I have to add a line
            var stringBuilder = new StringBuilder(base.ToString())
                .AppendLine($"Required energy efficiency rating: {this.EnergyEfficiencyRating}")
                .AppendLine($"Power Usage(KW / h): {this.PowerUsage}")
                .Append("====================");

            return stringBuilder.ToString();
        }
    }
}