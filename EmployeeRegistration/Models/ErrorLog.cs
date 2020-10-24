using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmployeeRegistration.Models
{
    public class ErrorLog
    {
        private string sLogFormat;
        private string sErrorTime;
        public ErrorLog()
        {
            
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + "" +
                DateTime.Now.ToLongTimeString().ToString() + "==>";

            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;
        }
        public void Log(string sInfoMsg)
        {
            StreamWriter sw = new StreamWriter(@"F:\Swapnali\Practice\EmployeeRegistration\EmployeeRegistration\Logs\ErrorLogFile.txt", true);
            sw.WriteLine(sInfoMsg, sErrorTime);
            sw.Flush();
            sw.Close();
        }
    }
}