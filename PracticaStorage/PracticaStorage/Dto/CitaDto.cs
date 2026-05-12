namespace PracticaStorage.Dto;

public record CitaDto(
      int Id ,
      string Matricula,
      string Marca,
      string Modelo, 
      int Cilindrada,
      string Motor,
      string DniDueño,
      string FechaMatriculacion,
      string FechaInspeccion,
      string CreateAt,
      string? UpdateAt,
      bool IsDelete
);