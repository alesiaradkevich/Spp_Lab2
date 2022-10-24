using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Loader;
using System.Reflection;
using FakerLib.Generators;

namespace FakerLib
{
    public class TypeGenerator
    {
        private Dictionary<Type, IGenerator> Generators;

        public TypeGenerator()
        {
            Generators = new Dictionary<Type, IGenerator>();
            LoadInnerGenerators();
            LoadAdditionalGenerators();
        }

        private void LoadInnerGenerators()
        {
            IGenerator byteGenerator = new ByteGenerator();
            Generators.Add(byteGenerator.GetGenerationType(), byteGenerator);

            IGenerator shortGenerator = new ShortGenerator();
            Generators.Add(shortGenerator.GetGenerationType(), shortGenerator);

            IGenerator intGenerator = new IntGenerator();
            Generators.Add(intGenerator.GetGenerationType(), intGenerator);

            IGenerator charGenerator = new CharGenerator();
            Generators.Add(charGenerator.GetGenerationType(), charGenerator);
        }

        private void LoadAdditionalGenerators()
        {
            string additionalGeneratorsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\Plugins\\");
            foreach (var dll in Directory.GetFiles(additionalGeneratorsDirectory, "*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(dll);
                foreach (Type type in assembly.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator generator = (IGenerator)Activator.CreateInstance(type);
                        Generators.Add(generator.GetGenerationType(), generator);
                    }
                }
            }
        }
        public object Generate(Type type)
        {
            return Generators[type].Generate();
        }
        public bool GeneratorExists(Type type)
        {
            if (Generators.ContainsKey(type))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
