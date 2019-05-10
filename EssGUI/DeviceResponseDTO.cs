using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class DeviceResponseDTO
    {
        String description;
        String id;
        String model;
        String name;
        Boolean removed;
        String serialNumber;
        String brand;
        OrderStatus orderStatus;

        public string Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public string Name { get => name; set => name = value; }
        public string Model { get => model; set => model = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public bool Removed { get => removed; set => removed = value; }
        public string Brand { get => brand; set => brand = value; }
        public OrderStatus OrderStatus { get => orderStatus; set => orderStatus = value; }
    }
}
