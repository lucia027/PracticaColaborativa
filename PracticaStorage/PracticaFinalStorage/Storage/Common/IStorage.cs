using PracticaFinalStorage.Models;

namespace PracticaFinalStorage.Storage.Common;

public interface IStorage {
    public void Salvar(IEnumerable<Cita> items, string path);
    public IEnumerable<Cita> Cargar(string path);
}