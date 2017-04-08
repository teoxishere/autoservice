using AutoService.Enums;
using AutoService.Models;
using System;

namespace AutoService.Services
{
    public class LoggingService
    {
        public static void Log(ActionsEnum action, string description = null)
        {
            var logEntry = new LogEntry {
                Action = action,
                Date = DateTime.Now,
                Description = description,
                Username = UserService.LoggedInUser == null ? "unkown" : UserService.LoggedInUser.Username
            };
            using (var db = new Context())
            {
                db.LogEntries.Add(logEntry);
                db.SaveChanges();
            }
        }
    }
}
