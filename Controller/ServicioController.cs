
using FrontEndRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace FrontEndRazor.Controllers
{
    public class ServicioController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Venta> listaVentas = new List<Venta>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44324/api/Ventas"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listaVentas = JsonConvert.DeserializeObject<List<Venta>>(apiResponse);
                }
            }
            return View(listaVentas);
        }


        [HttpPost]
        public async Task<IActionResult> AgregarVenta(Venta venta)
        {
            Venta ventaRecibida = new Venta();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(venta), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44324/api/Ventas", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ventaRecibida = JsonConvert.DeserializeObject<Venta>(apiResponse);
                }
            }
            return View(ventaRecibida);
        }

    }
}