using System;
using System.Collections.Generic;
using TheChannelCakeFactory.Configuration;

namespace TheChannelCakeFactory
{
    public class BindingNameConfiguration
    {
        protected static readonly Dictionary<Type, string> BindingNames = new Dictionary<Type, string>();

        public void Configure<T>(string bindingName)
        {
            var typeKey = typeof(T);

            if (BindingNames.ContainsKey(typeKey))
            {
                string errorMessage = string.Format("{0} has already a bindingName configured, make sure you're not configuring twice", typeKey.Name);
                throw new BindingNameConfigurationException(errorMessage);
            }
            BindingNames.Add(typeKey, bindingName);
        }

        public string GetBindingName<T>()
        {
            var typeKey = typeof(T);

            if (!BindingNames.ContainsKey(typeKey))
            {
                return string.Format("{0}_BindingName", typeKey.Name);
            }

            return BindingNames[typeKey];
        }

        public void ClearConfiguration()
        {
            BindingNames.Clear();
        }
    }
}