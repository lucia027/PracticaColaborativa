using static System.Console;
using System.Text;
using System.Text.RegularExpressions;
using Serilog;

//Configuración del logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

//Configuración console y encoding
Title = "Incendio Forestal";
OutputEncoding = Encoding.UTF8;
Clear();
    
//Constantes y variables locales    


//Programa principal
Main();

//Limpieza de Logs y de salidas
Log.CloseAndFlush();
WriteLine("Pulse cualquier tecla para salir del programa.👋");
ReadKey();

//Función principal
void Main() {
    WriteLine("🕵️ !Bienvenido a la Agencia Wise¡ 🕵️");
    Menu();
}

//Funciones auxiliares
void Menu() {
    Log.Debug("Iniciando el menu");
    WriteLine("------------------------");
    WriteLine("          Menu          ");
    WriteLine("------------------------");
    
    WriteLine("1- Salir del programa");
    WriteLine("2- Crear nueva misión");
    WriteLine("3- Actualizar misión");
    WriteLine("4- Eliminar misión");
    WriteLine("5- Listar misiones");
    WriteLine("6- Listar misiones por nivel de riego(ASC/DES)");
    WriteLine();

    string opcion;
    do {
        Write("Elige una opción del menu valida.");
        WriteLine();
        opcion = ReadLine() ?? "0";

        switch (opcion) {
            case "1":
                WriteLine("Saliendo del programa..👋🏻");
                break;
            case "2":
                CrearMision();
                break;
            case "3":
                ActualizarMision();
                break;
            case "4":
                EliminarMision();
                break;
            case "5":
                ListarMisiones();
                break;
            case "6":
                ListaMisionesRiesgo();
                break; 
            default: 
                WriteLine("Opcion no valida.");
                Log.Debug("Opción del menú no valida.");
                opcion = "0";
                break;
        }
    } while (opcion == "0");
}

void CrearMision() {
    
}

void ActualizarMision() {
    
}
void EliminarMision() {
    
}
void ListarMisiones() {
    
}
void ListaMisionesRiesgo() {
}