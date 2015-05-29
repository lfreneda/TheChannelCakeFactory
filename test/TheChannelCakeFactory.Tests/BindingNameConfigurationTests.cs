using System.Configuration;
using NUnit.Framework;
using FluentAssertions;
using TheChannelCakeFactory.Configuration;

namespace TheChannelCakeFactory.Tests
{
    [TestFixture]
    public class BindingNameConfigurationTests
    {
        private BindingNameConfiguration _bindingNameConfiguration;

        public interface IFoo
        {
            void Bar();
        }

        [SetUp]
        public void SetUp()
        {
            _bindingNameConfiguration = new BindingNameConfiguration();
        }

        [TearDown]
        public void TearDown()
        {
            _bindingNameConfiguration.ClearConfiguration();
        }

        [Test]
        public void GetBindingName_WhenGettingABindingNameForIFooWhichWasNotConfigured_ShouldReturnConventionNameWhichIsIFoo_Endpoint()
        {
            _bindingNameConfiguration.GetBindingName<IFoo>().Should().Be("IFoo_Endpoint");
        }

        [Test]
        public void GetBindingName_WhenGettingABindingNameForIFooWhichWasConfigured_ShouldReturnIFoo_CustomName()
        {
            _bindingNameConfiguration.Configure<IFoo>("IFoo_CustomName");
            _bindingNameConfiguration.GetBindingName<IFoo>().Should().Be("IFoo_CustomName");
        }

        [Test]
        [ExpectedException(typeof(BindingNameConfigurationException), ExpectedMessage = "IFoo has already a bindingName configured, make sure you're not configuring twice")]
        public void Configure_WhenConfiguringABindingNameToAContractTwice_ItShouldThrowsException()
        {
            _bindingNameConfiguration.Configure<IFoo>("IFoo_CustomName1");
            _bindingNameConfiguration.Configure<IFoo>("IFoo_CustomName2");
        }
    }
}
