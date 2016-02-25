namespace AirConditionerTestingSystem.Models.AirConditioners
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Common;

    public class PlaneAirConditioner : CarAirConditioner
    {
        private int electricityUsed;

        public PlaneAirConditioner(
            string manufacturer, string model, int volumeCoverage, int electricityUsed)
            : base(manufacturer, model, volumeCoverage)
        {
            this.ElectricityUsed = electricityUsed;
        }

        [Range(0, int.MaxValue, ErrorMessage = StatusMessages.NonPositive)]
        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.ElectricityUsed)
                });

                this.electricityUsed = value;
            }
        }

        public override bool Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            bool success = (this.ElectricityUsed / sqrtVolume) < ModelConstraints.MinPlaneElectricity;

            return success;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(base.ToString());
            int builderLength = stringBuilder.Length;
            int lineLength = "====================".Length;

            stringBuilder.Remove(builderLength - lineLength, lineLength)
                .AppendLine($"Electricity Used: {this.ElectricityUsed}")
                .Append("====================");

            return stringBuilder.ToString();
        }
    }
}