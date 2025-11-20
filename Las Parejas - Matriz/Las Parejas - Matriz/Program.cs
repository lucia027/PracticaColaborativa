using System.Text;
using System.Text.RegularExpressions;
using Serilog;
using static System.Console;

//Configuración del logger estático
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

//Configuracion consola y encoding
Console.Title = "Juego de Parejas - Matriz";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

//Constantes y variable globales
const int Size = 5; //¡Cuidado el numero tiene que ser par!
Random Random = Random.Shared;

//Programa principal
Main();

//Limpieza de Logs y de salidas
Log.CloseAndFlush();
WriteLine("Pulse cualquier tecla para salir del programa.👋");
ReadKey();

//Función principal
void Main() {
    EmpezarJuego();
}    

//Funciones auxiliares
void EmpezarJuego() {
    bool isAdivinada = false;
    int[,] tablero = Generartablero();
    
    WriteLine("👋 Bienvenido al juego de los pares. 👋");
    ImprimirTablero(tablero, isAdivinada);

    string tirada1 = PedirTirada();
    string tirada2 = PedirTirada();
    bool isTiradaParejas = ComprobarTirada(tirada1, tirada2, tablero);

    if (isTiradaParejas) {
        WriteLine("¡Enhorabuena, has hecho una pareja!");
    }
}

string PedirTirada() {
    var regex = @"^\d\:\d$";
    string input;
    bool isApta = false;
    bool inRango = false;
    
    do {
        WriteLine("Introduce la tirada que vas a hacer, con el formato 2:2.");
        input = ReadLine()!.Trim();

        string[] vectorTexto = input.Split(":");
        int[] vectorEntero = [int.Parse(vectorTexto[0]), int.Parse(vectorTexto[1])];
        
        if (vectorEntero[0] <= Size || vectorEntero[1] <= Size) {
            inRango = true;
        }
        
        if (Regex.IsMatch(input, regex) && inRango) {
            isApta = true;
        } else {
            WriteLine("Formato incorrecto.");
        }
    } while (!isApta);

    return input;
}

bool ComprobarTirada(string tirada1, string tirada2, int[,] tablero) {
    bool isPareja = false;

    string[] tirada1Texto = tirada1.Split(":");
    int[] tirada1Entero = [int.Parse(tirada1Texto[0]), int.Parse(tirada1Texto[1])];
    
    string[] tirada2Texto = tirada2.Split(":");
    int[] tirada2Entero = [int.Parse(tirada2Texto[0]), int.Parse(tirada2Texto[1])];

    if (tablero[tirada1Entero[0], tirada1Entero[1]] == tablero[tirada2Entero[0], tirada2Entero[1]]) {
        isPareja = true;
    }

    return isPareja;
}

int[,] Generartablero() {
   int[,] tablero = new int[Size, Size];
   var random = Random.Next(7);
   
   for (int i = 0;  i < tablero.GetLength(0);  i++) {
       for (int j = 0; j < tablero.GetLength(1) && tablero[i, j] != 0; j++)
       {
           if (random % 2 == 0) {
               tablero[i, j] = random;
           }
       }
   }
   return tablero;
}

void ImprimirTablero(int[,] tablero, bool isAdivinada) {
    WriteLine("--------------------");
    WriteLine("       Tablero      ");
    WriteLine("--------------------");

    for (int i = 0;  i < tablero.GetLength(0);  i++) {
        for (int j = 0; j < tablero.GetLength(1); j++) {
            if (isAdivinada) {
                Write($"[  {tablero[i, j]}  ]");
            }
            else {
                Write($"[⚪ ]");
            }
        }
        WriteLine();
    }
}