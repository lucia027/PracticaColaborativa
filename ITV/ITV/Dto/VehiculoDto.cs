namespace ITV.Dto;

public record VehiculoDto(
    int Id,
    string Matricula,
    string Marca,
    string Modelo,
    int Cilindrada,
    string Motor,
    string DniDueño,
    bool IsDelete
) { }