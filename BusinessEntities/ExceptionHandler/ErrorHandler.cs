using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Web;

namespace ExceptionHandler
{
    #region "Enumerators"
    public enum ErrorLogEntryType
    {
        /// <summary>
        /// Informational entry.
        /// </summary>
        /// <remarks></remarks>
        Information,

        /// <summary>
        /// Warning entry: more serious, but non-fatal.
        /// </summary>
        /// <remarks></remarks>
        Warning,

        /// <summary>
        /// Error entry: very serious, mostly fatal exception.
        /// </summary>
        /// <remarks></remarks>
        Error,

        /// <summary>
        /// Error entry: very serious, mostly fatal exception.
        /// </summary>
        /// <remarks></remarks>
        Fatal

    }

    public enum ErrorLevel
    {
        /// <summary>
        /// Low severity, no immidiate action has to be taken.
        /// </summary>
        /// <remarks></remarks>
        Low,

        /// <summary>
        /// Normal severity, one should check the problem.
        /// </summary>
        /// <remarks></remarks>
        Normal,

        /// <summary>
        /// High severity, a serious error has occured.
        /// </summary>
        /// <remarks></remarks>
        High,

        /// <summary>
        /// Fatal severity, immidiate action is required.
        /// </summary>
        /// <remarks></remarks>
        Fatal
    }
    #endregion

    public class ErrorHandler
    {
        //public Guid? UserID { get;  set; }

        //public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public ErrorLogEntryType? Type { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        /// <value>The level.</value>
        public ErrorLevel? Level { get; set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        /// <value>The stack trace.</value>
        public string StackTrace { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        //public object Data { get; set; }

        /// <summary>
        /// Gets or sets the current date time.
        /// </summary>
        /// <value>The current date time.</value>
        public DateTime? CurrentDateTime { get; set; }


        /// <summary>
        /// To bind the exception in the errorlog file.
        /// </summary>
        /// <param name="objException"></param>
        public static void ErrorLog(ErrorHandler objException)
        {
            var strErrPath = HttpContext.Current != null
                                    ? HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["LogFiles"])
                                    : string.Format("{0}{1}", System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath,
                                                    ConfigurationManager.AppSettings["LogFiles"]);
            try
            {
                if (objException != null)
                {
                    if (!Directory.Exists(strErrPath))
                    {
                        Directory.CreateDirectory(strErrPath);
                    }
                    var file = new FileStream(strErrPath + "ErrorLog" + DateTime.Now.ToString("MMddyyyy") + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                    var streamWriter = new StreamWriter(file);
                    streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                    streamWriter.WriteLine("---------------------------------------------------------------------");
                    streamWriter.WriteLine(string.Format("DateTime: {0}", objException.CurrentDateTime));
                    streamWriter.WriteLine(string.Format("StackTrace: {0}", objException.StackTrace));
                    streamWriter.WriteLine(string.Format("Message: {0}", objException.Message));
                    streamWriter.WriteLine(string.Format("ErrorLogEntryType : {0} ", objException.Type));
                    streamWriter.WriteLine(string.Format("ErrorLevel : {0} ", objException.Level)); 
                    streamWriter.WriteLine("---------------------------------------------------------------------");
                    streamWriter.Close();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
