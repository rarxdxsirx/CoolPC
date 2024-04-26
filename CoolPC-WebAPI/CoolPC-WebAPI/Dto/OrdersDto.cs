using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class OrdersDto
    {
        public long order_id { get; set; }
        public long delivery_details_id { get; set; }
        public long payment_details_id { get; set; }
        public long order_status_id { get; set; }
        public long customer_id { get; set; }
        public string type { get; set; }

        public OrdersDto(Orders orders)
        {
            this.order_id = orders.order_id;
            this.delivery_details_id = orders.delivery_details_id;
            this.payment_details_id = orders.payment_details_id;
            this.order_status_id = orders.order_status_id;
            this.customer_id = orders.customer_id;
            this.type = orders.type;
        }
    }
}