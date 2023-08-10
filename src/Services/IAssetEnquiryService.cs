using System.Threading.Tasks;
using StockportGovUK.NetStandard.Gateways.Models.TrackAReport.Requests;

namespace track_a_report_service.Services
{
    public interface IAssetEnquiryService
    {
        Task CreateAssetEnquiry(TrackAReportRequest request);
    }
}