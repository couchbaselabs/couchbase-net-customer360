using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Couchbase.Data.DAL;
using Newtonsoft.Json;

namespace Couchbase.Data.Customer360.Models
{
    public class Customer : EntityBase
    {

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string created { get; set; }

       [JsonProperty("customerid")]
        public string customerid { get; set; }

        public Address billingAddress { get; set; }

        public string Type { get; set; }

        public string updated { get; set; }

        public string email { get; set; }

        public string userName { get; set; }

 }
}