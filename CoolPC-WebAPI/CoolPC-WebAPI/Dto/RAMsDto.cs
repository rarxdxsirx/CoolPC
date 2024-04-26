using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class RAMsDto
    {
        public long ram_id { get; set; }
        public string type { get; set; }
        public int count { get; set; }
        public string memory_volume { get; set; }
        public string frequency { get; set; }
        public long device_type_id { get; set; }

        public RAMsDto(RAMs rAMs)
        {
            this.ram_id = rAMs.ram_id;
            this.type = rAMs.type;
            this.count = rAMs.count;
            this.memory_volume = rAMs.memory_volume;
            this.frequency = rAMs.frequency;
            this.device_type_id = rAMs.device_type_id;
        }
    }
}