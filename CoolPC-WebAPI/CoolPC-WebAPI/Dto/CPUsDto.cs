using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class CPUsDto
    {
        public long cpu_id { get; set; }
        public string socket { get; set; }
        public long number_of_cores { get; set; }
        public string frequency { get; set; }
        public string threads { get; set; }
        public long device_type_id { get; set; }

        public CPUsDto(CPUs cPUs)
        {
            this.cpu_id = cPUs.cpu_id;
            this.socket = cPUs.socket;
            this.number_of_cores = cPUs.number_of_cores;
            this.frequency = cPUs.frequency;
            this.threads = cPUs.threads;
            this.device_type_id = cPUs.device_type_id;
        }
    }
}