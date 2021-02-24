using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockportGovUK.NetStandard.Models.TrackAReport.Requests;
using track_a_report_service.Data;
using track_a_report_service.Exceptions;

namespace track_a_report_service.Services
{
    public class AssetEnquiriesService : IAssetEnquiriesService
    {
        private readonly InthubContext _db;

        public AssetEnquiriesService(InthubContext db) => _db = db;

        public async Task CreateAssetEnquiry(TrackAReportRequest request)
        {
            var assetEnquiry = await _db.AssetEnquiries.SingleOrDefaultAsync(_ => _.ExternalReference.Equals(request.ReferenceNumber));

            if (assetEnquiry != null)
                throw new AssetAlreadyExistsException($"Asset already exists with reference {request.ReferenceNumber}");

            try
            {
                _db.AssetEnquiries.Add(new AssetEnquiries
                {
                    ExternalReference = request.ReferenceNumber, 
                    AssetId = request.AssetId,
                    AssetType = request.AssetType.ToString(),
                    CreatedOn = DateTime.Now
                });

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}