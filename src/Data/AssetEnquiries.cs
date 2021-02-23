using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace track_a_report_service.Data
{
    public partial class AssetEnquiries
    {
        public int Id { get; set; }
        public string ExternalReference { get; set; }
        public DateTime CreatedOn { get; set; }
        public string AssetId { get; set; }
        public string AssetType { get; set; }
    }
}
