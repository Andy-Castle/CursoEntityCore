using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string NombreUsuario { get; set; }

        [EmailAddress(ErrorMessage = "Porfavor ingrese un mail Valido")]
        public string Email { get; set; }

        [Display(Name = "Dirección del usuario")]
        public string Direccion { get; set; }

        public int Edad { get; set; }

        public int? DetalleUsuario_Id { get; set; }

        public DetalleUsuario DetalleUsuario { get; set; }
    }
}
