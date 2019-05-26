using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class CreateSettlementRequestDTO
    {
        [JsonProperty("ordersIds")]
        List<string> ordersIds;
        public List<string> OrdersIds { get => ordersIds; set => ordersIds = value; }
    }
}
