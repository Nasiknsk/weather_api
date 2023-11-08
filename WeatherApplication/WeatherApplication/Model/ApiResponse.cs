namespace WeatherApplication.Model
{
    public class ApiResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public object? ResponseData { get; set; }


    }
    public enum ResponseType 
    {
        Success,
        NotFound,
        Failure
    }
}
