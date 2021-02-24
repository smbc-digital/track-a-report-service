namespace track_a_report_service.Exceptions
{
    public class AssetBadRequestException : HttpResponseException
    {
        public AssetBadRequestException(string message) : base(message) { }

        public override int Status { get; set; } = 400;
    }
}
