using El_registro_de_Jinshi.Models;

namespace El_registro_de_Jinshi.Repository;

public class NobleRepository {
    private int _totalNobles;
    private Noble?[] _lista = new Noble[5];

    public Noble? Create(Noble noble) {
        bool isAñadido = false;
        for (int i = 0; i < _lista.Length && !isAñadido; i++) {
            if (_lista[i] == null && !isAñadido) {
                _lista[i] = noble;
                isAñadido = true;
                _totalNobles++;
                return noble;
            }
        }

        return null;
    }

    public Noble? Update(Noble noble) {
        for (int i = 0; i < _lista.Length; i++) {
            if (_lista[i] != null && _lista[i]?.Id == noble.Id) {
                _lista[i] = noble;
                return noble;
            }
        }

        return null;
    }

    public Noble? Delete(int id) {
        for (int i = 0; i < _lista.Length; i++) {
            if (_lista[i] != null && _lista[i]?.Id == id) {
                Noble eliminado = _lista[i]!;
                _lista[i] = null;
                _totalNobles--;
                return eliminado;
            }
        }

        return null;
    }

    public Noble? GetById(int id) {
        foreach (var noble in _lista) {
            if (noble != null && noble.Id == id) {
                return noble;
            }
        }

        return null;
    }

    public Noble[] GetAll() {
        return ListaCompacta();
    }

    private Noble[] ListaCompacta() {
        Noble[] listaCompacta = new Noble[_totalNobles];
        int indexListaCompacta = 0;
        foreach (var noble in _lista) {
            if (noble != null) {
                listaCompacta[indexListaCompacta] = noble;
                indexListaCompacta++;
            }
        }

        return listaCompacta;
    }
}