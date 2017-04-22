using AutoService.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoService.Models
{
    public class LogEntry
    {
        
        public long Id { get; set; }

        public ActionsEnum Action { get; set; }

        public string Username { get; set; }

        public DateTime Date { get; set; }

        public double Price { get; set; }
      
        public string Description { get; set; }

    }
}
