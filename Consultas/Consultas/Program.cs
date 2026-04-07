// See https://aka.ms/new-console-template for more information

using Consultas.Models;

var fechaActual =  DateTime.Now;

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
var post7Dias = posts
    .Where(p => p.FechaPublicacion >= DateTime.Now.AddDays(-7));
foreach (var p in post7Dias) {
    Console.WriteLine($"Id: {p.Id}, Fecha de publicaciones: {p.FechaPublicacion}");
}

Console.WriteLine();
Console.WriteLine("Busca el post más compartido de la categoría \"Video\".");
var postCompartido = posts
    .Where(p => p.Categoria == "Video")
    .MaxBy(p => p.Compartidos);
Console.WriteLine(postCompartido);

Console.WriteLine();
Console.WriteLine("Crea una lista de objetos anónimos new { Id, Autor, Ratio } donde el Ratio sea (Likes + Compartidos) / Visualizaciones.");
var listaAnonimos = posts
    .Select(p => new { p.Id, p.Autor, Ratio =(double)(p.Likes + p.Compartidos) / p.Visualizaciones})
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
    .OrderByDescending(p => p.Value.Actividad);
foreach (var p in postAutor) {
    Console.WriteLine($"Autor: {p.Key}, Actividad total: {p.Value}");
}  

Console.WriteLine();
Console.WriteLine("Obtén los nombres de los 3 autores con más Likes totales en sus publicaciones.");
var topAutores = posts
    .GroupBy(p => p.Autor)
    .Select(g => new { NombreAutor = g.Key, TotalLikes = g.Sum(p => p.Likes) })
    .OrderByDescending(a => a.TotalLikes)
    .Take(3);
foreach (var p in topAutores) {
    Console.WriteLine($"Autor: {p.NombreAutor}, Total de Likes: {p.TotalLikes}");
}  

Console.WriteLine();
Console.WriteLine("Para cada post, genera una cadena con el formato: \"[CATEGORIA] Autor: Contenido (Recortado a 20 caracteres)...\".");
var postRecortado = posts
    .Select(p => new { Cadena = $"[{p.Categoria}] Autor: {p.Autor}  Contenido: {string.Concat(p.Contenido.Take(20))}" });
foreach (var p in postRecortado) { 
    Console.WriteLine(p.Cadena);
}  

Console.WriteLine();
Console.WriteLine("Agrupa los posts por el Mes de publicación y calcula la media de visualizaciones por mes.");
var postMes = posts
    .GroupBy(p => p.FechaPublicacion.Month)
    .Select(g => new { Mes = g.Key, VisMedia = g.Average(p => p.Visualizaciones) });
foreach (var p in postMes) {
    Console.WriteLine($"Mes: {p.Mes}, Media de visualizaciones: {p.VisMedia}");
}

Console.WriteLine();
Console.WriteLine("Si tuvieras una lista de Autores y cada uno tuviera una List<Post>, usa SelectMany para obtener todos los posts con más de 500 likes.");
var listaAutores = posts
    .GroupBy(p => p.Autor)
    .ToDictionary(g => g.Key, _ => new List<Post>());
foreach (var a in listaAutores) {
    foreach (var p in posts) {
        if (a.Key == p.Autor) {
            a.Value.Add(p);
        }
    }
}

var selectaMAny = listaAutores
    .SelectMany(p => p.Value)
    .Where(p => p.Likes > 500);
foreach (var p in selectaMAny) {
    Console.WriteLine($"Likes: {p.Likes}");
}

Console.WriteLine();
Console.WriteLine("Ordena los posts primero por Likes (descendente) y luego por FechaPublicacion (más reciente primero).");
var postOrden = posts
    .OrderByDescending(p => p.Likes)
    .ThenBy(p => p.FechaPublicacion);
foreach (var p in postOrden) {
    Console.WriteLine($"Id: {p.Id}, Likes: {p.Likes}, Fecha de publicacion: {p.FechaPublicacion}.");
}

Console.WriteLine();
Console.WriteLine("Encuentra los 5 posts con menos visualizaciones que no sean de la categoría \"Texto\".");
var postX = posts
    . Where(p => p.Categoria != "Texto")
    .OrderBy(p => p.Visualizaciones)
    .Take(5);
foreach (var p in postX) {
    Console.WriteLine($"Categoria: {p.Categoria}, Visualizaciones: {p.Visualizaciones}.");
}

Console.WriteLine();
Console.WriteLine("Obtén una lista única de todas las categorías que han superado las 1,000 interacciones(likes + compartidos ) totales.");
var postY = posts
    .GroupBy(p => p.Categoria)
    .Select(g => new { Categoria = g.Key, Compartidos = g.Sum(p => p.Likes) + g.Sum(p => p.Compartidos) })
    .Where(p => p.Compartidos > 1000)
    .ToList();
foreach (var p in postY) {
    Console.WriteLine($"Categoria: {p.Categoria}, Compartidos: {p.Compartidos}.");
}