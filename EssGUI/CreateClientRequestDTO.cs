using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class CreateClientRequestDTO
    {
        String name;
        String surname;
        String email;
        Address address;
        String nip;
        PhoneNumber phoneNumber;
        ClientType clientType;

        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("surname")]
        public string Surname { get => surname; set => surname = value; }
        [JsonProperty("nip")]
        public string Nip { get => nip; set => nip = value; }
        [JsonProperty("email")]
        public string Email { get => email; set => email = value; }
        [JsonProperty("address")]
        internal Address Address { get => address; set => address = value; }
        [JsonProperty("clientType")]
        internal ClientType ClientType { get => clientType; set => clientType = value; }
        [JsonProperty("phoneNumber")]
        internal PhoneNumber PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
