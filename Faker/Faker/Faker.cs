using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Faker
{
    public class Faker : IFaker
    {
        private readonly Dictionary<Type, IGenerator> generators;

        public Faker()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var types = currentAssembly.GetTypes().Where(type =>
                type.GetInterfaces().Any(i => i.FullName == typeof(IGenerator).FullName));
                                              //|| i.FullName == typeof(IGenericGeneratorFactory).FullName));
            foreach (var type in types)
            {
                if (type.FullName == null) continue;
                if (currentAssembly.CreateInstance(type.FullName) is IGenerator generatorPlugin)
                {
                    var generatorType = generatorPlugin.GetObjectType();
                    generators.Add(generatorType, generatorPlugin);
                }
                //else if (currentAssembly.CreateInstance(type.FullName) is IGenericGeneratorFactory generatorFactoryPlugin)
                //{
                //    _genericGeneratorFactory.Add(generatorFactoryPlugin);
                //}
            }
        }

        private object GenerateValue(Type type, bool currentClass)
        {
            if (generators.TryGetValue(type, out var generator))
            {
                return generator.Generate();
            }

            if (currentClass) return null;
            if (type.IsValueType || type.IsClass)
            {
                var method = typeof(Faker).GetMethod("CreateObj");
                if (method == null) return null;
                var genericMethod = method.MakeGenericMethod(type);
                return genericMethod.Invoke(new Faker(), null);
            }
            return null;
        }

        private void FillObject(object instance)
        {
            var type = instance.GetType();

            var properties = new List<PropertyInfo>(type.GetProperties());
            foreach (var property in properties)
            {
                if (!property.CanWrite) continue;
                var propertyType = property.PropertyType;
                var value = GenerateValue(propertyType, propertyType == instance.GetType());
                property.SetValue(instance, value);
            }
            var fieldInfos = new List<FieldInfo>(type.GetFields());
            foreach (var fieldInfo in fieldInfos)
            {
                if (fieldInfo.IsLiteral) continue;
                var fieldType = fieldInfo.FieldType;
                var value = GenerateValue(fieldType, fieldType == instance.GetType());
                fieldInfo.SetValue(instance, value);
            }
        }

        public object CreateObj<T>()
        {
            var type = typeof(T);
            if (generators.TryGetValue(type, out var generator))
            {
                return generator.Generate();
            }
            if (type.IsValueType)
            {
                var obj = Activator.CreateInstance(type);
                FillObject(obj);
                return obj;
            }
            if (type.IsGenericType)
            {

            }


            
            return null;
        }
    }
}
