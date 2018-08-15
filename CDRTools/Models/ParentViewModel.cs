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
        public Extension ext { get; set; }

        public IEnumerable<SelectListItem> ListaExtensiones { get; set; }

        public ParentViewModel(IEnumerable<Extension> items)
        {
            ListaExtensiones = items
                .Select(i => new SelectListItem()
                {
                    Text = i.Id_Extension,
                    Value = i.Id_Extension
                })
                .ToList();
        }
    }
}