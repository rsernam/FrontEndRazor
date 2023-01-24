using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FrontEndRazor.Data;
using FrontEndRazor.Models;

namespace FrontEndRazor.Pages.Ventas
{
    public class DeleteModel : PageModel
    {
        private readonly FrontEndRazor.Data.FrontEndRazorContext _context;

        public DeleteModel(FrontEndRazor.Data.FrontEndRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Venta Venta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            /*
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var venta = await _context.Venta.FirstOrDefaultAsync(m => m.IdVenta == id);

            if (venta == null)
            {
                return NotFound();
            }
            else 
            {
                Venta = venta;
            }
            */
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            /*
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }
            var venta = await _context.Venta.FindAsync(id);

            if (venta != null)
            {
                Venta = venta;
                _context.Venta.Remove(Venta);
                await _context.SaveChangesAsync();
            }
            */

            return RedirectToPage("./Index");
        }
    }
}
