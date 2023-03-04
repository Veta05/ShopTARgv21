using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARgv21.Core.Dto.Weather;
using ShopTARgv21.Core.ServiceInterface;

namespace ShopTARgv21.ApplicationServices.Services
{
    public interface IWeatherForecastServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}
