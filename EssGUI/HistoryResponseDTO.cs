using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssGUI
{
    class HistoryResponseDTO
    {
        String id;
        UserResponseDTO user;
        OrderResponseDTO order;
        OrderStatus prevStatus;
        OrderStatus actualStatus;
        DateTime orderStatusChangeDate;

        public string Id { get => id; set => id = value; }
        public UserResponseDTO User { get => user; set => user = value; }
        public DateTime OrderStatusChangeDate { get => orderStatusChangeDate; set => orderStatusChangeDate = value; }
        public OrderResponseDTO Order { get => order; set => order = value; }
        public OrderStatus PrevStatus { get => prevStatus; set => prevStatus = value; }
        public OrderStatus ActualStatus { get => actualStatus; set => actualStatus = value; }
    }
}
