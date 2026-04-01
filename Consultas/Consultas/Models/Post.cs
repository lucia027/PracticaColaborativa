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
);
