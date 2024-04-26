using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class KeyboardsDto
    {
        public long keyboard_id { get; set; }
        public string type { get; set; }
        public string format { get; set; }
        public int number_of_buttons { get; set; }
        public long device_type_id { get; set; }

        public KeyboardsDto(Keyboards keyboards)
        {
            this.keyboard_id = keyboards.keyboard_id;
            this.type = keyboards.type;
            this.format = keyboards.format;
            this.number_of_buttons = keyboards.number_of_buttons;
            this.device_type_id = keyboards.device_type_id;
        }
    }
}