using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class SSDsDto
    {
        public long ssd_id { get; set; }
        public string type { get; set; }
        public string capacity { get; set; }
        public string max_read_speed { get; set; }
        public string max_write_speed { get; set; }
        public long device_type_id { get; set; }

        public SSDsDto(SSDs sSDs)
        {
            this.ssd_id = sSDs.ssd_id;
            this.type = sSDs.type;
            this.capacity = sSDs.capacity;
            this.max_read_speed = sSDs.max_read_speed;
            this.max_write_speed = sSDs.max_write_speed;
            this.device_type_id = sSDs.device_type_id;
        }
    }
}