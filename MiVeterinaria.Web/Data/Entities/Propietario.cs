using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiVeterinaria.Web.Data.Entities
{
    public class Propietario
    {
        public int Id { get; set; }
        [Display(Name = "Documento")]
        [MaxLength(30, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Documento { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [MaxLength(20, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Display(Name = "Teléfono Fijo")]
        public string TelFijo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(20, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Display(Name = "Teléfono Celular")]
        public string TelCelular { get; set; }
        [MaxLength(100, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres.")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        public ICollection<Mascota> Mascotas { get; set; }

        [Display(Name = "Propietario")]
        public string nombreApellido => $"{Nombre} {Apellido}";
        [Display(Name = "Propietario")]
        public string nombreApellidoConDire => $"{Nombre} {Apellido} - {Direccion}";
        
    }
}
