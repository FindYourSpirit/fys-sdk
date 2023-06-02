using FYS_SDK.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FYS_SDK.tests
{
    [TestClass]
    public class SdkConfigurationTests
    {
        [TestMethod]
        public void GetBaseUrl_ReturnsLiveEnvironmentUrl()
        {
            // Arrange
            var configuration = new SdkConfiguration("apiKey", EnvironmentType.Live, "jwtToken", "clientId", "v1");

            // Act
            var baseUrl = configuration.GetBaseUrl();

            // Assert
            Assert.AreEqual("https://api.live.fysapp.co/v1", baseUrl);
        }

        [TestMethod]
        public void GetBaseUrl_ReturnsTestEnvironmentUrl()
        {
            // Arrange
            var configuration = new SdkConfiguration("apiKey", EnvironmentType.Test, "jwtToken", "clientId", "v2");

            // Act
            var baseUrl = configuration.GetBaseUrl();

            // Assert
            Assert.AreEqual("https://api.test.fysapp.co/v2", baseUrl);
        }

        [TestMethod]
        public void GetBaseUrl_ThrowsExceptionForInvalidEnvironment()
        {
            // Arrange
            var configuration = new SdkConfiguration("apiKey", (EnvironmentType)99, "jwtToken", "clientId", "v1");

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => configuration.GetBaseUrl());
        }
    }
}
