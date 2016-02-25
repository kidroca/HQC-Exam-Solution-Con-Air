namespace AirConditionerTestingSystem.ProcessResults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;
    using Models;

    public class FindReportResult : BaseProcessResult
    {
        public FindReportResult(Report report)
        {
            // Todo: if time move string processing from the report to this class
            this.Result = report.ToString();
        }

        public FindReportResult(IList<Report> reports, string manufacturer)
        {
            if (reports.Count == 0)
            {
                this.Result = StatusMessages.NoReports;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();

            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));

            this.Result = reportsPrint.ToString();
        }
    }
}