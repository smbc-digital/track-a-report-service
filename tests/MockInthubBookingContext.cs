using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StockportGovUK.NetStandard.Gateways.Enums;
using track_a_report_service.Data;
using track_a_report_service_tests.Constants;

namespace track_a_report_service_tests
{
    public class MockInthubBookingContext
    {
        protected MockInthubBookingContext(DbContextOptions<InthubContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        public DbContextOptions<InthubContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new InthubContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var assetEnquiries = SetAssetEnquries();
                if (assetEnquiries.Any())
                    context.AssetEnquiries.AddRange(assetEnquiries);

                context.SaveChanges();
            }
        }
        private static List<AssetEnquiries> SetAssetEnquries()
        {
            var customers = new List<AssetEnquiries>
            {
                new AssetEnquiries
                {
                    AssetId = "12345",
                    AssetType = EAssetType.StreetLightFault.ToString(),
                    CreatedOn = DateTime.Now,
                    ExternalReference = AssetEnquiryConstants.EXISTING_EXTERNAL_ID,
                    Id = 1
                }
            };

            return customers;
        }
    }
}
