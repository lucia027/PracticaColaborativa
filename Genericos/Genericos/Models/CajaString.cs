namespace Genericos.Models;

public class CajaString(string valor) {
    private string _valor = valor;
    public string GetValor => _valor;
    public void SetValor(string valorNuevo) {
        _valor = valorNuevo;
    }
}