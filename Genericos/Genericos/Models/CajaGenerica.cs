namespace Genericos.Models;

public class CajaGenerica<T> (T valor) {
    private T _valor  { get; set; }
    
    //Es una forma de hacerlo manual, pero ambas son validas
    /*
    public T GetValor() => _valor;
    private void SetValor(T valorNuevo) {
        _valor = valorNuevo;
    }
    */
}