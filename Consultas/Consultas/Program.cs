// See https://aka.ms/new-console-template for more information

using Consultas.Models;

var fechaActual = new DateTime(2024, 1, 15);

var posts = new List<Post> {
    new("P1", "AnaCreator", "Video de viaje a París", 15000, 800, 150, fechaActual.AddDays(-2), "Video"),
    new("P2", "AnaCreator", "Foto de comida saludable", 8000, 400, 50, fechaActual.AddDays(-5), "Imagen"),
    new("P3", "TechBlog", "Review del nuevo móvil", 25000, 1200, 300, fechaActual.AddDays(-1), "Video"),
    new("P4", "TechBlog", "5 consejos de programación", 12000, 600, 100, fechaActual.AddDays(-3), "Texto"),
    new("P5", "ViajesMax", "Mi experiencia en Tokio", 30000, 1500, 400, fechaActual.AddDays(-7), "Video"),
    new("P6", "ViajesMax", "Fotos de atardecer", 5000, 250, 30, fechaActual.AddDays(-10), "Imagen"),
    new("P7", "AnaCreator", "Tutorial de maquillaje", 10000, 700, 80, fechaActual.AddDays(-4), "Video"),
    new("P8", "TechBlog", "Unboxing tecnología", 18000, 900, 200, fechaActual.AddDays(-6), "Video"),
    new("P9", "FitnessPro", "Rutina de ejercicios", 22000, 1100, 250, fechaActual.AddDays(-2), "Video"),
    new("P10", "FitnessPro", "Tips de nutrición", 8000, 350, 45, fechaActual.AddDays(-8), "Texto"),
    new("P11", "ViajesMax", "Best beaches 2024", 15000, 800, 120, fechaActual.AddDays(-12), "Imagen"),
    new("P12", "TechBlog", "IA y el futuro", 20000, 950, 180, fechaActual.AddDays(-9), "Texto")
};



// Consultas:
Console.WriteLine("Encuentra los posts que tengan más de 10,000 visualizaciones.");
var postMas = posts
    .Where(p => p.Visualizaciones > 10000)
    .ToDictionary(p => p.Id, p => p.Visualizaciones);

foreach (var p in postMas) {
    Console.WriteLine($"Id: {p.Key}, Visualizaciones: {p.Value}");
}

Console.WriteLine();
Console.WriteLine("Filtra los posts donde el número de Likes sea superior al 5% de las Visualizaciones.");
var postLikes = posts
    .Where(p => p.Likes > p.Visualizaciones * 0.05)
    .ToDictionary(p => p.Id, p => p.Likes);

foreach (var p in postLikes) {
    Console.WriteLine($"Id: {p.Key}, Likes: {p.Value}");
}

Console.WriteLine();
Console.WriteLine("Obtén los posts publicados en los últimos 7 días.");


Console.WriteLine();
Console.WriteLine("Busca el post más compartido de la categoría \"Video\".");
var postCompartido = posts
    .Where(p => p.Categoria == "Video")
    .MaxBy(p => p.Compartidos);
Console.WriteLine(postCompartido);

Console.WriteLine();
Console.WriteLine("Crea una lista de objetos anónimos new { Id, Autor, Ratio } donde el Ratio sea (Likes + Compartidos) / Visualizaciones.");
var listaAnonimos = posts
    .Select(p => new { p.Id, p.Autor, Ratio =((p.Likes + p.Compartidos) / p.Visualizaciones)})
    .ToList();
foreach (var p in listaAnonimos) {
    Console.WriteLine($"Id: {p.Id}, Autor: {p.Autor}, Ratio: {p.Ratio}");
}

Console.WriteLine();
Console.WriteLine("Calcula la suma total de visualizaciones de toda la agencia.");
var sumVisualizaiones = posts
    .Sum(p => p.Visualizaciones);
Console.WriteLine(sumVisualizaiones);

Console.WriteLine();
Console.WriteLine("Obtén la media de Likes para todos los posts de categoría \"Imagen\".");
var mediaLikesImagen = posts
    .Where(p => p.Categoria == "Imagen")
    .Average(p => p.Likes);
Console.WriteLine(mediaLikesImagen);

Console.WriteLine();
Console.WriteLine("Agrupa los posts por Categoria y muestra el total de visualizaciones acumuladas en cada una.");
var categoriaVis = posts
    .GroupBy(p => p.Categoria)
    .ToDictionary(g => g.Key, g => new { Visualizaciones = g.Sum(p => p.Visualizaciones) });
foreach (var p in categoriaVis) {
    Console.WriteLine($"Categoria: {p.Key}, Suma: {p.Value}");
}   
    
Console.WriteLine();
Console.WriteLine("Muestra cuántos posts ha subido cada autor, ordenados de mayor a menor actividad.");
var postAutor = posts
    .GroupBy(p => p.Autor)
    .ToDictionary(p => p.Key, p => new { Actividad = p.Count()})
    .OrderBy(p => p.Value.Actividad);
foreach (var p in postAutor) {
    Console.WriteLine($"Autor: {p.Key}, Actividad total: {p.Value}");
}  

Console.WriteLine();
Console.WriteLine("Obtén los nombres de los 3 autores con más Likes totales en sus publicaciones.");


Console.WriteLine();
Console.WriteLine("Obtén los nombres de los 3 autores con más Likes totales en sus publicaciones.");


Console.WriteLine();
Console.WriteLine("Para cada post, genera una cadena con el formato: \"[CATEGORIA] Autor: Contenido (Recortado a 20 caracteres)...\".");


Console.WriteLine();
Console.WriteLine("Agrupa los posts por el Mes de publicación y calcula la media de visualizaciones por mes.");


Console.WriteLine("Si tuvieras una lista de Autores y cada uno tuviera una List<Post>, usa SelectMany para obtener todos los posts con más de 500 likes.");


Console.WriteLine();
Console.WriteLine("Ordena los posts primero por Likes (descendente) y luego por FechaPublicacion (más reciente primero).");


Console.WriteLine();
Console.WriteLine("Encuentra los 5 posts con menos visualizaciones que no sean de la categoría \"Texto\".");


Console.WriteLine();
Console.WriteLine("Obtén una lista única de todas las categorías que han superado las 1,000 interacciones totales.");


