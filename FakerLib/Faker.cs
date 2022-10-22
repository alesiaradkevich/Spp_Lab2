using System;
using System.Collections.Generic;

namespace FakerLib
{
    public class Faker
    {
        private TypeGenerator TypeGenerator = new TypeGenerator();

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
                var obj = GenerateWithConstructor(type);
                FillDTO(obj);
                return obj;
            }
        }

        private object GenerateWithConstructor(Type type)
        {
            try
            {
                var constructor = type.GetConstructors()[0];
                var constructorParams = constructor.GetParameters();
                List<object> createdParams = new List<object>();
                if (createdParams.Count > 0)
                {
                    foreach (var param in constructorParams)
                    {
                        createdParams.Add(GenerateDPO(param.ParameterType));
                    }
                }
                return constructor.Invoke(createdParams.ToArray());
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
