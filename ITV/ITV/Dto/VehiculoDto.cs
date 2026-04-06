using System.Xml.Serialization;

namespace ITV.Dto;

[XmlRoot("Itv")]
[XmlType("Vehiculo")]
public record VehiculoDto(
    [property: XmlAttribute("id")] int Id,
    [property: XmlAttribute("matricula")] string Matricula,
    [property: XmlAttribute("marca")] string Marca,
    [property: XmlAttribute("modelo")] string Modelo,
    [property: XmlAttribute("cilindrada")] int Cilindrada,
    [property: XmlAttribute("motor")] string Motor,
    [property: XmlAttribute("dniDueño")] string DniDueño,
    [property: XmlAttribute("isDelete")] bool IsDelete
) {
    public VehiculoDto() : this (0, "", "", "", 0 ,"", "", false) { }
}