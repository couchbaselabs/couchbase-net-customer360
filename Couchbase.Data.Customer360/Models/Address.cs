using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase.Data.DAL;
using Newtonsoft.Json;

namespace Couchbase.Data.Customer360.Models
{
    public class Address
    {
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("state")]
        public string state { get; set; }
        [JsonProperty("city")]
        public string city { get; set; }
        [JsonProperty("line1")]
        public string line1 { get; set; }
        [JsonProperty("postalCode")]
        public string postalCode { get; set; }

    }
}