namespace Funko_Pop.Models;

public class FunkoPop {
    public int Id { get; set; } = 0;
    public required string Nombre { get; set; }
    public required decimal Precio { get; set; }
    public required Tipo Categoria { get; set; }
    

    public enum Tipo {
        Superheroe, Anime, Disney
    }
}