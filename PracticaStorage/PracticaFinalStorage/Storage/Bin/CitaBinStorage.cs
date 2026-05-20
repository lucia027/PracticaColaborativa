using System.Text;
using PracticaFinalStorage.Dto;
using PracticaFinalStorage.Mapper;
using PracticaFinalStorage.Models;
using PracticaFinalStorage.Storage.Common;

namespace PracticaFinalStorage.Storage.Bin;

public class CitaBinStorage : IStorage {

    public CitaBinStorage() {
        InitStorage();
    }

    public void Salvar(IEnumerable<Cita> items, string path) {
        try {
            using var stream = File.Create(path);
            var dtos = items.Select(d => d.ToDto());
            var writer = new BinaryWriter(stream, new UTF8Encoding());
            writer.Write(dtos.Count());

            foreach (var d in dtos) {
                writer.Write(d.Id);
            }

        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<Cita> Cargar(string path) {
        if (!File.Exists(path)) throw new FileNotFoundException();
        try {
            var stream = File.OpenRead(path);
            var reader = new BinaryReader(stream, new UTF8Encoding());
            var count = reader.ReadInt32();
            List<Cita> lista = [];
            for (int i = 0; i < count; i++) {
                var c = new CitaDto(
                    reader.ReadInt32()
                ).ToModel();
                lista.Add(c);
            }
            return lista
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    private void InitStorage() {
        if (Directory.Exists(Config.DataFolder)) return;
        Directory.CreateDirectory("data");
    }
}