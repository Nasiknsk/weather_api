using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApplication.Entity;
using WeatherApplication.Model;
using WeatherApplication.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApplication.Controllers
{

    [ApiController]
    public class ValuesController : ControllerBase

    {
        private readonly DbHelper _db;
        private readonly string apiKey = "7c4b6c87791544b29ec144203230111";
        public ValuesController(DataContextcs dataContextcs)
        {
            _db = new DbHelper(dataContextcs);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Route("api/[controller]/GetResults")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<ResultsModel> data = _db.GetResults();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GeApiResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet]
        [Route("api/[controller]/GetResultsById")]
        public IActionResult Get([FromQuery] int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                ResultsModel data = _db.GetResultsById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }

                return Ok(ResponseHandler.GeApiResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


        // POST api/<ValuesController>
        /*[HttpPost]
        [Route("api/[controller]/SaveResult")]

        public IActionResult Post([FromBody] ResultsModel resultsModel)
        {
            ResponseType type = ResponseType.Success;

            try
            {
                _db.SaveResult(resultsModel);
                return Ok(ResponseHandler.GeApiResponse(type, resultsModel));
            }
            catch (Exception ex) 
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }*/
        [HttpGet]
        [Route("api/[controller]/SaveResult")]
        public async Task<IActionResult> GetWeatherData(string city)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                // Ensure the city parameter is provided
                if (string.IsNullOrEmpty(city))
                {
                    return BadRequest("City parameter is required.");
                }

                // Construct the WeatherAPI URL
                string apiUrl = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&aqi=no&q={city}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response from the WeatherAPI
                        string jsonString = await response.Content.ReadAsStringAsync();
                        ThirdPartyApiResponse thirdPartyResponse = JsonConvert.DeserializeObject<ThirdPartyApiResponse>(jsonString);

                        // Save required data to your database
                        double tempC = thirdPartyResponse.Current.TempC;
                        string country = thirdPartyResponse.Location.Country;

                        // Create a new model to save to the database
                        ResultsModel resultsModel = new ResultsModel
                        {
                            Location = city,
                            Temp = tempC,
                            Country = country
                        };

                        // Save the data to your database
                        _db.SaveResult(resultsModel);
                        return Ok(ResponseHandler.GeApiResponse(type, resultsModel));


                        // Return the saved data in the response
                       
                    }
                    else
                    {
                        // Handle the error from the WeatherAPI
                        return BadRequest($"Failed to fetch data from the WeatherAPI. Status Code: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }



        // PUT api/<ValuesController>/5
        [HttpPut]
        [Route("api/Values/UpdateResult")]
        public IActionResult Put([FromQuery] int id, [FromBody] ResultsModel resultsModel)
        {
            ResponseType type = ResponseType.Success;

            try
            {
                // Set the ID from the query parameter to the resultsModel
                resultsModel.Id = id;
                _db.SaveResult(resultsModel);
                return Ok(ResponseHandler.GeApiResponse(type, resultsModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete]
        [Route("api/Values/DeleteResults")]
        public IActionResult DeleteResults([FromQuery] int id)
        {
            ResponseType type = ResponseType.Success;

            try
            {
                _db.DeleteResults(id);
                return Ok(ResponseHandler.GeApiResponse(type, "Deleted !"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }


    }
}
