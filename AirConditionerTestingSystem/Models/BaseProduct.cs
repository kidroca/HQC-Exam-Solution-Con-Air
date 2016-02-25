namespace AirConditionerTestingSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common;

    public abstract class BaseProduct
    {
        private string manufacturer;
        private string model;

        protected BaseProduct(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            Model = model;
        }

        [Required]
        [MinLength(ModelConstraints.ManufacturerMinLength, ErrorMessage = StatusMessages.IncorrectPropertyLength)]
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.Manufacturer)
                });

                this.manufacturer = value;
            }
        }

        [Required]
        [MinLength(ModelConstraints.ModelMinLength, ErrorMessage = StatusMessages.IncorrectPropertyLength)]
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                Validator.ValidateProperty(value, new ValidationContext(this)
                {
                    MemberName = nameof(this.Model)
                });

                this.model = value;
            }
        }
    }
}