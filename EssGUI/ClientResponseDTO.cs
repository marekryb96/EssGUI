using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class ClientResponseDTO
    {
        private String id;
        private String name;
        private String surname;       
        private Address address;
        private PhoneNumber phoneNumber;
        private String email;
        private ClientType clientType;
        private String nip;

        public string Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }        
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Nip { get => nip; set => nip = value; }
        public Address Address { get => address; set => address = value; }
        public ClientType ClientType { get => clientType; set => clientType = value; }
        public PhoneNumber PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
