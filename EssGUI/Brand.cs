using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class Brand
    {
        String city;
        String country;
        String houseNumber;
        String street;
        String zipDode;

        [JsonProperty("city")]
        public string City { get => city; set => city = value; }
        [JsonProperty("country")]
        public string Country { get => country; set => country = value; }
        [JsonProperty("houseNumber")]
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        [JsonProperty("street")]
        public string Street { get => street; set => street = value; }
        [JsonProperty("zipDode")]
        public string ZipDode { get => zipDode; set => zipDode = value; }
    }
}
