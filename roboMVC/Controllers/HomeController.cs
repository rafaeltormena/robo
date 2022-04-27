using Microsoft.AspNetCore.Mvc;
using roboMVC.Models;
using System.Diagnostics;

namespace roboMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string urlAPI = "https://localhost:7295/api/";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Braco()
        {
            IEnumerable<BracoModel> bracos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                //HTTP GET
                var responseTask = client.GetAsync("Braco");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BracoModel[]>();
                    readTask.Wait();

                    bracos = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }


            return View("BracoView", bracos);
        }

        public IActionResult EditCotovelo(string Lado, string NovoCotovelo)
        {
            // TODO PUT
            IEnumerable<BracoModel> bracos = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                //string command = "/Braco/Cotovelo?id=" + Lado + "&NovoCotovelo=" + NovoCotovelo;
                string command = "id=" + Lado + "&NovoCotovelo=" + NovoCotovelo;
                //HTTP PUT
                /*
                var responseTask = client.PutAsync("Braco/Cotovelo", command);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BracoModel[]>();
                    readTask.Wait();

                    bracos = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                */
            }

            return View("Index");
            //return View("BracoView");
        }

        public IActionResult EditPulso(string NovoPulso)
        {
            // TODO PUT

            return View("Index");
        }


        public IActionResult Cabeca()
        {
            IEnumerable<CabecaModel> cabeca = null;
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);
                //HTTP GET
                var responseTask = client.GetAsync("Cabeca");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CabecaModel[]>();
                    readTask.Wait();

                    cabeca = readTask.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }


            return View("CabecaView", cabeca);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}