using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrontEndRazor.Models;

namespace FrontEndRazor.Data
{
    public class FrontEndRazorContext : DbContext
    {
        public FrontEndRazorContext (DbContextOptions<FrontEndRazorContext> options)
            : base(options)
        {
        }

        public DbSet<FrontEndRazor.Models.Venta> Venta { get; set; } = default!;
    }
}
