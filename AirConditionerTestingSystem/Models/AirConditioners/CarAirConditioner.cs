namespace AirConditionerTestingSystem.Models.AirConditioners
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Common;

    public class CarAirConditioner : AirConditioner
    {
        private int volumeCovered;

        public CarAirConditioner(string manufacturer, string model, int volumeCoverage)
            : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCoverage;
        }

        [Range(0, int.MaxValue, ErrorMessage = StatusMessages.NonPositive)]
        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.VolumeCovered)
                });

                this.volumeCovered = value;
            }
        }

        public override bool Test()
        {
            double sqrtVolume = Math.Sqrt(this.volumeCovered);
            return sqrtVolume < ModelConstraints.MinCarVolume;
        }

        // Todo use string builder
        public override string ToString()
        {
            var stringBuilder = new StringBuilder(base.ToString())
                .AppendLine($"Volume Covered: {this.VolumeCovered}")
                .AppendLine("====================");

            return stringBuilder.ToString();
        }
    }
}