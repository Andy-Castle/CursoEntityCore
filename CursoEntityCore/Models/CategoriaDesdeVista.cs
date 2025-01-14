namespace CursoEntityCore.Models
{
    public class CategoriaDesdeVista
    {
        public int Categoria_Id { get; set; }

        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
