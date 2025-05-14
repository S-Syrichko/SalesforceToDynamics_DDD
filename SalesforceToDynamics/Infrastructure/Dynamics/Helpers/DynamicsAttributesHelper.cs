using Microsoft.Xrm.Sdk;
using System;
using System.Linq;
using System.Reflection;

namespace SalesforceToDynamics.Helpers
{
    public static class DynamicsAttributesHelper
    {
        public static string[] GetDynamicsAttributeNames<T>()
        {
            return typeof(T)
                .GetProperties()
                .Select(prop => prop.GetCustomAttribute<DynamicsLogicalNameAttribute>())
                .Where(attr => attr != null)
                .Select(attr => attr.Name)
                .ToArray();
        }

        public static Entity MapToNewEntity<T>(T model, string logicalName)
        {
            var entity = new Entity(logicalName);
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<DynamicsLogicalNameAttribute>();
                if (attribute != null)
                {
                    object value = property.GetValue(model);
                    if (value != null)
                    {
                        entity.Attributes[attribute.Name] = value;
                    }
                }
            }
            return entity;
        }

        public static Entity MapToExistingEntity<T>(T model, Entity entity)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<DynamicsLogicalNameAttribute>();
                if (attribute != null)
                {
                    object newValue = property.GetValue(model);
                    if (newValue != null)
                    {
                        if (entity.Attributes.TryGetValue(attribute.Name, out var currentValue))
                        {
                            if (!object.Equals(currentValue, newValue))
                            {
                                entity.Attributes[attribute.Name] = newValue;
                            }
                        }
                        else
                        {
                            entity.Attributes.Add(attribute.Name, newValue);
                        }
                    }
                }
            }
            return entity;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DynamicsLogicalNameAttribute : Attribute
    {
        public string Name { get; }
        public DynamicsLogicalNameAttribute(string name)
        {
            Name = name;
        }
    }
}
