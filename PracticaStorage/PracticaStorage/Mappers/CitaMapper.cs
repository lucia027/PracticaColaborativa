using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using Itv.Models;
using PracticaStorage.Dto;
using PracticaStorage.Enums;

namespace PracticaStorage.Mappers;

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
            Motor = Enum.TryParse(dto.Motor, out Motor m) ? m : Motor.Diesel,
            DniDueño = dto.DniDueño,
            FechaMatriculacion = DateTime.TryParse(dto.FechaMatriculacion, InvariantCulture, out var  d) ? d : DateTime.Now,
            FechaInspeccion = DateTime.TryParse(dto.FechaInspeccion, InvariantCulture, out var f) ? f : DateTime.Now,
            CreateAt = DateTime.TryParse(dto.CreateAt, InvariantCulture, out var c) ? c : DateTime.Now,
            UpdateAt = DateTime.TryParse(dto.UpdateAt, InvariantCulture, out var u) ? u : null,
            IsDelete = dto.IsDelete,
        };
    }

    public static CitaDto ToDto(this Cita model) {
        return new CitaDto (
            model.Id,
            model.Matricula,
            model.Marca,
            model.Modelo,
            model.Cilindrada,
            model.Motor.ToString(),
            model.DniDueño,
            model.FechaMatriculacion.ToString(DateTimeFormat, InvariantCulture),
            model.FechaInspeccion.ToString(DateTimeFormat, InvariantCulture),
            model.CreateAt.ToString(DateTimeFormat, InvariantCulture),
            model.UpdateAt?.ToString(DateTimeFormat, InvariantCulture) ?? "No se ha actualizado",
            model.IsDelete);
    }
}