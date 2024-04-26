using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class HDDsDto
    {
        public long hdd_id { get; set; }
        public string capacity { get; set; }
        public string spindle_speed { get; set; }
        public string latency { get; set; }
        public string data_speed { get; set; }
        public long device_type_id { get; set; }

        public HDDsDto(HDDs hDDs)
        {
            this.hdd_id = hDDs.hdd_id;
            this.capacity = hDDs.capacity;
            this.spindle_speed = hDDs.spindle_speed;
            this.latency = hDDs.latency;
            this.data_speed = hDDs.data_speed;
            this.device_type_id = hDDs.device_type_id;
        }
    }
}