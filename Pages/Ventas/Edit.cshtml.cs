using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrontEndRazor.Data;
using FrontEndRazor.Models;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace FrontEndRazor.Pages.Ventas
{
    public class EditModel : PageModel
    {
        /*
        private readonly FrontEndRazor.Data.FrontEndRazorContext _context;

        public EditModel(FrontEndRazor.Data.FrontEndRazorContext context)
        {
            _context = context;
        }
        */

        [BindProperty]
        public Venta Venta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            /*
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta =  await _context.Venta.FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }
            Venta = venta;*/
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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
            

            return RedirectToPage("./Index");
        }

        private bool VentaExists(int id)
        {
            //return _context.Venta.Any(e => e.IdVenta == id);
            return true;
        }
    }
}
