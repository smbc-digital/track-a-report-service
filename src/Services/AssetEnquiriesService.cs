using System.Linq;
using track_a_report_service.Data;

namespace track_a_report_service.Service
{
    public class AssetEnquiriesService : IAssetEnquiriesService
    {
        private readonly InthubContext _db;

        public AssetEnquiriesService(InthubContext db) => _db = db;

        public void CreateAssetEnquiry()
        {
            //Check the id does not exist already and throw
            var assetEnquiry = _db.AssetEnquiries.Where(_ => _.ExternalReference.Equals("REPLACE-ME")).FirstOrDefault();

            //If it doesent add it
        }
    }
}