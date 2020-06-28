using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiVeterinaria.Web.Data.Entities
{
    public class Historia
    {
        public int Id { get; set; }
        [Display(Name = "Descripción")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Descripcion { get; set; }
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd HH:mm}",ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Display(Name ="Comentarios")]
        public string Comentarios { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public Mascota Mascota { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaLocal => Fecha.ToLocalTime();
    }
}
