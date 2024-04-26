using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class DeliveriesDetailsDto
    {
        public long delivery_details_id { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public int postal_code { get; set; }
        public string street { get; set; }
        public int building { get; set; }
        public int apartament { get; set; }
        public string region { get; set; }

        public DeliveriesDetailsDto(Deliveries_Details deliveries_Details)
        {
            this.delivery_details_id = deliveries_Details.delivery_details_id;
            this.country = deliveries_Details.country;
            this.city = deliveries_Details.city;
            this.postal_code = deliveries_Details.postal_code;
            this.street = deliveries_Details.street;
            this.building = deliveries_Details.building;
            this.apartament = deliveries_Details.apartament;
            this.region = deliveries_Details.region;
        }
    }
}