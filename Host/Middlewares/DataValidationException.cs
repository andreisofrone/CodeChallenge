using System;

namespace Host.Middlewares
{
    public class DataValidationException
        : Exception
    {
        public object Errors { get; }

        public DataValidationException(object errors)
        {
            Errors = errors;
        }
    }
}
