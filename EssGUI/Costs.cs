using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class Costs
    {
        String deviceCosts;
        String labourCosts;

        [JsonProperty("deviceCosts")]
        public string DeviceCosts { get => deviceCosts; set => deviceCosts = value; }
        [JsonProperty("labourCosts")]
        public string LabourCosts { get => labourCosts; set => labourCosts = value; }
    }
}
