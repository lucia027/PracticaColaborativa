using Biblioteca.List;
using Biblioteca.Models;

namespace Biblioteca.Service;

public interface IFichaService {
    string? TipoFicha(Ficha ficha);
    
    Revista CreateRevista(Revista revista);
    Revista UpdateRevista(Revista revista);
    Revista DeleteRevista(int id);
    Revista GetByIdRevista(int id);
    ILista<Revista> GetAllRevista();
    
    Dvd CreateDvd(Dvd dvd);
    Dvd UpdateDvd(Dvd dvd);
    Dvd DeleteDvd(int id);
    Dvd GetByIdDvd(int id);
    ILista<Dvd> GetAllDvd();
    
    Libro CreateLibro(Libro libro);
    Libro UpdateLibro(Libro libro);
    Libro DeleteLibro(int id);
    Libro GetByIdLibro(int id);
    ILista<Libro> GetAllLibro();

}