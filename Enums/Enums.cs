using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dukkantek_WebAPI.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductStatus
    {
        INSTOCK = 1,
        SOLD,
        DAMAGED
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SaleType
    {
        CASH = 1,
        CREDIT
    }
}
