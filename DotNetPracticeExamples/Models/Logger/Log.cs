using Microsoft.VisualBasic;

namespace DotNetPracticeExamples.Models.Logger
{
    public class Log
    {
        public string Id { get; set; }
        public string LogLevelId { get; set; }
        public string EventaName { get; set; }
        public string Source { get; set; }

        public string Message { get; set; } ///Will eventually need to be a list of a list

        public string StackTrace { get; set; }
        public string LoggerInstanceId { get; set; }
        public DateAndTime CreatedAt { get; set; }
    }
}
