using System;
using FakerLib;

namespace FakerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            string str = faker.Create<string>();
            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}
