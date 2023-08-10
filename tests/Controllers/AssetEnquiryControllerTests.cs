using track_a_report_service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using StockportGovUK.NetStandard.Gateways.Enums;
using StockportGovUK.NetStandard.Gateways.Models.TrackAReport.Requests;
using track_a_report_service.Services;
using System.Threading.Tasks;

namespace track_a_report_service_tests.Controllers
{
    public class AssetEnquiryControllerTests
    {
        private readonly Mock<IAssetEnquiryService> _mockAssetEnquiriesService = new Mock<IAssetEnquiryService>();
        private readonly AssetEnquiryController _homeController;

        public AssetEnquiryControllerTests()
        {
            _homeController = new AssetEnquiryController(_mockAssetEnquiriesService.Object);
        }
        
        [Fact]
        public async Task Post_ShouldReturn_NoContent_OnSuccessful_Call()
        {
            // Act
            var response = await _homeController.Post(new TrackAReportRequest
            {
                AssetId = "assetId",
                AssetType = EAssetType.StreetLightFault,
                ReferenceNumber = "ReferenceNumber"
            });

            // Assert
            var statusResponse = Assert.IsType<NoContentResult>(response);
            Assert.NotNull(statusResponse);
            Assert.Equal(204, statusResponse.StatusCode);
        }

        [Fact]
        public async Task Post_ShouldReturn_BadRequest_WhenModel_IsNotValid()
        {
            // Act
            _homeController.ModelState.AddModelError("ReferenceNumber", "imvalid reference");
            var response = await _homeController.Post(new TrackAReportRequest());

            // Assert
            var statusResponse = Assert.IsType<BadRequestResult>(response);
            Assert.NotNull(statusResponse);
            Assert.Equal(400, statusResponse.StatusCode);
        }
    }
}
