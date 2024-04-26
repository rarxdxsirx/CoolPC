using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class GPUsDto
    {
        public long gpu_id { get; set; }
        public string frequency { get; set; }
        public string memory { get; set; }
        public string memory_frequency { get; set; }
        public string power_consuption { get; set; }
        public long device_type_id { get; set; }

        public GPUsDto(GPUs gPUs)
        {
            this.gpu_id = gPUs.gpu_id;
            this.frequency = gPUs.frequency;
            this.memory = gPUs.memory;
            this.memory_frequency = gPUs.memory_frequency;
            this.power_consuption = gPUs.power_consuption;
            this.device_type_id = gPUs.device_type_id;
        }
    }
}