using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDRTools.Models
{
    public class Get_Llamadas_Extensiones
    {
        public int globalCallID_callManagerId { get; set; }
        public int globalCallID_callId { get; set; }
        public DateTime dateTimeOrigination { get; set; }
        public string callingPartyNumber { get; set; }
        public string Extension_Descripcion { get; set; }
        public string originalCalledPartyNumber { get; set; }
        public int duration { get; set; } 
    }
}