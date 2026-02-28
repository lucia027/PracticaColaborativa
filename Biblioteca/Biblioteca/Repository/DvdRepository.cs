using Biblioteca.List;
using Biblioteca.Models;

namespace Biblioteca.Repository;

public class DvdRepository : IDvdRepository {
    private static DvdRepository? _instance;
    private readonly ILista<Dvd> _lista = new Lista<Dvd>();
    
    public Dvd? Create(Dvd dvd) {
        if (_lista.Existe(dvd)) {
            return null;
        }
        
        _lista.AgregarFinal(dvd);
        return dvd;
    }

    public Dvd? Update(Dvd dvd, int id) {
        //Devolvemos null cuando no exista por que si no existe no lo podemos modificar.
        if (!_lista.Existe(dvd)) {
            return null;
        }

        var indice = IndexOf(id);
        _lista.AgregarEnMedio(dvd, indice);
        return dvd;
    }

    public Dvd? Delete(int id) {
        var indice = IndexOf(id);
        if (indice == -1) {
            return null;
        }

        var eliminado = _lista.ObtenerEnMedio(indice);
        _lista.EliminarEnMedio(indice);
        return eliminado;
    }

    public Dvd? GetById(int id) {
        foreach (Dvd dvd in _lista) {
            if (dvd.Id == id) {
                return dvd;
            }
        }

        return null;
    }

    public ILista<Dvd> GetAll() {
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

    public static DvdRepository GetInstance() {
        return _instance ??= new DvdRepository();
    }
}