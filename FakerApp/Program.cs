using System;
using FakerLib;

namespace FakerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();

            int I = faker.Create<int>();
            Console.WriteLine(I.GetType().Name + ": " + I.ToString());

            short S = faker.Create<short>();
            Console.WriteLine(S.GetType().Name + ": " + S.ToString());

            byte B = faker.Create<byte>();
            Console.WriteLine(B.GetType().Name + ": " + B.ToString());

            float F = faker.Create<float>();
            Console.WriteLine(F.GetType().Name + ": " + F.ToString());

            char C = faker.Create<char>();
            Console.WriteLine(C.GetType().Name + ": " + C);

            string Str = faker.Create<string>();
            Console.WriteLine(Str.GetType().Name + ": " + S);


            Console.ReadLine();
        }
    }
}
