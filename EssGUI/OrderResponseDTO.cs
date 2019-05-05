using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class OrderResponseDTO
    {
        Boolean calculated;
        ClientResponseDTO client;
        String description;
        DeviceResponseDTO device;
        String id;
        UserResponseDTO user;

        public bool Calculated { get => calculated; set => calculated = value; }
        public string Description { get => description; set => description = value; }
        public string Id { get => id; set => id = value; }
        internal ClientResponseDTO Client { get => client; set => client = value; }
        internal DeviceResponseDTO Device { get => device; set => device = value; }
        internal UserResponseDTO User { get => user; set => user = value; }
    }
}
