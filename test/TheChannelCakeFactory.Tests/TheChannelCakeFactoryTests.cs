using System;
using System.Globalization;
using System.ServiceModel;
using System.Threading;
using NUnit.Framework;

namespace TheChannelCakeFactory.Tests
{
    [ServiceContract]
    public interface IFoo 
    {
        [OperationContract]
        void Bar();
    }

    [TestFixture]
    public class TheChannelCakeFactoryTests
    {
        [SetUp]
        public void SetUp()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }

        [Test]
        public void Create_GivenAContractAndABindingConfugurationOnAppConfig_ShouldCreateProxyClient()
        {
            var theChannelCakeFactory = new TheChannelCakeFactory();
            IFoo channel = theChannelCakeFactory.Create<IFoo>();
            Assert.IsInstanceOf<IFoo>(channel);
        }
    }
}
