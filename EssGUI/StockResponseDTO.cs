﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class StockResponseDTO
    {
        String brand;
        String description;
        String id;
        String model;
        String name;
        int quantity;
        Boolean removed;
        String serialNumber;

        public string Brand { get => brand; set => brand = value; }
        public string Description { get => description; set => description = value; }
        public string Id { get => id; set => id = value; }
        public string Model { get => model; set => model = value; }
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public bool Removed { get => removed; set => removed = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
    }
}
