namespace WeatherApplication.Model
{
    public class ResultsModel
    {
        public int Id { get; set; }


        public string Location { get; set; } = string.Empty;


        public string Country { get; set; } = string.Empty;


        public double Temp { get; set; }
    }
}
