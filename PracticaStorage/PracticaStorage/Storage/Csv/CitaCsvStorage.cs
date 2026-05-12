using System.Text;
using Itv.Models;
using PracticaStorage.Config;
using PracticaStorage.Dto;
using PracticaStorage.Mappers;

namespace PracticaStorage.Storage.Csv;

public class CitaCsvStorage : ICitaStorage{

    public CitaCsvStorage() {
        InitStorage();
    }

    public void Salvar(IEnumerable<Cita> items, string path) {
        try {
            using var writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.Write("Id;Matricula;Marca;Modelo;Cilindrada;Motor;DniDueño;FechaMatriculacion;FechaInspeccion;CreateAt;UpdateAt;IsDelete");
            foreach (var c in items) {
                writer.Write($"{c.Id};{c.Matricula};{c.Marca};{c.Modelo};{c.Cilindrada};{c.Motor};{c.FechaMatriculacion};{c.FechaInspeccion};{c.CreateAt};{c.UpdateAt};{c.IsDelete}");
            }
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<Cita> Cargar(string path) {
        if (!File.Exists(path)) throw new FileNotFoundException();

        try {
            var items = File.ReadAllLines(path, Encoding.UTF8)
                .Skip(1)
                .Select(l => l.Split(";"))
                .Select(campos => new CitaDto(
                    int.Parse(campos[0]),
                    campos[1],
                    campos[2],
                    campos[3],
                    int.Parse(campos[4]),
                    campos[5],
                    campos[6],
                    campos[7],
                    campos[8],
                    campos[9],
                    campos[10],
                    bool.Parse(campos[11])
                ).ToModel());
            return items;
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    private void InitStorage() {
        if (Directory.Exists(Configuracion.DataFolder)) return;
        Directory.CreateDirectory("data");
    }
}