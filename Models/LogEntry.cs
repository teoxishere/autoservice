using AutoService.Enums;
using System;

namespace AutoService.Models
{
    public class LogEntry
    {
        public long Id { get; set; }

        public ActionsEnum Action { get; set; }

        public string Username { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

    }
}
