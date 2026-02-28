using Biblioteca.List;
using Biblioteca.Models;

namespace Biblioteca.Repository;

public class RevistaRepository : IRevistaRepository {
    private static RevistaRepository? _instance;
    private readonly ILista<Revista> _lista = new Lista<Revista>();
    
    public Revista? Create(Revista revista) {
        if (_lista.Existe(revista)) {
            return null;
        }
        _lista.AgregarFinal(revista);
        return revista;
    }

    public Revista? Update(Revista revista, int id) {
        //Devolvemos null cuando no exista por que si no existe no lo podemos modificar.
        if (!_lista.Existe(revista)) {
            return null;
        }

        var indice = IndexOf(id);
        _lista.AgregarEnMedio(revista, indice);
        return revista;
    }

    public Revista? Delete(int id) {
        //Si Id no está en la lista es que no existe.
        var indice = IndexOf(id);
        if (indice == -1) {
            return null;
        }

        Revista eliminado = _lista.ObtenerEnMedio(indice);
        _lista.EliminarEnMedio(indice);
        return eliminado;
    }

    public Revista? GetById(int id) {
        //Para poder utilizar el foreach con una lista necesitamos IEnumerable
        foreach (Revista revista in _lista) {
            if (revista.Id == id) {
                return revista;
            }
        }
        return null;
    }

    public ILista<Revista> GetAll() {
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
    
    public static RevistaRepository GetInstance() {
        return _instance ??= new RevistaRepository();
    }
}