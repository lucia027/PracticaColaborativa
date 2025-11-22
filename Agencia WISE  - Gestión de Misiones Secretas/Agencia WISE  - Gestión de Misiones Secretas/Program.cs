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
    Mision[] misiones = CrearDatosExistentes();
    Menu(misiones);
}

//Funciones auxiliares
Mision[] CrearDatosExistentes() {
    Log.Debug("Creación de la base de datos de misiones existentes");
    
    var mision1 = new Mision {Id = 01, Nombre = "Strix", NivelRiesgo = 5, AgenteAsignado = Agentes.Loid};
    var mision2 = new Mision {Id = 02, Nombre = "Infiltración en la fiesta de Donovan Desmond", NivelRiesgo = 5, AgenteAsignado = Agentes.Loid};
    var mision3 = new Mision {Id = 03, Nombre = "Rescate de perro Bond y de Loid Forger durante el atentado", NivelRiesgo = 3, AgenteAsignado = Agentes.Anya};
    var mision4 = new Mision {Id = 04, Nombre = "Neutralización de banda criminal Garden", NivelRiesgo = 4, AgenteAsignado = Agentes.Yor};
    var mision5 = new Mision {Id = 05, Nombre = "Operación Stella – Conseguir estrellas en el Colegio Eden", NivelRiesgo = 1, AgenteAsignado = Agentes.Anya};

    Mision[] misiones = {mision1, mision2, mision3, mision4, mision5};
    return misiones;
}

void Menu(Mision[] misiones) {   
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
                CrearMision(misiones);
                break;
            case "3":
                ActualizarMision(misiones);
                break;
            case "4":
                EliminarMision(misiones);
                break;
            case "5":
                ListarMisiones(misiones);
                break;
            case "6":
                ListarMisionesRiesgo(misiones);
                break; 
            default: 
                WriteLine("Opcion no valida.");
                Log.Debug("Opción del menú no valida.");
                opcion = "0";
                break;
        }
    } while (opcion == "0");
}

int ValidarId(string  id) {
    
}

string ValidarNombre(string input, string nombreAntiguo) {
    
}

int ValidarNivelRiesgo(string input, int nivelRiesgo) {
    
}

Agentes ValidarAgente(string input, Agentes agente) {
    
}

void CrearMision(Mision[]  misiones) {
    
}

void ActualizarMision(Mision[]  misiones) {
    Log.Debug("Actualizando el contenido de la mision");
    
    WriteLine("--------------------------");
    WriteLine("         Misiones:        ");
    ListarMisiones(misiones);    
    
    WriteLine("Introduce el Id de la mision que actualizar: (Utiliza el formato correcto)");
    var inputId = ReadLine() ??  "0";
    int id =  ValidarId(inputId);

    for (int i = 0; i < misiones.Length; i++) {
        if (misiones[i].Id == id) {
            WriteLine($"Id: {misiones[i].Id}");
            
            Log.Debug($"Cambiando nombre: {misiones[i].Nombre}");
            WriteLine($"Nombre antiguo: {misiones[i].Nombre} (para no cambiarlo pulse intro)");
            var inputNombre = ReadLine() ??  ""; 
            string nombreNuevo = ValidarNombre(inputNombre, misiones[i].Nombre);
            misiones[i].Nombre = nombreNuevo;
            
            Log.Debug($"Cambiando nivel de riesgo: {misiones[i].NivelRiesgo}");
            WriteLine($"Nivel de riesgo antiguo: {misiones[i].NivelRiesgo} (para no cambiarlo pulse intro)");
            var inputNivelRiesgo = ReadLine() ??  "";
            int nivelRiesgoNuevo = ValidarNivelRiesgo(inputNivelRiesgo, misiones[i].NivelRiesgo);
            misiones[i].NivelRiesgo = nivelRiesgoNuevo;
            
            Log.Debug($"Cambiando asignado: {misiones[i].AgenteAsignado}");
            WriteLine($"Agente asignado antiguo: {misiones[i].AgenteAsignado} (para no cambiarlo pulse intro)");
            var inputAgente = ReadLine() ??  "";
            Agentes agenteNuevo = ValidarAgente(inputAgente, misiones[i].AgenteAsignado);
            misiones[i].AgenteAsignado = agenteNuevo;
        }
    }
}

void EliminarMision(Mision[]  misiones) {
    
}

void ListarMisiones(Mision[]  misiones) {
    Log.Debug("Listando misiones..");
    
    WriteLine("--------------------------");
    WriteLine("Id, Nombre, Riesgo, Agente");
    WriteLine("--------------------------");

    for (int i = 0; i < misiones.Length; i++) {
        var mision = misiones[i];
        WriteLine($"ID: {mision.Id}, Nombre: {mision.Nombre}, Riesgo{mision.NivelRiesgo},  Agente: {mision.AgenteAsignado}");
    };
}

void ListarMisionesRiesgo(Mision[]  misiones) {
    
}