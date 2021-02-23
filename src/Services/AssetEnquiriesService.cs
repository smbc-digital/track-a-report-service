using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using track_a_report_service.Data;

namespace track_a_report_service.Service
{
    public class AssetEnquiriesService : IAssetEnquiriesService
    {
        private readonly InthubContext _db;

        public AssetEnquiriesService(InthubContext db) => _db = db;

        public async Task CreateAssetEnquiry()
        {
            var assetEnquiry = await _db.AssetEnquiries.SingleOrDefaultAsync(_ => _.ExternalReference.Equals("CHANGE-ME"));

            if(assetEnquiry != null)
                throw new System.Exception("Asset already exists with reference");

            _db.AssetEnquiries.Add(new AssetEnquiries{ ExternalReference = "CHANGE-ME", AssetId = "CHANGE-ME", AssetType = "CHANGE-ME" });

            await _db.SaveChangesAsync();
        }
    }
}