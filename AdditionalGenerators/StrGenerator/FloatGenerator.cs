using System;
using FakerLib;
namespace StrGenerator
{
    public class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            Random random = new Random();
            float number = 0;
            while (number == 0)
            {
                number = (float)random.NextDouble();
            }
            return number;
        }

        public Type GetGenerationType()
        {
            return typeof(float);
        }
    }
}
