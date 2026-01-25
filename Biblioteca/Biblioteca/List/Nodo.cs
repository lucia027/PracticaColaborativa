namespace Biblioteca.List;

public class Nodo<T> (T valor) {
    public T Valor { get; set; }
    public Nodo<T>? Siguiente { get; set; } = null;

    public override string ToString() {
        return $"Nodo({valor})";
    }
}