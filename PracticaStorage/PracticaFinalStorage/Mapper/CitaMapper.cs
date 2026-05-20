using System.Globalization;
using PracticaFinalStorage.Dto;
using PracticaFinalStorage.Enum;
using PracticaFinalStorage.Models;

namespace PracticaFinalStorage.Mapper;

public static class CitaMapper {

    private const string DateTimeFormat = "s";
    private static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;

    public static Cita ToModel(this CitaDto dto) {
        return new Cita {
            Id = dto.Id,
            Matricula = dto.Matricula,
            Marca = dto.Marca,
            Modelo = dto.Modelo,
            Cilindrada = dto.Cilindrada,
            Motor = System.Enum.TryParse(dto.Motor, out Motor m) ? m : Motor.Diesel,
            DniDueño = dto.DniDueño,
            FechaMatriculacion = DateTime.TryParse(dto.FechaMatriculacion, InvariantCulture, out var fm)
                ? fm
                : DateTime.Now,
            FechaInspeccion = DateTime.TryParse(dto.FechaInspeccion, InvariantCulture, out var fi) ? fi : DateTime.Now,
            CreateAt = DateTime.TryParse(dto.CreateAt, InvariantCulture, out var c) ? c : DateTime.Now,
            UpdateAt = DateTime.TryParse(dto.UpdateAt, InvariantCulture, out var u) ? u : DateTime.Now,
            IsDelete = dto.IsDelete
        };
    }

    public static CitaDto ToDto(this Cita cita) {
        return new CitaDto(
            cita.Id,
            cita.Matricula,
            cita.Marca,
            cita.Modelo,
            cita.Cilindrada,
            cita.Motor.ToString(),
            cita.DniDueño,
            cita.FechaMatriculacion.ToString(DateTimeFormat ,InvariantCulture),
            cita.FechaInspeccion.ToString(DateTimeFormat ,InvariantCulture),
            cita.CreateAt.ToString(DateTimeFormat ,InvariantCulture),
            cita.UpdateAt?.ToString(DateTimeFormat, InvariantCulture) ?? "No se ha actualizado",
            cita.IsDelete
        );
    }

}