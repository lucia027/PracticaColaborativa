using System.Text;
using Itv.Models;
using PracticaStorage.Config;
using PracticaStorage.Dto;
using PracticaStorage.Mappers;

namespace PracticaStorage.Storage.Csv;

public class CitaCsvStorage : ICitaStorage {

    public CitaCsvStorage() {
        InitStorage();
    }

    public void Salvar(IEnumerable<Cita> items, string path) {
        try {
            var dtos = items.Select(d => d.ToDto());
            using var writer = new StreamWriter(path);
            writer.Write("Id;Matricula;Marca;Modelo;Cilindrada;DniDueño;FechaMatriculacion;FechaInspeccion;CreateAt;UpdateAt;IsDelete");
            foreach (var d in dtos) {
                writer.Write($"{d.Id};{d.Matricula};{d.Marca};{d.Modelo};{d.Cilindrada};{d.DniDueño};{d.FechaMatriculacion};{d.FechaInspeccion};{d.CreateAt};{d.UpdateAt};{d.IsDelete}");
            }
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public IEnumerable<Cita> Cargar(string path) {
        if (!File.Exists(path)) throw new FileNotFoundException();
        try {
            return File.ReadAllLines(path)
                .Skip(1)
                .Select(l => l.Split(";"))
                .Select(campo => new CitaDto(
                    int.Parse(campo[0]),
                    campo[1],
                    campo[2],
                    campo[3],
                    int.Parse(campo[4]),
                    campo[5],
                    campo[6],
                    campo[7],
                    campo[8],
                    campo[9],
                    campo[10],
                    bool.Parse(campo[11])
                ).ToModel());
        } catch(Exception e)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               {
            throw new ArgumentException();
        }
    }

    private void InitStorage() {
        if (Directory.Exists(Configuracion.DataFolder)) return;
        Directory.CreateDirectory("data");
    }
}