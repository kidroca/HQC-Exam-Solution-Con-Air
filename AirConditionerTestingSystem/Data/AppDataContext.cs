namespace AirConditionerTestingSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Exceptions;
    using Models;
    using Models.AirConditioners;
    using Protocols;

    public class AppDataContext : IAppDataContext
    {
        private readonly ICollection<AirConditioner> airConditioners;
        private readonly ICollection<Report> reports;

        public AppDataContext()
        {
            this.airConditioners = new List<AirConditioner>();
            this.reports = new List<Report>();
        }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            var existing = this.GetAirConditioner(airConditioner.Manufacturer, airConditioner.Model);

            if (existing != null)
            {
                throw new DuplicateEntryException(StatusMessages.Duplicate);
            }

            this.airConditioners.Add(airConditioner);
        }

        public bool RemoveAirConditioner(AirConditioner oldAirConditioner)
        {
            return this.airConditioners.Remove(oldAirConditioner);
        }

        public AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            return this.airConditioners
                .FirstOrDefault(x => x.Manufacturer.Equals(manufacturer, StringComparison.Ordinal) && x.Model.Equals(model, StringComparison.Ordinal));
        }

        public int GetAirConditionersCount()
        {
            return this.airConditioners.Count;
        }

        public void AddReport(Report report)
        {
            this.reports.Add(report);
        }

        public bool RemoveReport(Report report)
        {
            return this.reports.Remove(report);
        }

        public Report GetReport(string manufacturer, string model)
        {
            return this.reports
                .FirstOrDefault(x => x.Manufacturer.Equals(manufacturer, StringComparison.Ordinal) && x.Model.Equals(model, StringComparison.Ordinal));
        }

        public int GetReportsCount()
        {
            return this.reports.Count;
        }

        public IList<Report> GetReportsByManufacturer(string manufacturer)
        {
            return this.reports.Where(x => x.Manufacturer.Equals(manufacturer, StringComparison.Ordinal)).ToList();
        }
    }
}
