using System.Text;
using PracticaFinalStorage.Dto;
using PracticaFinalStorage.Mapper;
using PracticaFinalStorage.Models;
using PracticaFinalStorage.Storage.Common;

namespace PracticaFinalStorage.Storage.Csv;

public class CitaCsvStorage : IStorage {
    
    public CitaCsvStorage() {
        InitStorage();
    }

    public void Salvar(IEnumerable<Cita> items, string path) {
        try {
            var dtos = items.Select(d => d.ToDto());
            using var writer = new StreamWriter(path);
            writer.Write("Id;Matricula;Marca;Modelo;...");
            foreach (var d in dtos) {
                writer.Write($"{d.Id};{d.Matricula}..");
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

        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    private void InitStorage() {
        if(Directory.Exists(Config.DataFolder)) return;
        Directory.CreateDirectory("data");
    }
}