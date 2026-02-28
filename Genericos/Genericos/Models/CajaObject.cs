namespace Genericos.Models;

public class CajaObject(object valor) {
    private object _valor;
    public object GetValor => _valor;

    public void SetValor(object valorNuevo) {
        _valor = valorNuevo;
    }

}