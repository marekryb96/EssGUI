using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class CreateOrderRequestDTO
    {
        String clientId;
        String defectDescription;
        String description;
        String deviceId;
        String userLogin;
        Costs costs;

        [JsonProperty("clientId")]
        public string ClientId { get => clientId; set => clientId = value; }
        [JsonProperty("defectDescription")]
        public string DefectDescription { get => defectDescription; set => defectDescription = value; }
        [JsonProperty("description")]
        public string Description { get => description; set => description = value; }
        [JsonProperty("deviceId")]
        public string DeviceId { get => deviceId; set => deviceId = value; }
        [JsonProperty("userLogin")]
        public string UserLogin { get => userLogin; set => userLogin = value; }
        public Costs Costs { get => costs; set => costs = value; }
    }

}
