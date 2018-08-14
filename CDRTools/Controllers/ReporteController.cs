using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Hosting;
using CDRTools.DBServices;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.text.html;
using System.Text;
using iTextSharp.tool.xml.parser;
using System.Data;
using System.Collections.ObjectModel;

namespace CDRTools.Models
{
    public class ReporteController : Controller
    {


        // GET: Reporte
        public ActionResult Index()
        {
                return View();         
        }

       public ActionResult Container()
        {
            return View("_Reports.Container");
        }


        public ActionResult GetReporte(int id)
        {
            int pageToLoad = id;
            
            if (pageToLoad == 0)
            {
                pageToLoad = 1;
            }

            LlamadasDBService llamadasService = new LlamadasDBService();

            var data = llamadasService.Llamadas_Recupera(pageToLoad);
            
            var callDetailsCount = data.Item1;
            var callDetails = data.Item2;

            var pager = new Pager(callDetailsCount, pageToLoad);

            var viewModel = new IndexViewModel
            {
                Llamadas = callDetails, // callDetails.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            List<string> cssFiles = new List<string>();
            cssFiles.Add(@"/Content/bootstrap.css");

            var output = new MemoryStream();

            var input = new MemoryStream(Encoding.UTF8.GetBytes(GridHtml));

            var document = new Document();
            var writer = PdfWriter.GetInstance(document, output);
            writer.CloseStream = false;

            document.Open();
            var htmlContext = new HtmlPipelineContext(null);
            htmlContext.SetTagFactory(iTextSharp.tool.xml.html.Tags.GetHtmlTagProcessorFactory());

            ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
            cssFiles.ForEach(i => cssResolver.AddCssFile(System.Web.HttpContext.Current.Server.MapPath(i), true));

            var pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
            var worker = new XMLWorker(pipeline, true);
            var p = new XMLParser(worker);
            p.Parse(input);
            document.Close();
            output.Position = 0;

            return File(output.ToArray(), "application/pdf", "Reporte.pdf");
            
        }



        

        public ActionResult _ShowData(string ini, string fin, string ex)
        {

            DBServices.FilterDBService dblayer = new DBServices.FilterDBService();

            string i = ini;
            string f = fin;
            string e = ex;
            DataSet ds = dblayer.Show_data(i, f, e);
            ViewBag.emp = ds.Tables[0];

            ObservableCollection<Get_Llamadas_Extensiones> modeldata = new ObservableCollection<Get_Llamadas_Extensiones>();

            foreach (System.Data.DataRow dr in ViewBag.emp.Rows)
            {
                modeldata.Add(new Get_Llamadas_Extensiones
                {

                    globalCallID_callManagerId = Convert.ToInt32(dr["globalCallID_callManagerId"]),
                    globalCallID_callId = Convert.ToInt32(dr["globalCallID_callId"]),
                    dateTimeOrigination = Convert.ToDateTime(dr["dateTimeOrigination"]),
                    callingPartyNumber = dr["callingPartyNumber"].ToString(),
                    Extension_Descripcion = dr["Extension_Descripcion"].ToString(),
                    originalCalledPartyNumber = dr["originalCalledPartyNumber"].ToString(),
                    duration = Convert.ToInt32(dr["duration"])
                });
            }
            return View(modeldata);
        }


        public ActionResult _SelectReport()
        {
            ObservableCollection<Filtro> inventoryList = new ObservableCollection<Filtro>();
            inventoryList.Add(new Filtro { NameReport = "Reporte 1", DescriptionReport = "Computer", ReportDefinicion = "All type of computers", Actions = "800" });
            inventoryList.Add(new Filtro { NameReport = "Reporte 2", DescriptionReport = "Laptop", ReportDefinicion = "All models of Laptops", Actions = "500" });
            inventoryList.Add(new Filtro { NameReport = "Reporte 3", DescriptionReport = "Camera", ReportDefinicion = "Hd  cameras", Actions = "300" });
            inventoryList.Add(new Filtro { NameReport = "Reporte 4", DescriptionReport = "Mobile", ReportDefinicion = "All Smartphones", Actions = "450" });
            inventoryList.Add(new Filtro { NameReport = "Reporte 5", DescriptionReport = "Notepad", ReportDefinicion = "All branded of notepads", Actions = "670" });
            inventoryList.Add(new Filtro { NameReport = "Reporte 6", DescriptionReport = "Harddisk", ReportDefinicion = "All type of Harddisk", Actions = "1200" });
            inventoryList.Add(new Filtro { NameReport = "Reporte 7", DescriptionReport = "PenDrive", ReportDefinicion = "All type of Pendrive", Actions = "370" });
            return View(inventoryList);
        }




    }
}