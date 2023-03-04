﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopTARgv21.Core.Dto.Weather
{
    public class WeatherResultDto
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public object PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
        public float TempMetricValue { get; set; }
        public string TempMetricUnit { get; set; }
        public int TempMetricUnitType { get; set; }
        public float TempImperialValue { get; set; }
        public string TempImperialUnit { get; set; }
        public int TempImperialUnitType { get; set; }

    }
}
