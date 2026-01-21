namespace ListasPilasColas.Models;

public class Lista<T> : ILista<T> {
    private Nodo<T>? _cabeza;
    private int _contador;
    
    public void AgregarInicio(T valor) {
        var nodoNuevo = new Nodo<T>(valor);

        if (_cabeza == null) {
            _cabeza = nodoNuevo;
        } else {
            nodoNuevo.Siguiente = _cabeza;
            _cabeza = nodoNuevo;
        }

        _contador++;
    }

    public void AgregarEnMedio(T valor) {
        _contador++;

        throw new NotImplementedException();
    }

    public void AgregarFinal(T valor) {
        _contador++;

        throw new NotImplementedException();
    }

    public void EliminarInicio() {
        _contador--;

        throw new NotImplementedException();
    }

    public void EliminarEnMedio(int indice) {
        _contador--;

        throw new NotImplementedException();
    }

    public void EliminarFinal() {
        _contador--;

        throw new NotImplementedException();
    }

    public T ObtenerPrimero() {
        throw new NotImplementedException();
    }

    public T ObtenerEnMedio(int indice) {
        throw new NotImplementedException();
    }

    public T ObtenerUltimo() {
        throw new NotImplementedException();
    }

    public bool Existe(T valor) {
        throw new NotImplementedException();
    }

    public int Contar() {
        throw new NotImplementedException();
    }

    public bool EstaVacia() {
        throw new NotImplementedException();
    }

    public void Limpiar() {
        throw new NotImplementedException();
    }

    public void Mostrar() {
        throw new NotImplementedException();
    }
}