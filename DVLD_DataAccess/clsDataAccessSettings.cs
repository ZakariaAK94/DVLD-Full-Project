using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public static class clsDataAccessSettings
    {
        public static string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_DVLD");
    }

    public static class clsLogException
    {
        /// <summary>
        /// this method log error in the try catch in the event log 
        /// </summary>
        /// <param name="sourceName">the name of the soruce with the log exists </param>
        /// <param name="message">the message to display in the event log app </param>
        public static void WriteInLogEvents(string message)
        {
            // Create the event source if it does not exist
            if (!EventLog.SourceExists("DVLD"))
            {
                EventLog.CreateEventSource("DVLD", "Application");
            }

            // Log an error event
            EventLog.WriteEntry("DVLD", message , EventLogEntryType.Error);
        }
    }
}
