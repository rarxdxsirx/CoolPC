using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class ComponentsDto
    {
        public long component_id { get; set; }
        public string model { get; set; }
        public long type_id { get; set; }
        public decimal price { get; set; }
        public long device_id { get; set; }
        public string color { get; set; }
        public Nullable<long> discount_id { get; set; }

        public ComponentsDto(Components components)
        {
            this.component_id = components.component_id;
            this.model = components.model;
            this.type_id = components.type_id;
            this.price = components.price;
            this.device_id = components.device_id;
            this.color = components.color;
            this.discount_id = components.discount_id;
        }
    }
}