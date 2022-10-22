using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLib
{
    public class ByteGenerator:IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            byte number = 0;
            while (number == 0)
            {
                number = (byte)random.Next(byte.MinValue, byte.MaxValue);
            }
            return number;
        }
        public Type GetGenerationType()
        {
            return typeof(byte);
        }
    }
}
