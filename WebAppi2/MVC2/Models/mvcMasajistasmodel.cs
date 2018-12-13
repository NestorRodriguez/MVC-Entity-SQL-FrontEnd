using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC2.Models
{
    public class mvcMasajistasmodel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo es necesario")]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public string Titulacion { get; set; }
        public int añosExperiencia { get; set; }
    }
}