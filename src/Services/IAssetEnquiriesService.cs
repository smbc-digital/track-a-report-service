using System.Threading.Tasks;
using StockportGovUK.NetStandard.Models.TrackAReport.Requests;

namespace track_a_report_service.Services
{
    public interface IAssetEnquiriesService
    {
        Task CreateAssetEnquiry(TrackAReportRequest request);
    }
}