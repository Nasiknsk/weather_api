namespace WeatherApplication.Models
{
    public class ThirdPartyApiResponse
    {
        public CurrentWeather Current { get; set; }
        public Location Location { get; set; }
    

        // Add other properties as needed based on the actual response structure
    }

    public class CurrentWeather
    {
        public double TempC { get; set; }

        // Add other properties for temperature as needed
    }

    public class Location
    {
        public string Country { get; set; }

        // Add other properties for location as needed
    }
}
