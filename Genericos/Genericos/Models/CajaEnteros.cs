namespace Genericos.Models;

public class CajaEnteros(int valor) {
    private int _valor = valor;
    public int GetValor => _valor;
    public void SetValor(int valorNuevo) {
        _valor = valorNuevo;
    }
}