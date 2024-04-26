using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class Components_TypesDto
    {
        public long component_type_id { get; set; }
        public string type { get; set; }

        public Components_TypesDto(Components_Types components_Types)
        {
            this.component_type_id = components_Types.component_type_id;
            this.type = components_Types.type;
        }
    }
}