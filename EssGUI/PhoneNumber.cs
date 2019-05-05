using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class PhoneNumber
    {
        String areaCode;
        String number;

        [JsonProperty("areaCode")]
        public string AreaCode { get => areaCode; set => areaCode = value; }
        [JsonProperty("number")]
        public string Number { get => number; set => number = value; }
    }
}
