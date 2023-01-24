using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FrontEndRazor.Data;
using FrontEndRazor.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FrontEndRazor.Pages.Ventas
{
    public class CreateModel : PageModel
    {
        /*
        private readonly FrontEndRazor.Data.FrontEndRazorContext _context;

        public CreateModel(FrontEndRazor.Data.FrontEndRazorContext context)
        {
            _context = context;
        }
        */

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Venta? Venta { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            string Baseurl = "https://localhost:44376/";
            string APIKEYNAME = "secret-api-key";
            var json = JsonConvert.SerializeObject(Venta);
            var data = new StringContent(json, Encoding.UTF8, "application/json");


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(APIKEYNAME, "SOFTEK_API_KEY");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.PostAsync("api/Ventas", data);

            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            /*

              _context.Venta.Add(Venta);
              await _context.SaveChangesAsync();
            */

            return RedirectToPage("./Index");
        }
    }




}
