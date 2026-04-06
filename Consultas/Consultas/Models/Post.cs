namespace Consultas.Models;

public record Post(
    string Id,
    string Autor,
    string Contenido,
    int Visualizaciones,
    int Likes,
    int Compartidos,
    DateTime FechaPublicacion,
    string Categoria // "Video", "Imagen", "Texto"
) {
    public override string ToString() {
        return $"Id = {Id}, autor = {Autor}, contenido = {Contenido}, visualizaciones = {Visualizaciones}, likes = {Likes}, compartidos = {Compartidos}, fecha publicacion = {FechaPublicacion}, categoria 0 {Categoria}";
    }
};
