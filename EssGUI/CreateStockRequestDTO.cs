using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class CreateStockRequestDTO
    {
        int count;
        String orderId;
        String stockId;

        [JsonProperty("count")]
        public int Count { get => count; set => count = value; }
        [JsonProperty("orderId")]
        public string OrderID { get => orderId; set => orderId = value; }
        [JsonProperty("stockId")]
        public string StockId { get => stockId; set => stockId = value; }
    }
}
