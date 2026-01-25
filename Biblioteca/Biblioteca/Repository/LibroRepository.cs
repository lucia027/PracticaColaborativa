using Biblioteca.List;
using Biblioteca.Models;

namespace Biblioteca.Repository;

public class LibroRepository : ILibroRepository {
    private readonly ILista<Libro> _lista = new Lista<Libro>();
    
    public Libro? Create(Libro libro) {
        if (_lista.Existe(libro)) {
            return null;
        }
        
        _lista.AgregarFinal(libro);
        return libro;
    }

    public Libro? Update(Libro libro, int id) {
        //Devolvemos null cuando no exista por que si no existe no lo podemos modificar.
        if (!_lista.Existe(libro)) {
            return null;
        }

        var indice = IndexOf(id);
        _lista.AgregarEnMedio(libro, indice);
        return libro;
    }

    public Libro? Delete(int id) {
        //Si Id no está en la lista es que no existe.
        var indice = IndexOf(id);
        if (indice == -1) {
            return null;
        }

        var eliminado = _lista.ObtenerEnMedio(indice);
        _lista.EliminarEnMedio(indice);
        return eliminado;
    }

    public Libro? GetById(int id) {
        foreach (Libro libro in _lista) {
            if (libro.Id == id) {
                return libro;
            }
        }

        return null;
    }

    public ILista<Libro> GetAll() {
        return _lista;
    }
    
    private int IndexOf(int id) {
        for (int i = 0; i < _lista.Contar(); i++) {
            if (_lista.ObtenerEnMedio(i).Id == id) {
                return i;
            }
        }

        return -1;
    }
}