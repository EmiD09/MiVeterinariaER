using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiVeterinaria.Web.Data.Entities
{
    public class Mascota
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Imagen")]
        public string ImagenUrl { get; set; }
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        public string Raza { get; set; }
        [Display(Name = "Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Nacimiento { get; set; }
        public string comentario { get; set; }
        public TipoMascota TipoMascota { get; set; }
        public Propietario Propietario { get; set; }
        public ICollection<Historia> Historias { get; set; }
        public ICollection<Agenda> Agendas { get; set; }

        public string ImagenFullPath => string.IsNullOrEmpty(ImagenUrl)
            ? null
            : $"https://TDB.azurewebsites.net{ImagenUrl.Substring(1)}";
        [Display(Name = "Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime NacimientoLocal => Nacimiento.ToLocalTime();
        


    }
}
