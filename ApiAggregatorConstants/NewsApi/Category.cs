using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace ApiAggregatorConstants.NewsApi
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Category
    {
        None = 0,
        Business,
        Entertainment,
        General,
        Health,
        Science,
        Sports,
        Technology
    }
}
