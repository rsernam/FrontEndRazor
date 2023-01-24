using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FrontEndRazor.Data;
using FrontEndRazor.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FrontEndRazor.Pages.Ventas
{
    public class DetailsModel : PageModel
    {
        /*
        private readonly FrontEndRazor.Data.FrontEndRazorContext _context;

        public DetailsModel(FrontEndRazor.Data.FrontEndRazorContext context)
        {
            _context = context;
        }
        */

        public Venta Venta { get; set; }
        string Baseurl = "https://localhost:44376/";

        private const string APIKEYNAME = "secret-api-key";

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(APIKEYNAME, "SOFTEK_API_KEY");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Ventas/"+ id);
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    Venta = JsonConvert.DeserializeObject<Venta>(EmpResponse);
                    Console.WriteLine(Venta);
                }
            }
            return null;


        }
    }
}
