namespace AirConditionerTestingSystem.Models
{
    using System.Text;

    public class Report : BaseProduct
    {

        public Report(string manufacturer, string model, bool mark)
            : base(manufacturer, model)
        {
            this.Mark = mark;
        }

        public bool Mark { get; }

        public override string ToString()
        {
            // Bug Passed or Failed was appended to the report word
            string mark = this.Mark ? "Passed" : "Failed";

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Report")
                .AppendLine("====================")
                .AppendLine($"Manufacturer: {this.Manufacturer}")
                .AppendLine($"Model: {this.Model}")
                .AppendLine($"Mark: {mark}")
                .Append("====================");

            // original (kept for template)
            //string result = "Report" + "\r\n" +
            //    "====================" +"\r\n" +
            //    "Manufacturer: " + this.Manufacturer + "\r\n" +
            //          "Model: " + this.Model + "\r\n" + "Mark: " + mark + "\r\n" + "====================";

            return stringBuilder.ToString();
        }
    }
}
