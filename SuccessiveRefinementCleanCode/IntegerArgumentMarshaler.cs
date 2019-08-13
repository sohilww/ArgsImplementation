using System.Collections.Generic;

namespace SuccessiveRefinementCleanCode
{
    public class IntegerArgumentMarshaler : IArgumentMarshaler
    {
        private int intValue = 0;
        public void Set(IEnumerator<string> currentArgument)
        {
            string parameter = null;
            var hasNext = currentArgument.MoveNext();
            if (hasNext)
            {
                parameter = currentArgument.Current;
                try
                {
                    intValue = int.Parse(parameter);
                }
                catch 
                {
                    throw new ArgsException("");
                }
            }
            else
            {
                throw new ArgsException("");
            }
        }

        public static int GetValue(IArgumentMarshaler am)
        {
            if (am != null && am is IntegerArgumentMarshaler)
                return (am as IntegerArgumentMarshaler).intValue;
            else
                return 0;
        }
    }
}