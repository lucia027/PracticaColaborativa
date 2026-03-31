using ITV.Dto;
using ITV.Enums;
using ITV.Models;

namespace ITV.Mapper;

public static class VehiculoMapper {

    /// <summary>
    /// Convierte un VehiculoDto a un Vehiculo.
    /// </summary>
    /// <param name="dto">VehiculoDto a convertir.</param>
    /// <returns>Vehiculo convertido.</returns>
    public static Vehiculo ToModel(this VehiculoDto dto) {
        return new Vehiculo {
            Id = dto.Id,
            Matricula = dto.Matricula,
            Marca = dto.Marca,
            Modelo = dto.Modelo,
            Cilindrada = dto.Cilindrada,
            Motor = Enum.TryParse(dto.Motor, out Motor motor) ? motor : Motor.Diesel,
            DniDueño = dto.DniDueño,
            IsDelete = dto.IsDelete
        };
    }

    /// <summary>
    /// Convierte un Vehiculo a un VehiculoDto.
    /// </summary>
    /// <param name="vehiculo">Vehiculo a convertir.</param>
    /// <returns>VehiculoDto convertido.</returns>
    public static VehiculoDto ToDto(this Vehiculo vehiculo) {
        return new VehiculoDto (
            vehiculo.Id,
            vehiculo.Matricula,
            vehiculo.Marca,
            vehiculo.Modelo,
            vehiculo.Cilindrada,
            vehiculo.Motor.ToString(),
            vehiculo.DniDueño,
            vehiculo.IsDelete
        );
    }
}