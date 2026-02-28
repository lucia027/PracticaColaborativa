using System.Text;
using Funko_Pop.Models;
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
    service.DatosBaseFunkoPop();
    
    WriteLine("-------------------------------------------------------");
    WriteLine("   ¡Bienvenido al programa de gestion de FunkoPops!    ");
    WriteLine("-------------------------------------------------------");

    MostrarMenu(service);
    
}

// Métodos auxiliares
void MostrarMenu(FunkoPopService service) {
    WriteLine("------------------------");
    WriteLine("          Menú:         ");
    WriteLine("------------------------");
    WriteLine("1·  Listar FunkoPops.");
    WriteLine("2·  Buscar FunkoPop.");
    WriteLine("3·  Crear FunkoPop.");
    WriteLine("4·  Actualizar FunkoPop.");
    WriteLine("5·  Eliminar FunkoPop.");
    WriteLine("6·  Salir.");
    WriteLine("");
    OpcionMenu(service);
}
    
void OpcionMenu(FunkoPopService service) {
    bool isValida;
    string opcion;

    do {
        WriteLine("Elige una opcion valida del menú:");
        opcion = ReadLine() ?? "0".Trim();
        isValida = ValidarOpcionMenu(opcion);
    } while (!isValida);

    switch (opcion) {
        case "1": 
            ListarFunkoPop(service);
            MostrarMenu(service);
            break;
        case "2": 
            BuscarFunkoPop(service);
            MostrarMenu(service);
            break;
        case "3": 
            CrearFunkoPop(service);
            MostrarMenu(service);
            break;
        case "4": 
            ActualizarFunkoPop(service);
            MostrarMenu(service);
            break;
        case "5": 
            ELiminarFunkoPop(service);
            MostrarMenu(service);
            break;
        case "6": 
            WriteLine("Adios👋🏻");
            break;
    }
    WriteLine();
}

bool ValidarOpcionMenu(string opcion) {
    if (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4" && opcion != "5" && opcion != "6") {
        WriteLine("Formato incorrecto, intentalo de nuevo.");
        return false;
    }
    return true;
}

void ListarFunkoPop(FunkoPopService service) {
    bool isValida;
    char letra;
    FunkoPop[] funkos = [];

    do {
        WriteLine("¿Quieres listarlos de forma ascendente o descencente?. Pulsa \"a\" para ascendente y \"d\" para descendente.");
        letra = ReadKey().KeyChar;
        WriteLine();
        isValida = ValidarOpcionOrden(letra);
    } while (!isValida);
    
    WriteLine("------------------------");
    WriteLine("    Listado FunkoPops   ");
    WriteLine("------------------------");

    switch (letra) {
        case 'a':
            funkos = service.GetAll("ASC");
            break;
        case 'd':
            funkos = service.GetAll("DSC");
            break;
    }
    ImprimirFunkoPops(funkos);
}

void BuscarFunkoPop(FunkoPopService service) {
    WriteLine("BuscarFunkoPop");
}

void CrearFunkoPop(FunkoPopService service) {
    WriteLine("CrearFunkoPop");
}

void ActualizarFunkoPop(FunkoPopService service) {
    WriteLine("ActualizarFunkoPop");
}

void ELiminarFunkoPop(FunkoPopService service) {
    try {
        WriteLine("Id del FunkoPop a eliminar:");
        var id = int.Parse(ReadLine()?.Trim() ?? "");
        service.DeleteFunkoPop(id);
        WriteLine();
    } catch (KeyNotFoundException e) {
        WriteLine(e.Message);
    }
}

bool ValidarOpcionOrden(char letra) {
    if (letra != 'a' && letra != 'd') {
        WriteLine("Formato incorrecto, intentalo de nuevo.");
        return false;
    }
    return true;
}

void ImprimirFunkoPops(FunkoPop[] funkos) {
    foreach (var funkoPop in funkos) {
        WriteLine($"FunkoPop= Id:{funkoPop.Id}, Nombre:{funkoPop.Nombre}, Precio:{funkoPop.Precio}, Categoria:{funkoPop.Categoria.ToString()}");
    }
}