using Xunit;
using track_a_report_service.Services;
using System.Threading.Tasks;
using track_a_report_service.Data;
using Microsoft.EntityFrameworkCore;
using StockportGovUK.NetStandard.Gateways.Models.TrackAReport.Requests;
using track_a_report_service_tests.Constants;
using track_a_report_service.Constants;
using track_a_report_service.Exceptions;
using System.Linq;
using StockportGovUK.NetStandard.Gateways.Enums;

namespace track_a_report_service_tests.Services
{
    public class AssetEnquiryServiceTests : MockInthubBookingContext
    {
        private readonly AssetEnquiryService _service;

        public AssetEnquiryServiceTests() : base(new DbContextOptionsBuilder<InthubContext>()
            .UseInMemoryDatabase(databaseName: "testDb").Options)
        {
        }

        [Fact]
        public async Task CreateAssetEnquiry_ShouldThrowException_WhenAssetAlreadyExists_InDbContext()
        {
            var request = new TrackAReportRequest{ ReferenceNumber = AssetEnquiryConstants.EXISTING_EXTERNAL_ID };
            using (var db = new InthubContext(ContextOptions))
            {
                var availabilityService = CreateAssetEnquiryService(db);

                var result = await Assert.ThrowsAsync<AssetAlreadyExistsException>(() => availabilityService.CreateAssetEnquiry(request));
                Assert.Equal(string.Format(ExceptionMessage.ASSET_ENQUIRY_ALREADY_EXISTS, AssetEnquiryConstants.EXISTING_EXTERNAL_ID), result.Message);
            }
        }

        [Fact]
        public async Task CreateAssetEnquiry_ShouldReturn_Successfully_AfterCreatingAssetEnquriy_InDb()
        {
            var request = new TrackAReportRequest{ ReferenceNumber = AssetEnquiryConstants.NEW_ENQIRY, AssetId = "123", AssetType = EAssetType.StreetLightFault };
            using (var db = new InthubContext(ContextOptions))
            {
                var availabilityService = CreateAssetEnquiryService(db);

                await availabilityService.CreateAssetEnquiry(request);
                var assetEnquiry = db.AssetEnquiries
                    .FirstOrDefault(_ => _.ExternalReference == request.ReferenceNumber);
                Assert.NotNull(assetEnquiry);
            }
        }

        private AssetEnquiryService CreateAssetEnquiryService(InthubContext db) =>
            new AssetEnquiryService(db);
    }
}
