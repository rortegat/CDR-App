using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDRTools.Models
{
    public class ParentViewModel
    {
        
        public Autorizacion aut { get; set; }
        public IEnumerable<Extension> enumExt { get; set; }
    }
}