﻿using Newtonsoft.Json;


namespace DataLayer.Model
{
    public class InitialWoFSettings
    {
        [JsonProperty("Language")]
        public string Language { get; set; }

        [JsonProperty("Championship")]
        public string Championship { get; set; }

        [JsonProperty("ScreenSize")]
        public string ScreenSize { get; set; }


   
    }
}

