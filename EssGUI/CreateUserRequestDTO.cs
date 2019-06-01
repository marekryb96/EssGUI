using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class CreateUserRequestDTO
    {
        String name;
        String surname;
        String login;
        String password;
        UserType userType;
        Boolean removed;

        [JsonProperty("login")]
        public string Login { get => login; set => login = value; }
        [JsonProperty("name")]
        public string Name { get => name; set => name = value; }
        [JsonProperty("password")]
        public string Password { get => password; set => password = value; }
        [JsonProperty("surname")]
        public string Surname { get => surname; set => surname = value; }
        public bool Removed { get => removed; set => removed = value; }
        [JsonProperty("userType")]
        internal UserType UserType { get => userType; set => userType = value; }
    }
}
