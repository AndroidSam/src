using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExceptionHandler;
using System.Web.Mvc;

namespace PMS_MVC
{
    public class ExceptionHelper
    {
        public void ConstructException(Exception exception)
        {
            ErrorHandler.ErrorLog(new ErrorHandler
            {
                CurrentDateTime = DateTime.Now,
                StackTrace = exception.StackTrace,
                Message = exception.Message,
                Level = ErrorLevel.High,
                Type = ErrorLogEntryType.Error,
            });
        } 
    }
}