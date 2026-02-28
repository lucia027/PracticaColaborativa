using El_registro_de_Jinshi.Models;

namespace El_registro_de_Jinshi.Repository;

public class BoticariaRepository {
    private int _totalBoticarias;
    private Boticaria?[] _lista = new Boticaria?[5];

    public Boticaria? Create(Boticaria boticaria) {
        bool isAñadido = false;
        for (int i = 0; i < _lista.Length && !isAñadido; i++) {
            if (_lista[i] == null) {
                _lista[i] = boticaria;
                isAñadido = true;
                _totalBoticarias++;
                return boticaria;
            }
        }
        return null;
    }

    public Boticaria? Update(Boticaria boticaria) {
        for (int i = 0; i < _lista.Length; i++) {
            if (_lista[i] != null && _lista[i]?.Id == boticaria.Id) {
                _lista[i] = boticaria;
                return boticaria;
            }
        }

        return null;
    }

    public Boticaria? Delete(int id) {
        for (int i = 0; i < _lista.Length; i++) {
            if (_lista[i] != null && _lista[i]?.Id == id) {
                var eliminado = _lista[i]!;
                _lista[i] = null;
                _totalBoticarias--;
                return eliminado;
            }
        }

        return null;
    }

    public Boticaria? GetById(int id) {
        foreach (var boticaria in _lista) {
            if (boticaria != null && boticaria.Id == id) {
                return boticaria;
            }
        }

        return null;
    }

    public Boticaria[] GetAll() {
        return ListaCompacta();
    }

    private Boticaria[] ListaCompacta() {
        Boticaria[] listaCompacta = new Boticaria[_totalBoticarias];
        int indexCompacto = 0;
        
        foreach (var boticaria in _lista) {
            if (boticaria != null) {
                listaCompacta[indexCompacto] = boticaria;
                indexCompacto++;
            }
        }

        return listaCompacta;
    }
}