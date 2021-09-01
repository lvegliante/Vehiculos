using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehiculos.API.Data.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }
        [Display(Name = "Tipo de Documento")]
        [MaxLength(50, ErrorMessage = "El Campo {0} No Puede Tener Mas De {1} Caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        public string Description { get; set; }
    }
}
