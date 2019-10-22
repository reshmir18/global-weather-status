using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Configuration;

namespace WeatherService.Controllers
{
    public class GlobalWeatherController : ApiController
    {
        [Route("api/GlobalWeather")]
        [HttpGet]
        public string Index()
        {
            string inputFilePath = ConfigurationManager.AppSettings["InputFilePath"];
            string identifier = "", cityName = "", response = "";
            string status = "Success";
            try
            {
                string[] cityData = File.ReadAllLines(inputFilePath);
                foreach (string city in cityData)
                {
                    identifier = city.Split('=')[0];
                    cityName = city.Split('=')[1];
                    HttpRequest request = new HttpRequest();
                    
                    // Invokes the method to fetch weather information
                    response = request.SendRequest(identifier);

                    //Checks for availability of directory and file and logs the data
                    DirectoryInfo directoryInfo = Directory.CreateDirectory(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName.Replace("\\WeatherService.Tests","")+"\\EveryDay Weather Status\\" + DateTime.Now.ToShortDateString());
                    FileStream fileStream = new FileStream(directoryInfo.FullName + "\\" + cityName + ".txt", FileMode.Create);
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(response);
                    }
                }
            }
            catch (Exception ex)
            {
                status = "Failure fetching weather information for " + cityName + ", Exception: " + ex.Message;
            }

            return status;
        }
    }
}