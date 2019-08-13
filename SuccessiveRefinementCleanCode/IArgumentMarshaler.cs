using System;
using System.Collections.Generic;

namespace SuccessiveRefinementCleanCode
{
    //I know the book said we shouldn't put I before Interfaces,
    //but it's good practice to me(sorry uncle bob)
    public interface IArgumentMarshaler
    {
        void Set(IEnumerator<string> currentArgument);
    }

    public class DoubleArgumentMarshaler : IArgumentMarshaler
    {
        public void Set(IEnumerator<string> currentArgument)
        {
            
        }

        public static double GetValue(IArgumentMarshaler argumentMarshaler)
        {
            return 0;
        }
    }

    public class StringArrayArgumentMarshaler : IArgumentMarshaler
    {
        public void Set(IEnumerator<string> currentArgument)
        {
            throw new NotImplementedException();
        }

        public static string[] GetValue(IArgumentMarshaler argumentMarshaler)
        {
            return new[] {""};
        }
    }
}