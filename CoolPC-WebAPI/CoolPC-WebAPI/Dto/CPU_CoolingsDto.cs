using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class CPU_CoolingsDto
    {
        public long cpu_cooling_id { get; set; }
        public string min_speed { get; set; }
        public string max_speed { get; set; }
        public long device_type_id { get; set; }

        public CPU_CoolingsDto(CPU_Coolings coolings)
        {
            this.cpu_cooling_id = coolings.cpu_cooling_id;
            this.min_speed = coolings.min_speed;
            this.max_speed = coolings.max_speed;
            this.device_type_id = coolings.device_type_id;
        }
    }
}