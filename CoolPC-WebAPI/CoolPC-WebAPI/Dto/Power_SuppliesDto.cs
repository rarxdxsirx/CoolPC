using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class Power_SuppliesDto
    {
        public long power_supply_id { get; set; }
        public string power { get; set; }
        public string cable_length { get; set; }
        public string pins { get; set; }
        public long device_type_id { get; set; }

        public Power_SuppliesDto(Power_Supplies power_Supplies)
        {
            this.power_supply_id = power_Supplies.power_supply_id;
            this.power = power_Supplies.power;
            this.cable_length = power_Supplies.cable_length;
            this.pins = power_Supplies.pins;
            this.device_type_id = power_Supplies.device_type_id;
        }
    }
}