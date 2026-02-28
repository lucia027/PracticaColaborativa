namespace Genericos.Models;

public class CajaGenericosMultiple<T, TP> (T valor1, TP valor2) {
    private T _valor1 = valor1;
    private TP _valor2 = valor2;

    public T GetValor1 => _valor1;
    public void SetValor1(T valorNuevo1) {
        _valor1 = valorNuevo1;
    }

    public TP GetValor2 => _valor2;
    public void SetValor2(TP valorNuevo2) {
        _valor2 = valorNuevo2;
    }
}