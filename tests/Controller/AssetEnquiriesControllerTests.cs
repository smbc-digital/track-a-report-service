using track_a_report_service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using StockportGovUK.NetStandard.Models.Enums;
using StockportGovUK.NetStandard.Models.TrackAReport.Requests;
using track_a_report_service.Services;

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
        public void Post_ShouldReturnNoContent()
        {
            // Act
            var response = _homeController.Post(new TrackAReportRequest
            {
                AssetId = "assetId",
                AssetType = EAssetType.StreetLightFault,
                ReferenceNumber = "ReferenceNumber"
            });

            var statusResponse = response.Result as NoContentResult;
            
            // Assert
            Assert.NotNull(statusResponse);
            Assert.Equal(204, statusResponse.StatusCode);
        }
    }
}
