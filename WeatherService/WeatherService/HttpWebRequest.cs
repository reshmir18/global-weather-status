using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;


namespace WeatherService
{
    public class HttpRequest
    {
        public string SendRequest(string identifier)
        {
            string url = "https://openweathermap.org/data/2.5/weather";
            string urlParameters = "?id=";
            string responseContent="";
            string appID = ConfigurationManager.AppSettings["AppID"];
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response =client.GetAsync(urlParameters + identifier+ "&appid="+appID).Result;
            if (response.IsSuccessStatusCode)
            {
               var responseData=response.Content.ReadAsStringAsync();
                responseContent = responseData.Result.ToString();
            }

            return responseContent;

        }
    }
}