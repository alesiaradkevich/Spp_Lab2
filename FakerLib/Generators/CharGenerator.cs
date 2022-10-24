using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLib.Generators
{
    public class CharGenerator : IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            char c = Convert.ToChar(0);
            while (c == Convert.ToChar(0))
            {
                c = Convert.ToChar(random.Next(char.MinValue, char.MaxValue));
            }
            return c;
        }

        public Type GetGenerationType()
        {
            return typeof(char);
        }
    }
}
