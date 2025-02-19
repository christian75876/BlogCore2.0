using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BlogCore_Models;

public class ApplicationUser : IdentityUser
{
    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "El correo es requerido")]
    public string Correo { get; set; }
    
    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string Contrasena { get; set; }
}