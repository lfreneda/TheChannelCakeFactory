using System;

namespace TheChannelCakeFactory.Configuration
{
    public class BindingNameConfigurationException : ApplicationException
    {
        public BindingNameConfigurationException(string message)
            : base(message)
        {
        }
    }
}
