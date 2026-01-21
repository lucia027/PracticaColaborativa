namespace ListasPilasColas.Models;

public class Nodo<T> (T valor) {
    private T valor { get; set; }
    private Nodo<T>? siguiente { get; set; } = null;

    public override string ToString() {
        return $"Nodo({valor})";
    }
}