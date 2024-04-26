using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class ConfigurationsDto
    {
        public long configuration_id { get; set; }
        public string custom { get; set; }
        public string name { get; set; }

        public ConfigurationsDto(Configurations configurations)
        {
            this.configuration_id = configurations.configuration_id;
            this.custom = configurations.custom;
            this.name = configurations.name;
        }
    }
}