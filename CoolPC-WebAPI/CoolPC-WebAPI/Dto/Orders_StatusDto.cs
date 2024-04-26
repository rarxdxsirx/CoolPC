using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class Orders_StatusDto
    {
        public long order_status_id { get; set; }
        public System.DateTime order_date { get; set; }
        public string payment_mark { get; set; }
        public string shipment_mark { get; set; }

        public Orders_StatusDto(Orders_Status orders_Status)
        {
            this.order_status_id = orders_Status.order_status_id;
            this.order_date = orders_Status.order_date;
            this.payment_mark = orders_Status.payment_mark;
            this.shipment_mark = orders_Status.shipment_mark;
        }
    }
}