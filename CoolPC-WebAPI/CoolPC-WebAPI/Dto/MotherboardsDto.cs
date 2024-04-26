using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolPC_WebAPI.Dto
{
    public class MotherboardsDto
    {
        public long motherbroad_id { get; set; }
        public string form_factor { get; set; }
        public string socket { get; set; }
        public int memory_slots { get; set; }
        public string memory_frequency { get; set; }
        public int pci_slots { get; set; }
        public int sata_slots { get; set; }
        public string pins { get; set; }
        public long device_type_id { get; set; }

        public MotherboardsDto(Motherboards motherboards)
        {
            this.motherbroad_id = motherboards.motherbroad_id;
            this.form_factor = motherboards.form_factor;
            this.socket = motherboards.socket;
            this.memory_slots = motherboards.memory_slots;
            this.memory_frequency = motherboards.memory_frequency;
            this.pci_slots = motherboards.pci_slots;
            this.sata_slots = motherboards.sata_slots;
            this.pins = motherboards.pins;
            this.device_type_id = motherboards.device_type_id;
        }
    }
}