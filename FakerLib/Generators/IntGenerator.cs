using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLib
{
    public class IntGenerator : IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            int number = 0;
            while (number == 0)
            {
                number = random.Next(int.MinValue, int.MaxValue);
            }
            return number;
        }

        public Type GetGenerationType()
        {
            return typeof(int);
        }
    }
}
