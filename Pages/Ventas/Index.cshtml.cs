using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FrontEndRazor.Data;
using FrontEndRazor.Models;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
//using RestSharp.Portable;

namespace FrontEndRazor.Pages.Ventas
{
    public class IndexModel : PageModel
    {
        /*
        private readonly FrontEndRazor.Data.FrontEndRazorContext _context;

        public IndexModel(FrontEndRazor.Data.FrontEndRazorContext context)
        {
            _context = context;
        }
        */

        public IList<Venta> Venta { get;set; } = default!;

        string Baseurl = "https://localhost:44376/";


        private const string APIKEYNAME = "secret-api-key";

        public async Task OnGetAsync()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(APIKEYNAME, "SOFTEK_API_KEY");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Ventas");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    Venta = JsonConvert.DeserializeObject<List<Venta>>(EmpResponse);
                    Console.WriteLine(Venta);
                }
            }

        }
    }
}
