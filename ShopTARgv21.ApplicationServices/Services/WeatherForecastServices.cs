using Nancy.Json;
using ShopTARgv21.Core.Dto.Weather;
using System.Net;

namespace ShopTARgv21.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            string apiKey = "1Aw4wIUG3AlDUZpDWLpbb0yFB4P0qD3N";
            var url = $"http://dataservice.accuweather.com/currentconditions/v1/1?apikey={apiKey}&et&details=false";
            var url2 = $"http://dataservice.accuweather.com/currentconditions/v1/1?apikey=1Aw4wIUG3AlDUZpDWLpbb0yFB4P0qD3N&et&details=false";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url2);
                //ainult ühe classi saab deserialiseerida korraga
                Root weatherInfo = (new JavaScriptSerializer()).Deserialize<Root>(json);

                dto.LocalObservationDateTime = weatherInfo.DailyForecasts[0].LocalObservationDateTime;
                dto.EpochTime = weatherInfo.DailyForecasts[0].EpochTime;
                dto.WeatherText = weatherInfo.DailyForecasts[0].WeatherText;
                dto.WeatherIcon = weatherInfo.DailyForecasts[0].WeatherIcon;
                dto.HasPrecipitation = weatherInfo.DailyForecasts[0].HasPrecipitation;
                dto.IsDayTime = weatherInfo.DailyForecasts[0].IsDayTime;
                dto.MobileLink = weatherInfo.DailyForecasts[0].MobileLink;
                dto.Link = weatherInfo.DailyForecasts[0].Link;

                dto.TempMetricValue = weatherInfo.DailyForecasts[0].Temperature.Metric.Value;
                dto.TempMetricUnit = weatherInfo.DailyForecasts[0].Temperature.Metric.Unit;
                dto.TempMetricUnitType = weatherInfo.DailyForecasts[0].Temperature.Metric.UnitType;

                dto.TempImperialValue = weatherInfo.DailyForecasts[0].Temperature.Imperial.Value;
                dto.TempImperialUnit = weatherInfo.DailyForecasts[0].Temperature.Imperial.Unit;
                dto.TempImperialUnitType = weatherInfo.DailyForecasts[0].Temperature.Imperial.UnitType;

                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }
            return dto;
        }
    }
}
