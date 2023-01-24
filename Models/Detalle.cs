
using System.ComponentModel.DataAnnotations;
namespace FrontEndRazor.Models
{
    public class Detalle
    {
        [Key]
        public int IdDetalle { get; set; }
        public string? NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Monto { get; set; }
    }
}
