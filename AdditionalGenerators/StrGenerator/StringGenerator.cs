using System;
using System.Collections.Generic;
using System.Text;
using FakerLib;

namespace AdditionalGenerators
{
    public class StringGenerator : IGenerator
    {
        string AvailableChars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
        public object Generate()
        {
            Random random = new Random();
            int length = random.Next(0, 20);
            StringBuilder sb = new StringBuilder();
            for (int i=0; i<length; i++)
            {
                int index = random.Next(0, AvailableChars.Length);
                sb.Append(AvailableChars[index]);
            }
            return sb.ToString();
        }

        public Type GetGenerationType()
        {
            return typeof(string);
        }
    }
}
