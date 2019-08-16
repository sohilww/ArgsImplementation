using System;

namespace SuccessiveRefinementCleanCode
{
    public class ArgsException : Exception
    {
        private char errorArgumentId = '\0';
        private string errorParameter = null;
        private ErrorCode errorCode = ErrorCode.OK;

        public ArgsException()
        {

        }
        public ArgsException(string message) : base(message)
        {

        }

        public ArgsException(ErrorCode errorCode)
        {
            this.errorCode = errorCode;
        }

        public ArgsException(ErrorCode errorCode, string errorParameter)
        {
            this.errorCode = errorCode;
            this.errorParameter = errorParameter;
        }
        public ArgsException(ErrorCode errorCode, char errorArgumentId, string errorParameter)
        {
            this.errorCode = errorCode;
            this.errorParameter = errorParameter;
            this.errorArgumentId = errorArgumentId;
        }

        public char GetErrorArgumentId()
        {
            return errorArgumentId;
        }

        public void SetErrorArgumentId(char errorArgumentId)
        {
            this.errorArgumentId = errorArgumentId;
        }

        public string GetErrorParameter()
        {
            return errorParameter;
        }

        public void SetErrorParameter(string errorParameter)
        {
            this.errorParameter = errorParameter;
        }

        public ErrorCode GetErrorCode()
        {
            return errorCode;
        }

        public void SetErrorCode(ErrorCode errorCode)
        {
            this.errorCode = errorCode;
        }

        public string ErrorMessage()
        {
            switch (errorCode)
            {
                case ErrorCode.OK:
                    return "Tilt: should nit get here,";
                case ErrorCode.UNEXPECTED_ARGUMENT:
                    return $"Argument {errorArgumentId} unexpected.";
                case ErrorCode.MISSING_STRING:
                    return $"Could not find string parameter for {errorArgumentId}";
                case ErrorCode.INVALID_INTEGER:
                    return $"Argument {errorArgumentId} expects an integer but was '{errorParameter}'.";
                case ErrorCode.MISSING_INTEGER:
                    return $"Could not find integer parameter for {errorArgumentId}.";
                case ErrorCode.INVALID_DOUBLE:
                    return $"Argument {errorArgumentId} expects a double but was '{errorParameter}'.";
                case ErrorCode.MISSING_DOUBLE:
                    return $"Could not find double parameter for {errorArgumentId}.";
                case ErrorCode.INVALID_ARGUMENT_NAME:
                    return $"'{errorArgumentId}' is not a valid argument name.";
                case ErrorCode.INVALID_ARGUMENT_FORMAT:
                    return $"'{errorParameter}' is not a valid argument format.";
            }
            return "";
        }
    }
}

public enum ErrorCode
{
    OK,
    Unexpected_Argument,
    UNEXPECTED_ARGUMENT,
    MISSING_STRING,
    INVALID_INTEGER,
    MISSING_INTEGER,
    INVALID_DOUBLE,
    MISSING_DOUBLE,
    INVALID_ARGUMENT_NAME,
    INVALID_ARGUMENT_FORMAT
}
