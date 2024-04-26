using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class Payments_DetailsDto
    {
        public long payment_details_id { get; set; }
        public string method { get; set; }
        public long discount_id { get; set; }

        public Payments_DetailsDto(Payments_Details payments_Details)
        {
            this.payment_details_id = payments_Details.payment_details_id;
            this.method = payments_Details.method;
            this.discount_id = payments_Details.discount_id;
        }
    }

}