using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Couchbase.Data.DAL
{
    public abstract class EntityBase : IEntity
    {
        private static string _typeName;

        protected EntityBase()
        {
            if (_typeName == null)
            {
                _typeName = GetType().Name;
            }
            Type = _typeName;
        }
      [JsonProperty("id")]
        public string Id { get; set; }
     
        public string Type { get; set; }
        [JsonIgnore]
        public ulong Cas { get; set; }
    }
}
