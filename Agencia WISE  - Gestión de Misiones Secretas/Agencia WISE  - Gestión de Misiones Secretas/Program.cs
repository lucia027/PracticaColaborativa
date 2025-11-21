using static System.Console;
using System.Text;
using Serilog;
using Agencia_WISE____Gestión_de_Misiones_Secretas;


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
    CrearDatosExistentes();
    Menu();
}

//Funciones auxiliares
void CrearDatosExistentes() {
    Log.Debug("Creación de la base de datos de misiones existentes");
    
    var mision1 = new Mision {Id = 01, Nombre = "Strix", NivelRiesgo = 5, AgenteAsignado = Agentes.Loid};
    var mision2 = new Mision {Id = 02, Nombre = "Infiltración en la fiesta de Donovan Desmond", NivelRiesgo = 5, AgenteAsignado = Agentes.Loid};
    var mision3 = new Mision {Id = 03, Nombre = "Rescate de perro Bond y de Loid Forger durante el atentado", NivelRiesgo = 3, AgenteAsignado = Agentes.Anya};
    var mision4 = new Mision {Id = 04, Nombre = "Neutralización de banda criminal Garden", NivelRiesgo = 4, AgenteAsignado = Agentes.Yor};
    var mision5 = new Mision {Id = 05, Nombre = "Operación Stella – Conseguir estrellas en el Colegio Eden", NivelRiesgo = 1, AgenteAsignado = Agentes.Anya};
    
    
}

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