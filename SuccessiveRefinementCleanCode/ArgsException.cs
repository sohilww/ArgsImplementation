using System;

namespace SuccessiveRefinementCleanCode
{
    public class ArgsException : Exception
    {
        public ArgsException(string message):base(message)
        {
            
        }

        public void SetErrorArgumentId(char argsChar)
        {
            throw new NotImplementedException();
        }
    }
}