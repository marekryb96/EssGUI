using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class SettlementResponseDTO
    {
        String id;
        //orders
        DateTime dateTime;
        String finalDeviceCost;
        String finalLabourCost;
        String finalCost;

        public string Id { get => id; set => id = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string FinalDeviceCost { get => finalDeviceCost; set => finalDeviceCost = value; }
        public string FinalLabourCost { get => finalLabourCost; set => finalLabourCost = value; }
        public string FinalCost { get => finalCost; set => finalCost = value; }
    }
}
