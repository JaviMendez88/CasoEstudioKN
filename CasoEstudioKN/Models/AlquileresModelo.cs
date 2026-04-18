using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CasoEstudioKN.Models
{
    public class AlquileresModelo
    {
        [Required]
        public long IdCasa { get; set; }

        public decimal PrecioCasa { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [StringLength(30)]
        public string UsuarioAlquiler { get; set; }

    }
}