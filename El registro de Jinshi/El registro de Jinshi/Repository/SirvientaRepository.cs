using El_registro_de_Jinshi.Models;

namespace El_registro_de_Jinshi.Repository;

public class SirvientaRepository {
    private int _totalSirvientas = 0;
    private Sirvienta?[] _lista = new Sirvienta[5];

    public Sirvienta? Create(Sirvienta sirvienta) {
        bool isAñadido = false;
        for (int i = 0; i < _lista.Length && !isAñadido; i++) {
            if (_lista[i] != null && !isAñadido) {
                _lista[i] = sirvienta;
                _totalSirvientas++;
                return sirvienta;
            }
        }

        return null;
    }

    public Sirvienta? Update(Sirvienta sirvienta) {
        for (int i = 0; i < _lista.Length; i++) {
            if (_lista[i] != null && _lista[i]?.Id == sirvienta.Id) {
                _lista[i] = sirvienta;
                return sirvienta;
            }
        }

        return null;
    }

    public Sirvienta? Delete(int id) {
        for (int i = 0; i < _lista.Length; i++) {
            if (_lista[i] != null && _lista[i]?.Id == id) {
                Sirvienta eliminado = _lista[i]!;
                _lista[i] = null;
                _totalSirvientas--;
                return eliminado;
            }
        }

        return null;
    }

    public Sirvienta? GetById(int id) {
        foreach (var sirvienta in _lista) {
            if (sirvienta != null && sirvienta.Id == id) {
                return sirvienta;
            }
        }

        return null;
    }

    public Sirvienta[] GetAll() {
        return ListaCompacta();
    }

    public Sirvienta[] ListaCompacta() {
        int indexListaCompacta = 0;
        Sirvienta[] listaCompacta = new Sirvienta[_totalSirvientas];

        foreach (var sirvienta in _lista) {
            if (sirvienta != null) {
                listaCompacta[indexListaCompacta] = sirvienta;
                indexListaCompacta++;
            }
        }

        return listaCompacta;
    }
}