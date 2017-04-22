using AutoService.Enums;
using AutoService.Models;
using System;

namespace AutoService.Services
{
    public class LoggingService
    {
        public static void Log(ActionsEnum action,double prix, string description = null)
        {
            var logEntry = new LogEntry {
                Action = action,
                Price=prix,
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
