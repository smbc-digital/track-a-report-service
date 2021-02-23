using track_a_report_service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using track_a_report_service.Service;

namespace track_a_report_service_tests.Controllers
{
    public class AssetEnquiriesControllerTests
    {
        private readonly Mock<IAssetEnquiriesService> _mockAssetEnquiriesService = new Mock<IAssetEnquiriesService>();
        private readonly AssetEnquiriesController _homeController;

        public AssetEnquiriesControllerTests()
        {
            _homeController = new AssetEnquiriesController(_mockAssetEnquiriesService.Object);
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
