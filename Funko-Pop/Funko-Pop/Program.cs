using System.Text;
using Funko_Pop.Repositories;
using Funko_Pop.Service;
using Funko_Pop.Validator;
using Serilog;
using static System.Console;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // Permitir mensajes Debug y superiores
    .WriteTo.Console() // Salida a consola
    .CreateLogger(); // Utilizamos Serilog para el logging


// Configuración de consola y Encoding
Title = "";
OutputEncoding = Encoding.UTF8;
Clear();

// Constantes y variables globales (Justificadas)


// Programa principal
Main();

// Limpieza de logs y salida
Log.CloseAndFlush(); // Asegura que todos los logs pendientes se escriban.
WriteLine("\n⌨️ Presiona una tecla para salir...");
ReadKey();

// Programa principal
void Main() {
    var service = new FunkoPopService(FunkoPopRepository.GetInstance(), new FunkoPopValidator());
    
    WriteLine("-------------------------------------------------------");
    WriteLine("   ¡Bienvenido al programa de gestion de FunkoPops!    ");
    WriteLine("-------------------------------------------------------");

    MostrarMenu();
    
}

// Métodos auxiliares
void MostrarMenu() {
    WriteLine("------------------------");
    WriteLine("          Menú:         ");
    WriteLine("------------------------");
    WriteLine("1·  Listar FunkoPops.");
    WriteLine("2·  Buscar FunkoPop.");
    WriteLine("3·  Crear FunkoPop.");
    WriteLine("4·  Actualizar FunkoPop.");
    WriteLine("5·  Eliminar FunkoPop.");
    WriteLine("");
    OpcionMenu();
}

void OpcionMenu() {
    bool isValida;

    do {
        WriteLine("Elige una opcion valida del menú:");
        var opcion = ReadLine() ?? "0".Trim();
        isValida = ValidarOpcionMenu(opcion);
    } while (!isValida);
}

bool ValidarOpcionMenu(string opcion) {
    if (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4" && opcion != "5") {
        return false;
    }
    return true;
}