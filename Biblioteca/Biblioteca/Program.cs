using System.Text;

// Configuración de consola y Encoding
Console.Title = "Biblioteca";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

// Constantes y variables globales (Justificadas)


// Programa principal
Main();

// Limpieza de logs y salida
Console.WriteLine("Presiona para salir. 👋🏻😊");
Console.ReadKey();

// Programa principal
void Main() {
    Console.WriteLine("¡¡Bienvenido al programa de la biblioteca!! 😊");
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine();
    ImprimirMenu();
    OpcionMenu();
}

// Metodos auxiliares
void ImprimirMenu() {
    Console.WriteLine("-------------------");
    Console.WriteLine("        Menú       ");
    Console.WriteLine("-------------------");
    Console.WriteLine("1- Menú de Revista");
    Console.WriteLine("2- Menú de Dvd");
    Console.WriteLine("3- Menú de Libro");
    Console.WriteLine("4- Salir");
    Console.WriteLine();
}

void OpcionMenu() {
    string opcion;
    do {
        opcion = Console.ReadLine() ?? "0";

        switch (opcion) {
            case "1":
                ImprimirMenuRevista();
                break;
            case "2":
                ImprimirMenuDvd();
                break;
            case "3":
                ImprimirMenuLibro();
                break;
            case "0":
                Console.WriteLine("Opcion no valida, introduce una valida.");
                break;
                
        }
    } while (opcion != "0");
}

void ImprimirMenuRevista() {
    Console.WriteLine("-------------------");
    Console.WriteLine("  Menú de Revista  ");
    Console.WriteLine("-------------------");
}

void ImprimirMenuDvd() {
    Console.WriteLine("-------------------");
    Console.WriteLine("    Menú de Dvd    ");
    Console.WriteLine("-------------------");
}

void ImprimirMenuLibro() {
    Console.WriteLine("-------------------");
    Console.WriteLine("   Menú de Libro   ");
    Console.WriteLine("-------------------");
}