﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Hosting;
using CDRTools.DBServices;
using CDRTools.ReportsServices;

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

        public FileResult CreateReport()
        {
            DateTime dTime = DateTime.Now;  

            MemoryStream workStream = new MemoryStream();

            byte[] result = LlamadasReportService.CreatePDF();

            workStream.Write(result, 0, result.Length);
            workStream.Position = 0;

            var strPDFFileName = string.Format("SamplePDF" + "-" + dTime.ToString("yyyyMMdd") + ".pdf");
            var exportFolder = HostingEnvironment.MapPath("~/Downloads/" + strPDFFileName);

            return File(workStream, "application/pdf", strPDFFileName);
        }
    }
}