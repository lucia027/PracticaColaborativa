namespace Biblioteca.List;

public interface ILista<T> {
    void AgregarInicio(T valor);
    void AgregarEnMedio(T valor, int indice);
    void AgregarFinal(T valor);
    void EliminarInicio();
    void EliminarEnMedio(int indice);
    void EliminarFinal();
    T ObtenerPrimero();
    T ObtenerEnMedio(int indice);
    T ObtenerUltimo();
    bool Existe(T valor);
    int Contar();
    bool EstaVacia();
    void Limpiar();
    void Mostrar();
    IEnumerator<T> GetEnumerator();
}