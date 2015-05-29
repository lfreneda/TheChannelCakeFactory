using System.ServiceModel;

namespace TheChannelCakeFactory
{
    public class TheChannelCakeFactory
    {
        private readonly BindingNameConfiguration _bindingNameConfiguration;

        public TheChannelCakeFactory()
        {
            _bindingNameConfiguration = new BindingNameConfiguration();
        }

        public T Create<T>()
        {
            var endpointConfigurationName = _bindingNameConfiguration.GetBindingName<T>();
            var factory = new ChannelFactory<T>(endpointConfigurationName);
            T channel = factory.CreateChannel();
            return channel;
        }
    }
}