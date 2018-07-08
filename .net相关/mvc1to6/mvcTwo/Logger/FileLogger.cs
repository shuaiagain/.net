using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;


namespace mvcTwo.Logger
{
    public class FileLogger
    {
        public void LogException(Exception e)
        {
            File.WriteAllLines("C://Error//" + DateTime.Now.ToString("dd-MM-yyyy mm hh ss") + ".txt",
                new string[] 
                 {
                     "Message:"+e.Message,
                     "Stacktrace:"+e.StackTrace
                 });
        }
    }
}