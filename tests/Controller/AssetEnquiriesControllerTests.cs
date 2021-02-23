using track_a_report_service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace track_a_report_service_tests.Controllers
{
    public class AssetEnquiriesControllerTests
    {
        private readonly AssetEnquiriesController _homeController;

        public AssetEnquiriesControllerTests()
        {
            _homeController = new AssetEnquiriesController();
        }

        [Fact]
        public void Get_ShouldReturnOK()
        {
            // Act
            var response = _homeController.Get();
            var statusResponse = response as OkResult;
            
            // Assert
            Assert.NotNull(statusResponse);
            Assert.Equal(200, statusResponse.StatusCode);
        }

        [Fact]
        public void Post_ShouldReturnOK()
        {
            // Act
            var response = _homeController.Post();
            var statusResponse = response as OkResult;
            
            // Assert
            Assert.NotNull(statusResponse);
            Assert.Equal(200, statusResponse.StatusCode);
        }
    }
}
