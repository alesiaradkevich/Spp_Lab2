using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLib
{
    public class ShortGenerator : IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            short number = 0;
            while (number == 0)
            {
                number = (short)random.Next(short.MinValue, short.MaxValue);
            }
            return number;
        }

        public Type GetGenerationType()
        {
            return typeof(short);
        }
    }
}
