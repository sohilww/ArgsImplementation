using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SuccessiveRefinementCleanCode
{
    public class Args
    {
        private Dictionary<char, IArgumentMarshaler> marshalers;
        private HashSet<char> argsFound;
        private List<string> currentArgument;

        public Args(string schema,string[] args)
        {
            marshalers=new Dictionary<char, IArgumentMarshaler>();
            argsFound=new HashSet<char>();

            ParseSchema(schema);
            ParseArgumentStrings(args.ToList());
        }
        private void ParseSchema(string schema)
        {
            foreach (string element in schema.Split(','))
            {
                if (element.Length > 0)
                    ParseSchemaElement(element.Trim());
            }
        }

        private void ParseSchemaElement(string element)
        {
            char elementId = element[0];
            string elementTail = element.Substring(1);
            ValidateSchemaElementId(elementId);
            if(elementTail.Length==0)
                marshalers.Add(elementId,new BooleanArgumentMarshaler());
            else if(elementTail=="*")
                marshalers.Add(elementId,new StringArgumentMarshaler());
            else if(elementTail=="#")
                marshalers.Add(elementId,new IntegerArgumentMarshaler());
            else if(elementTail=="##")
                marshalers.Add(elementId,new DoubleArgumentMarshaler());
            else if(elementTail=="[*]")
                marshalers.Add(elementId,new StringArrayArgumentMarshaler());
            else
                throw new ArgsException("");
            
        }

        private void ValidateSchemaElementId(char elementId)
        {
            if(!char.IsLetter(elementId))
                throw new ArgsException("");
        }

        private void ParseArgumentStrings(List<string> args)
        {
            foreach (var argString in args)
            {
                if (argString.StartsWith("-"))
                    ParseArgumentCharacters(argString.Substring(1));
                
            }
        }

        private void ParseArgumentCharacters(string argsChars)
        {
            for (int i = 0; i < argsChars.Length; i++)
            {
                ParseArgumentCharacter(argsChars[i]);
            }
        }

        private void ParseArgumentCharacter(char argsChar)
        {
            IArgumentMarshaler m = marshalers[argsChar];
            if(m == null)
                throw new ArgumentException();
            else
            {
                argsFound.Add(argsChar);
                try
                {
                    m.Set(currentArgument.GetEnumerator());
                }
                catch (ArgsException e)
                {
                    e.SetErrorArgumentId(argsChar);
                    throw e;
                }
            }
        }
        public bool Has(char arg)
        {
            return argsFound.Any(a=>a==arg);
        }
        public int nextArgument()
        {
            return 0;
        }
        public bool GetBoolean(char arg)
        {
            return BooleanArgumentMarshaler.GetValue(marshalers[arg]);
        }
        public String GetString(char arg)
        {
            return StringArgumentMarshaler.GetValue(marshalers[arg]);
        }
        public int GetInt(char arg)
        {
            return IntegerArgumentMarshaler.GetValue(marshalers[arg]);
        }
        public double GetDouble(char arg)
        {
            return DoubleArgumentMarshaler.GetValue(marshalers[arg]);
        }
        public string[] GetStringArray(char arg)
        {
            return StringArrayArgumentMarshaler.GetValue(marshalers[arg]);
        }

    }
}