using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using ExceptionHandler;

namespace WcfGetService.DAL_Logic
{
    public class BaseClass
    {

        public class CustomFault
        {
            public string Reason { get; set; }
            public string FunctionName { get; set; }
            public string Message { get; set; }
            public string StackTrace { get; set; }
            public int ErrorCode { get; set; }
        }

        public FaultException<CustomFault> ConstructFaultException(Exception ex)
        {
            CustomFault objFault = new CustomFault();
            ErrorHandler.ErrorLog(new ErrorHandler()
            {
                CurrentDateTime = DateTime.Now,
                Level = ErrorLevel.High,
                Type = ErrorLogEntryType.Error,
                StackTrace = ex.StackTrace,
                Message = ex.Message
            });

            objFault.Message = ex.Message;
            objFault.StackTrace = ex.StackTrace;
            objFault.ErrorCode = ex.GetHashCode();

            return new FaultException<CustomFault>(objFault, ex.Message);
        }

    }
}