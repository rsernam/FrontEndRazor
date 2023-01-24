using System.ComponentModel.DataAnnotations;

namespace FrontEndRazor.Models
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        public string? Cliente { get; set; }
        public string? RUCCliente { get; set; }
        public List<Detalle>? Detalles { get; set; }


    }
}

