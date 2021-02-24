namespace track_a_report_service.Exceptions
{
    public class AssetAlreadyExistsException : HttpResponseException
    {
        public AssetAlreadyExistsException(string message) : base(message) { }

        public override int Status { get; set; } = 409;
    }
}
