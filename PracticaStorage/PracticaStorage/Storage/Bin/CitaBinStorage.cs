using System.Text;
using Itv.Models;
using PracticaStorage.Config;
using PracticaStorage.Dto;
using PracticaStorage.Mappers;

namespace PracticaStorage.Storage.Bin;

public class CitaBinStorage : ICitaStorage {

    public CitaBinStorage() {
        InitStorage();
    }

    public void Salvar(IEnumerable<Cita> items, string path) {
        try {
            var stream = File.Create(path);
            var writer = new BinaryWriter(stream, new UTF8Encoding());

            var dtos = items.Select(d => d.ToDto());
            writer.Write(dtos.Count());
            foreach (var d in dtos) {
                writer.Write(d.Id);
                writer.Write(d.Matricula);
                writer.Write(d.Marca);
                writer.Write(d.Modelo);
                writer.Write(d.Cilindrada);
                writer.Write(d.Motor);
                writer.Write(d.DniDueño);
                writer.Write(d.FechaMatriculacion);
                writer.Write(d.FechaInspeccion);
                writer.Write(d.CreateAt);
                writer.Write(d.UpdateAt);
                writer.Write(d.IsDelete);
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
            var reader = new BinaryReader(stream, Encoding.UTF8);
            List<Cita> lista = [];
            var count = reader.ReadInt32();

            for (int i = 0; i < count; i++) {
                var cita = new CitaDto(
                    reader.ReadInt32(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadInt32(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadString(),
                    reader.ReadBoolean()
                    ).ToModel();
                lista.Add(cita);
            }

            return lista;

        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    private void InitStorage() {
        if (Directory.Exists(Configuracion.DataFolder)) return;
        Directory.CreateDirectory("dara");
    }
}