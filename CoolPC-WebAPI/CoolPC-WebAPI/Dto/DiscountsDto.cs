using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class DiscountsDto
    {
        public long discount_id { get; set; }
        public double discount_amount { get; set; }

        public DiscountsDto(Discounts discounts)
        {
            this.discount_id = discounts.discount_id;
            this.discount_amount = discounts.discount_amount;
        }
    }
}