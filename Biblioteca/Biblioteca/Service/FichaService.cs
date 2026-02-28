using Biblioteca.List;
using Biblioteca.Models;
using Biblioteca.Repository;
using Biblioteca.Validator;

namespace Biblioteca.Service;

public class FichaService( 
    IDvdRepository dvdRepository, 
    IRevistaRepository revistaRepository, 
    ILibroRepository libroRepository, 
    IDvdValidator dvdValidator,
    IRevistaValidator revistaValidator,
    ILibroValidator libroValidator
) : IFichaService {
    
    public string? TipoFicha(Ficha ficha) {
        if (ficha is Revista) {
            return "Revista";
        }
        if (ficha is Dvd) {
            return "Dvd";
        }
        if (ficha is Libro) {
            return "Libro";
        }
        return null;
    }

    public Revista CreateRevista(Revista revista) {
        var revistaValidada = revistaValidator.Validate(revista);
        return revistaRepository.Create(revistaValidada) ?? throw new ArgumentException($"No se pudo crear la revista con el id={revistaValidada.Id}.");
    }

    public Revista UpdateRevista(Revista revista) {
        var revistaValida = revistaValidator.Validate(revista);
        return revistaRepository.Update(revistaValida, revistaValida.Id) ?? throw new KeyNotFoundException($"No se encontro la revista para actualizar con el id={revistaValida.Id}.");
    }

    public Revista DeleteRevista(int id) {
        return revistaRepository.Delete(id) ?? throw new KeyNotFoundException($"No se encuentra la Revista para eliminar con el id={id}.");
    }

    public Revista GetByIdRevista(int id) {
        return revistaRepository.GetById(id) ?? throw new KeyNotFoundException($"No se encuentra la Revista con el id={id}.");
    }

    public ILista<Revista> GetAllRevista() {
        return revistaRepository.GetAll();
    }

    public Dvd CreateDvd(Dvd dvd) {
        var dvdValidado = dvdValidator.Validate(dvd);
        return dvdRepository.Create(dvdValidado) ?? throw new ArgumentException($"No se puede crear el dvd con el id={dvdValidado.Id}.");
    }

    public Dvd UpdateDvd(Dvd dvd) {
        var dvdValidado = dvdValidator.Validate(dvd);
        return dvdRepository.Update(dvdValidado, dvdValidado.Id) ?? throw new KeyNotFoundException($"No se encontro el Dvd para actualizar con el id={dvdValidado.Id}.");
    }

    public Dvd DeleteDvd(int id) {
        return dvdRepository.Delete(id) ?? throw new KeyNotFoundException($"No se puedo encontrar el Dvd para eliminar con el id={id}.");
    }

    public Dvd GetByIdDvd(int id) {
        return dvdRepository.GetById(id) ?? throw new KeyNotFoundException($"No se encuentra el Dvd con el id={id}.");
    }

    public ILista<Dvd> GetAllDvd() {
        return dvdRepository.GetAll();
    }

    public Libro CreateLibro(Libro libro) {
        var libroValidado = libroValidator.Validate(libro);
        return libroRepository.Create(libroValidado) ?? throw new ArgumentException($"No se puede guardar el libro con id={libroValidado.Id}");
    }

    public Libro UpdateLibro(Libro libro) {
        var libroValidado = libroValidator.Validate(libro);
        return libroRepository.Update(libroValidado, libroValidado.Id) ?? throw new KeyNotFoundException($"No se encontro el Libro para actualizar con el id={libroValidado.Id}.");
    }

    public Libro DeleteLibro(int id) {
        return libroRepository.Delete(id) ?? throw new KeyNotFoundException($"No se encontro el libro para eliminar con el id={id}.");
    }

    public Libro GetByIdLibro(int id) {
        return libroRepository.GetById(id) ?? throw new KeyNotFoundException($"No se encontro el libro con el id={id}.");
    }

    public ILista<Libro> GetAllLibro() {
        return libroRepository.GetAll();
    }
}