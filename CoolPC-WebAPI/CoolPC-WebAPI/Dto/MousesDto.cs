using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class MousesDto
    {
        public long mouse_id { get; set; }
        public int dpi { get; set; }
        public int number_of_buttons { get; set; }
        public int frequency { get; set; }
        public long device_type_id { get; set; }

        public MousesDto(Mouses mouses)
        {
            this.mouse_id = mouses.mouse_id;
            this.dpi = mouses.dpi;
            this.number_of_buttons = mouses.number_of_buttons;
            this.frequency = mouses.frequency;
            this.device_type_id = mouses.device_type_id;
        }
    }
}