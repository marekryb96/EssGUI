using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class CreateDeviceRequestDTO
    {
        [JsonProperty("brand")]
        String brand;
        [JsonProperty("description")]
        String description;
        [JsonProperty("id")]
        String id;
        [JsonProperty("model")]
        String model;
        [JsonProperty("name")]
        String name;
        [JsonProperty("removed")]
        Boolean removed;
        [JsonProperty("serialNumber")]
        String serialNumber;

        public string Description { get => description; set => description = value; }
        public string Id { get => id; set => id = value; }
        public string Model { get => model; set => model = value; }
        public string Name { get => name; set => name = value; }
        public bool Removed { get => removed; set => removed = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string Brand { get => brand; set => brand = value; }
        //internal Brand Brand { get => brand; set => brand = value; }
    }
}
