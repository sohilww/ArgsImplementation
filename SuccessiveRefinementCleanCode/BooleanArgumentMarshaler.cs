using System.Collections.Generic;

namespace SuccessiveRefinementCleanCode
{
    public class BooleanArgumentMarshaler : IArgumentMarshaler
    {
        private bool booleanValue = false;
        public void Set(IEnumerator<string> currentArgument)
        {
            booleanValue = true;
        }

        public static bool GetValue(IArgumentMarshaler am)
        {
            if (am != null && am is BooleanArgumentMarshaler)
                return (am as BooleanArgumentMarshaler).booleanValue;
            else
                return false;
        }
    }
}