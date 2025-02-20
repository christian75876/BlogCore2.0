using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BlogCore_Models;

public class ApplicationUser : IdentityUser
{
    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "La direccion es requerido")]
    public string Direccion { get; set; }
    
    [Required(ErrorMessage = "La ciudad es obligatoria")]
    public string Ciudad { get; set; }
    
    [Required(ErrorMessage = "El país es obligatorio")]
    public string Pais { get; set; }
}