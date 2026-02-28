using System.Text;
using System.Text.RegularExpressions;
using Serilog;
using static System.Console;

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
    EmpezarSimulacion();
}

//Funciones auxiliares
void EmpezarSimulacion() {
    WriteLine("🔥🎄 Empezamos con el incendio(christmas version). 🎄🔥");
    
    
}