using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class Configuration_In_OrdersDto
    {
        public Nullable<long> configuration_id { get; set; }
        public long order_id { get; set; }

        public Configuration_In_OrdersDto(Configuration_In_Orders configuration)
        {
            this.configuration_id = configuration.configuration_id;
            this.order_id = configuration.order_id;
        }
    }
}