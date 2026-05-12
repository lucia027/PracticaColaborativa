namespace PracticaStorage.Storage;

public interface IPracticaStorage<T> {
    void Salvar(IEnumerable<T> items, string path);
    IEnumerable<T> Cargar(string path);
}