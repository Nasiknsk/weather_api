using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApplication.Entity
{
    [Table("results")]
    public class Results
    {
        [Key, Required]
        public int Id { get; set; }

        
        public string Location { get; set; }=string.Empty;


        public string Country { get; set; } = string.Empty;

       
        public double Temp { get; set; }
    }
}
