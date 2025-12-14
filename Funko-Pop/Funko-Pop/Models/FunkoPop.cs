namespace Funko_Pop.Models;

public record FunkoPop {
    public int Id { get; init; }
    public required string Nombre { get; set; }
    public required decimal Precio { get; set; }
    public required Tipo Categoria { get; set; }
    

    public enum Tipo {
        Superheroe, Anime, Disney
    }
}