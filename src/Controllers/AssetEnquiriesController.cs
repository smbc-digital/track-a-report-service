using Microsoft.AspNetCore.Mvc;
using StockportGovUK.AspNetCore.Attributes.TokenAuthentication;
using track_a_report_service.Service;

namespace track_a_report_service.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[Controller]")]
    [ApiController]
    [TokenAuthentication]
    public class AssetEnquiriesController : ControllerBase
    {
        private readonly IAssetEnquiriesService _assetEnquiriesService;
        public AssetEnquiriesController(IAssetEnquiriesService assetEnquiriesService) => assetEnquiriesService = _assetEnquiriesService;

        [HttpPost]
        public IActionResult Post()
        {

            return Ok();
        }
    }
}