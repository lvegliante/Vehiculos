using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vehiculos.Common.Enums;

namespace Vehiculos.API.Data.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El Campo {0} No Puede Tener Mas De {1} Caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El Campo {0} No Puede Tener Mas De {1} Caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        public string LastName { get; set; }

        [Display(Name = "Tipo de Documento")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        public DocumentType DocumentType { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El Campo {0} No Puede Tener Mas De {1} Caracteres.")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio")]
        public string Document { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(20, ErrorMessage = "El Campo {0} No Puede Tener Mas De {1} Caracteres.")]
        public string Address { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:5001/images/noimage.png"
            : $"https://vehiculoslucho.blob.core.windows.net/users/{ImageId}";
                

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Vehicle> Vehicles { get; set; }
        //  public ICollection<History> Histories { get; set; }

        [Display(Name = "# Vehículos")]
        public int VehiclesCount => Vehicles == null ? 0 : Vehicles.Count;

    }
}
