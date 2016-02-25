﻿namespace AirConditionerTestingSystem.Common
{
    public static class StatusMessages
    {
        public const string IncorrectPropertyLength = "{0}'s name must be at least {1} symbols long.";

        public const string NoReports = "No reports.";

        public const string InvalidCommand = "Invalid command";

        public const string Status = "Jobs complete: {0:F2}%";

        public const string IncorrectRating = "Energy efficiency rating must be between \"A\" and \"E\".";

        public const string NonPositive = "{0} must be a positive integer.";

        public const string Duplicate = "An entry for the given model already exists.";

        public const string Nonexist = "The specified entry does not exist.";

        public const string Register = "Air Conditioner model {0} from {1} registered successfully.";

        public const string Test = "Air Conditioner model {0} from {1} tested successfully.";
    }
}
