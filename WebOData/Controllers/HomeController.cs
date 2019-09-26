using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple.OData.Client;
using WebOData.Models;

namespace WebOData.Controllers
{
    public class HomeController : Controller
    {
        readonly NetworkCredential credentials;
        readonly ODataClientSettings settings;
        ODataClient client;

        public HomeController()
        {
            credentials = new NetworkCredential("SES_DT_02", "everisCentros04");
            settings = new ODataClientSettings(new Uri("http://213.130.35.45:8000/sap/opu/odata/sap/zpruebaodata_srv/TextosGeneralesSet"), credentials);
            
            client = new ODataClient(settings);
        }
        
        
        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            IEnumerable<TextosGenerales> lista = null;
            try
            {
                lista = await client.For<TextosGenerales>().FindEntriesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return View(lista);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<IEnumerable<TextosGenerales>> GetTextosFromOData()
        {
            var texts = await client.For<TextosGenerales>().FindEntriesAsync();
            return texts;
        }
    }
}
