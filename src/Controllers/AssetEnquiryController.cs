using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockportGovUK.AspNetCore.Attributes.TokenAuthentication;
using StockportGovUK.NetStandard.Models.TrackAReport.Requests;
using track_a_report_service.Services;

namespace track_a_report_service.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [ApiController]
    [TokenAuthentication]
    public class AssetEnquiryController : ControllerBase
    {
        private readonly IAssetEnquiryService _assetEnquiriesService;
        public AssetEnquiryController(IAssetEnquiryService assetEnquiriesService) => _assetEnquiriesService = assetEnquiriesService;

        /// <summary>
        /// Adds an asset enquiry to the database
        /// </summary>
        /// <param name="request">The asset enquiry details</param>
        /// <returns> IActionResult </returns>
        /// <remarks> Adds the asset enquiry to the database if a record for that reference doesn't already exist </remarks>
        /// <response code="204">Success with no content</response>
        /// <response code="400">Track a report request model is not valid</response>
        /// <response code="409">Asset enquiry already exists</response>
        /// <response code="500">An error has occurred while attempting to add the asset enquiry</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([Required][FromBody]TrackAReportRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            await _assetEnquiriesService.CreateAssetEnquiry(request);
            return NoContent();
        }
    }
}