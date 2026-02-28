using System.Text;
using Biblioteca.Models;
using Biblioteca.Repository;
using Biblioteca.Service;
using Biblioteca.Validator;

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
    IFichaService service = new FichaService(
        DvdRepository.GetInstance(),
        RevistaRepository.GetInstance(),
        LibroRepository.GetInstance(),
        new DvdValidator(),
        new RevistaValidator(),
        new LibroValidator() );
    
    Console.WriteLine("¡¡Bienvenido al programa de la biblioteca!! 😊");
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine();
    ImprimirMenu();
    OpcionMenu(service);
}

// Metodos auxiliares
void ImprimirMenu() {
    Console.WriteLine("---------------------");
    Console.WriteLine("         Menú        ");
    Console.WriteLine("---------------------");
    Console.WriteLine("1- Menú de Revista 📕");
    Console.WriteLine("2- Menú de Dvd 💿");
    Console.WriteLine("3- Menú de Libro 📖");
    Console.WriteLine("4- Salir");
    Console.WriteLine();
}

void OpcionMenu(IFichaService service) {
    string opcion;
    do {
        opcion = Console.ReadLine() ?? "0";

        switch (opcion) {
            case "1":
                ImprimirMenuRevista();
                OpcionMenuRevista(service);
                break;
            case "2":
                ImprimirMenuDvd();
                OpcionMenuDvd(service);
                break;
            case "3":
                ImprimirMenuLibro();
                OpcionMenuLibro(service);
                break;
            case "4":
                break;
            default:
                Console.WriteLine("Opcion del menú no valida, introduce una valida. ❌");
                opcion = "0";
                break;
        }
    } while (opcion == "0");
}

void ImprimirMenuRevista() {
    Console.WriteLine("---------------------");
    Console.WriteLine("   Menú de Revista   ");
    Console.WriteLine("---------------------");
    Console.WriteLine("1- Crear revista");
    Console.WriteLine("2- Actualizar revista");
    Console.WriteLine("3- Eliminar revista");
    Console.WriteLine("4- Buscar revista");
    Console.WriteLine("5- Mostar todos");
    Console.WriteLine("6- Volver");
    Console.WriteLine();
}

void OpcionMenuRevista(IFichaService service) {
    string opcion;
    do {
        opcion = Console.ReadLine() ?? "0";
        switch (opcion) {
            case "1":
                CrearRevista(service);
                ImprimirMenuRevista();
                OpcionMenuRevista(service);
                break;
            case "2":
                ActualizarRevista(service);
                ImprimirMenuRevista();
                OpcionMenuRevista(service);
                break;
            case "3":
                EliminarRevista(service);
                ImprimirMenuRevista();
                OpcionMenuRevista(service);
                break;
            case "4":
                MostrarRevista(service);
                ImprimirMenuRevista();
                OpcionMenuRevista(service);
                break;
            case "5":
                MostrarTodasRevista(service);
                ImprimirMenuRevista();
                OpcionMenuRevista(service);
                break;
            case "6":
                ImprimirMenu();
                OpcionMenu(service);
                break;
            default:
                Console.WriteLine("Opcion del menú no valida, introduce una valida. ❌");
                opcion = "0";
                break;
        }
    } while (opcion == "0");
}

void ImprimirMenuDvd() {
    Console.WriteLine("-------------------");
    Console.WriteLine("    Menú de Dvd    ");
    Console.WriteLine("-------------------");
    Console.WriteLine("1- Crear dvd");
    Console.WriteLine("2- Actualizar dvd");
    Console.WriteLine("3- Eliminar dvd");
    Console.WriteLine("4- Buscar dvd");
    Console.WriteLine("5- Mostar todos");
    Console.WriteLine("6- Volver");
    Console.WriteLine();
}

void OpcionMenuDvd(IFichaService service) {
    string opcion;
    do {
        opcion = Console.ReadLine() ?? "0";
        switch (opcion) {
            case "1":
                CrearDvd(service);
                ImprimirMenuDvd();
                OpcionMenuDvd(service);    
                break;
            case "2":
                ActualizarDvd(service);
                ImprimirMenuDvd();
                OpcionMenuDvd(service); 
                break;
            case "3":
                EliminarDvd(service);
                ImprimirMenuDvd();
                OpcionMenuDvd(service); 
                break;
            case "4":
                MostrarDvd(service);
                ImprimirMenuDvd();
                OpcionMenuDvd(service); 
                break;
            case "5":
                MostrarTodosDvd(service);
                ImprimirMenuDvd();
                OpcionMenuDvd(service); 
                break;
            case "6":
                ImprimirMenu();
                OpcionMenu(service);
                break;
            default:
                Console.WriteLine("Opcion del menú no valida, introduce una valida. ❌");
                opcion = "0";
                break;
        }
    } while (opcion == "0");
}

void ImprimirMenuLibro() {
    Console.WriteLine("-------------------");
    Console.WriteLine("   Menú de Libro   ");
    Console.WriteLine("-------------------");
    Console.WriteLine("1- Crear libro");
    Console.WriteLine("2- Actualizar libro");
    Console.WriteLine("3- Eliminar libro");
    Console.WriteLine("4- Buscar libro");
    Console.WriteLine("5- Mostar todos");
    Console.WriteLine("6- Volver");
    Console.WriteLine();
}

void OpcionMenuLibro(IFichaService service) {
    string opcion;
    do {
        opcion = Console.ReadLine() ?? "0";
        switch (opcion) {
            case "1":
                CrearLibro(service);
                ImprimirMenuLibro();
                OpcionMenuLibro(service);
                break;
            case "2":
                ActualizarLibro(service);
                ImprimirMenuLibro();
                OpcionMenuLibro(service);
                break;
            case "3":
                EliminarLibro(service);
                ImprimirMenuLibro();
                OpcionMenuLibro(service);
                break;
            case "4":
                MostrarLibro(service);
                ImprimirMenuLibro();
                OpcionMenuLibro(service);
                break;
            case "5":
                MostrarTodosLibro(service);
                ImprimirMenuLibro();
                OpcionMenuLibro(service);
                break;
            case "6":
                ImprimirMenu();
                OpcionMenu(service);
                break;
            default:
                Console.WriteLine("Opcion del menú no valida, introduce una valida. ❌");
                opcion = "0";
                break;
        }
    } while (opcion == "0");
}

void CrearRevista(IFichaService service) {
    Console.WriteLine("Introduce los datos de la revista.");
    
    Console.WriteLine("Nombre:");
    var nombreNuevo = Console.ReadLine() ?? "";
    Console.WriteLine("Numero de usos:");
    int numUsosNuevo = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine("Categoria:");
    // var categoriaNueva = CategoriaRevista.Parse(Console.ReadLine() ?? "Cotilleo");
    var categoriaNueva = CategoriaRevista.Cotilleo;
    
    var revista = new Revista(nombreNuevo, numUsosNuevo, categoriaNueva);

    try {
        service.CreateRevista(revista);
    } catch (Exception e) {
        Console.WriteLine(e);
    }
}

void ActualizarRevista(IFichaService service) {

}

void EliminarRevista(IFichaService service) {
    Console.WriteLine("Introduce el id de la revista a eliminar:");
    var id = int.Parse(Console.ReadLine() ?? "0");

    try {
        service.DeleteRevista(id);
    }
    catch (Exception e) {
        Console.WriteLine(e);
    }
}

void MostrarRevista(IFichaService service) {
    Console.WriteLine("Introduce el id de la revista a mostrar:");
    var id = int.Parse(Console.ReadLine() ?? "0");

    try {
        service.GetByIdRevista(id);
    }
    catch (Exception e) {
        Console.WriteLine(e);
    }
}

void MostrarTodasRevista(IFichaService service) {
    Console.WriteLine("Mostrando todas las revistas..");
    service.GetAllRevista();
}

void CrearDvd(IFichaService service) {
    Console.WriteLine("Introduce los datos del dvd.");
    
    Console.WriteLine("Nombre:");
    var nombreNuevo = Console.ReadLine() ?? "";
    Console.WriteLine("Numero de usos:");
    int numUsosNuevo = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine("Minutos:");
    int minutosNuevo = int.Parse(Console.ReadLine() ?? "0");
    
    var dvd = new Dvd(nombreNuevo, numUsosNuevo, minutosNuevo);

    try {
        service.CreateDvd(dvd);
    } catch (Exception e) {
        Console.WriteLine(e);
    }
}

void ActualizarDvd(IFichaService service) {
}

void EliminarDvd(IFichaService service) {
    Console.WriteLine("Introduce el id del dvd a eliminar:");
    var id = int.Parse(Console.ReadLine() ?? "0");

    try {
        service.DeleteDvd(id);
    }
    catch (Exception e) {
        Console.WriteLine(e);
    }
}

void MostrarDvd(IFichaService service) {
    Console.WriteLine("Introduce el id del dvd a mostrar:");
    var id = int.Parse(Console.ReadLine() ?? "0");

    try {
        service.GetByIdDvd(id);
    }
    catch (Exception e) {
        Console.WriteLine(e);
    }
}

void MostrarTodosDvd(IFichaService service) {
    Console.WriteLine("Mostrando todos los dvd..");
    service.GetAllDvd();
}

void CrearLibro(IFichaService service) {
    Console.WriteLine("Introduce los datos del libro.");
    
    Console.WriteLine("Nombre:");
    var nombreNuevo = Console.ReadLine() ?? "";
    Console.WriteLine("Numero de usos:");
    int numUsosNuevo = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine("Numero de paginas:");
    int paginasNuevo = int.Parse(Console.ReadLine() ?? "0");
    
    var libro = new Libro(nombreNuevo, numUsosNuevo, paginasNuevo);

    try {
        service.CreateLibro(libro);
    } catch (Exception e) {
        Console.WriteLine(e);
    }
}

void ActualizarLibro(IFichaService service) {
}

void EliminarLibro(IFichaService service) {
    Console.WriteLine("Introduce el id del libro a eliminar:");
    var id = int.Parse(Console.ReadLine() ?? "0");

    try {
        service.DeleteLibro(id);
    }
    catch (Exception e) {
        Console.WriteLine(e);
    }
}

void MostrarLibro(IFichaService service) {
    Console.WriteLine("Introduce el id del libro a mostrar:");
    var id = int.Parse(Console.ReadLine() ?? "0");

    try {
        service.GetByIdLibro(id);
    }
    catch (Exception e) {
        Console.WriteLine(e);
    }
}

void MostrarTodosLibro(IFichaService service) {
    Console.WriteLine("Mostrando todos los libros..");
    service.GetAllLibro();
}