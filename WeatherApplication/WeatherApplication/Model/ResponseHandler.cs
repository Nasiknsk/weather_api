namespace WeatherApplication.Model
{
    public class ResponseHandler
    {
        public static ApiResponse GetExceptionResponse(Exception ex)
        {
            ApiResponse response= new ApiResponse();
            response.code = "1";
            response.ResponseData = ex.Message;
            return response;
        }
        public static ApiResponse GeApiResponse(ResponseType type , object? contract)
        {
            ApiResponse response;
            response= new ApiResponse { ResponseData = contract};
            switch(type) 
            {
                case ResponseType.Success:
                    response.code = "0";
                    response.message = "Success";
                    break;
                case ResponseType.NotFound:
                    response.code="2";
                    response.message = "No Record Available";
                    break;
            }
            return response;
        }
    }
}
