namespace PharmaCare.API.Helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statusCode, string? messege = null)
        {
            StatusCode = statusCode;
            Messege = messege?? GetMessegeFromCode(StatusCode);
        }

        private string GetMessegeFromCode(int statuscode)
        {
            return statuscode switch
            {
                200 => "Success",
                204 => "No Content",
                400 => "Bad Request",
                401 => "Unauthorized",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => null,
            };
        }

        public int StatusCode { get; set; }
        public string? Messege { get; set; }
    }
}
