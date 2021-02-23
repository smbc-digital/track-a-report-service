using track_a_report_service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace track_a_report_service_tests.Controllers
{
    public class HomeControllerTests
    {
        private readonly HomeController _homeController;

        public HomeControllerTests()
        {
            _homeController = new HomeController();
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
