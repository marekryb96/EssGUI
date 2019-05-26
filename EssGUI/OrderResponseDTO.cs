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
        String defectDescription;
        DeviceResponseDTO device;
        String id;
        UserResponseDTO user;
        OrderStatus orderStatus;
        Costs costs;
        DateTime beginDate;
        DateTime endDate;
        Boolean days;

        public OrderResponseDTO()
        {
            var time = DateTime.Now - BeginDate;
            double d = time.Days;
            if (d > 6) days = true;
            else days = true;
            int a = 1;
        }

        public bool Calculated { get => calculated; set => calculated = value; }
        public string Description { get => description; set => description = value; }
        public string Id { get => id; set => id = value; }
        public ClientResponseDTO Client { get => client; set => client = value; }
        public DeviceResponseDTO Device { get => device; set => device = value; }
        public UserResponseDTO User { get => user; set => user = value; }
        public OrderStatus OrderStatus { get => orderStatus; set => orderStatus = value; }
        public Costs Costs { get => costs; set => costs = value; }
        public string DefectDescription { get => defectDescription; set => defectDescription = value; }
        public DateTime BeginDate { get => beginDate; set => beginDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
    }
}
