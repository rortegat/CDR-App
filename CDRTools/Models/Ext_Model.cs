using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDRTools.Models
{
    public class Ext_Model
    {
        CDRModel cdrdb = new CDRModel();

        public List<Extension> GetExtensiones()
        {
            return cdrdb.FN_Extensiones_Recupera().ToList();
        }
    }

    public class Filtro
    {
        public string NameReport { get; set; }
        public string DescriptionReport { get; set; }
        public string ReportDefinicion { get; set; }
        public string Actions { get; set; }
    }
}