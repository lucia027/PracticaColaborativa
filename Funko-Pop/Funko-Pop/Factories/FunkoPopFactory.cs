using Funko_Pop.Config;
using Funko_Pop.Models;
using Serilog;

namespace Funko_Pop.Factories;

/// <summary>
///  Clase que crea los datos base de la aplicación.
/// </summary>
public static class FunkoPopFactory {
    private static readonly ILogger Log = Serilog.Log.ForContext(typeof(FunkoPopFactory));
    
    /// <summary>
    ///  Función que genera datos por defecto.
    /// </summary>
    /// <returns>Array de los datos.</returns>
    public static FunkoPop[] DatosBase() {
        Log.Information("Creando datos base.");
        
        var datos = new FunkoPop[Configuracion.TamVector];

        var funko1 = new FunkoPop { Id = 1, Nombre = "Spider-Man", Precio = 19.99m, Categoria = FunkoPop.Tipo.Superheroe };
        var funko2 = new FunkoPop { Id = 2, Nombre = "Naruto Uzumaki", Precio = 24.50m, Categoria = FunkoPop.Tipo.Anime };
        var funko3 = new FunkoPop { Id = 3, Nombre = "Mickey Mouse", Precio = 15.75m, Categoria = FunkoPop.Tipo.Disney };
        var funko4 = new FunkoPop { Id = 4, Nombre = "Batman", Precio = 21.00m, Categoria = FunkoPop.Tipo.Superheroe };
        var funko5 = new FunkoPop { Id = 5, Nombre = "Goku Super Saiyan", Precio = 29.99m, Categoria = FunkoPop.Tipo.Anime };

        datos[1] = funko1;
        datos[2] = funko2;
        datos[3] = funko3;
        datos[4] = funko4;
        datos[5] = funko5;

        return datos;
    }
}