using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockportGovUK.NetStandard.Gateways.Models.TrackAReport.Requests;
using track_a_report_service.Constants;
using track_a_report_service.Data;
using track_a_report_service.Exceptions;

namespace track_a_report_service.Services
{
    public class AssetEnquiryService : IAssetEnquiryService
    {
        private readonly InthubContext _db;
        public AssetEnquiryService(InthubContext db) => _db = db;

        public async Task CreateAssetEnquiry(TrackAReportRequest request)
        {
            var assetEnquiry = await _db.AssetEnquiries.SingleOrDefaultAsync(_ => _.ExternalReference.Equals(request.ReferenceNumber));

            if (assetEnquiry != null)
                throw new AssetAlreadyExistsException(string.Format(ExceptionMessage.ASSET_ENQUIRY_ALREADY_EXISTS, request.ReferenceNumber));

            _db.AssetEnquiries.Add(new AssetEnquiries
            {
                ExternalReference = request.ReferenceNumber, 
                AssetId = request.AssetId,
                AssetType = request.AssetType.ToString(),
                CreatedOn = DateTime.Now
            });

            await _db.SaveChangesAsync();
        }
    }
}