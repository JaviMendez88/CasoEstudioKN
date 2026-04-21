using System;
using System.ComponentModel.DataAnnotations;

namespace CasoEstudio2.Models
{
    public class CasasModel
    {
        [Required(ErrorMessage = "Debe seleccionar una casa")]
        public long? IdCasa { get; set; }

        public string DescripcionCasa { get; set; }

        public decimal PrecioCasa { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [StringLength(30)]
        public string UsuarioAlquiler { get; set; }

        public DateTime? FechaAlquiler { get; set; }

        public string Estado
        {
            get
            {
                return string.IsNullOrEmpty(UsuarioAlquiler)
                    ? "Disponible"
                    : "Reservada";
            }
        }
    }
}