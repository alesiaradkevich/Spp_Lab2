using System;
using System.Collections.Generic;

namespace FakerLib
{
    public class Faker
    {
        private TypeGenerator TypeGenerator = new TypeGenerator();
        private List<Type> InnerTypes = new List<Type>();
        public T Create<T>()
        {
            T obj = (T)GenerateDPO(typeof(T));
            return obj;
        }

        private object GenerateDPO(Type type)
        {
            if (TypeGenerator.GeneratorExists(type))
            {
                return TypeGenerator.Generate(type);
            }
            else
            {
                if (InnerTypes.Contains(type))
                {
                    return null;
                }
                else
                {
                    InnerTypes.Add(type);
                    var obj = GenerateWithConstructor(type);
                    FillDTO(obj);
                    InnerTypes.Remove(type);
                    return obj;
                }
            }
        }

        private object GenerateWithConstructor(Type type)
        {
            try
            {
                var constructor = type.GetConstructors()[1];
                var constrParams = constructor.GetParameters();
                var createdConstParams = new List<object>();
                if (constrParams.Length>0)
                {
                    foreach (var constrParam in constrParams)
                    {
                        createdConstParams.Add(GenerateDPO(constrParam.ParameterType));
                    }
                }
                return constructor.Invoke(createdConstParams.ToArray());
            }
            catch
            {
                try
                {
                    return Activator.CreateInstance(type);
                }
                catch
                {
                    return null;
                }
            }
        }
        private void FillDTO(object obj)
        {
            if (obj == null)
            {
                return;
            }
            var properties = obj.GetType().GetProperties();     
            foreach (var property in properties)
            {
                if (property.SetMethod != null)
                {
                    var propertyObject = GenerateDPO(property.PropertyType);
                    property.SetValue(obj, propertyObject);
                }
            }
            var fields = obj.GetType().GetFields();
            foreach (var field in fields)
            {
                try
                {
                    var fieldObject = GenerateDPO(field.FieldType);
                    field.SetValue(obj, fieldObject);
                }
                catch
                {
                    field.SetValue(obj, null);
                }
            }
        }
    }
}
