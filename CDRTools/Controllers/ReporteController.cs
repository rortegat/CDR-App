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
        /*
        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Tabla.pdf");
            }
        }*/

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
        
    }
}