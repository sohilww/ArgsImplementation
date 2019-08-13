using System;
using System.Collections.Generic;

namespace SuccessiveRefinementCleanCode
{
    public class StringArgumentMarshaler : IArgumentMarshaler
    {
        private string stringValue = "";
        public void Set(IEnumerator<string> currentArgument)
        {
            var hasNext = currentArgument.MoveNext();
            if (hasNext)
                stringValue = currentArgument.Current;
            throw new ArgsException("");
        }

        public static string GetValue(IArgumentMarshaler am)
        {
            //I know we have cast pattern, but the book didn't use it,am either
            if (am != null && am is StringArgumentMarshaler)
                return (am as StringArgumentMarshaler).stringValue;
            else
                return "";
        }
    }
}