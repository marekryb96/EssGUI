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
        String userLogin;
        String orderId;
        OrderStatus prevStatus;
        OrderStatus actualStatus;
        DateTime orderStatusChangeDate;

        public string Id { get => id; set => id = value; }
        public String UserLogin { get => userLogin; set => userLogin = value; }
        public DateTime OrderStatusChangeDate { get => orderStatusChangeDate; set => orderStatusChangeDate = value; }
        public String OrderId { get => orderId; set => orderId = value; }
        public OrderStatus PrevStatus { get => prevStatus; set => prevStatus = value; }
        public OrderStatus ActualStatus { get => actualStatus; set => actualStatus = value; }
    }
}
