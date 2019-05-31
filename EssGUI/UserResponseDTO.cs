using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    public class UserResponseDTO
    {
        String id;
        String name;
        String surname;
        String login;
        UserType userType;
        Boolean removed;
     

        public string Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Name { get => name; set => name = value; }
        public bool Removed { get => removed; set => removed = value; }
        public string Surname { get => surname; set => surname = value; }
        public UserType UserType { get => userType; set => userType = value; }
    }
}
