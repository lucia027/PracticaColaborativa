using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PersonaService.Models;

/// <summary>
///     Entidad que representa una persona en el sistema.
/// </summary>
[Table("Personas")] // Nombre de la tabla en la base de datos
[Index(nameof(Email), IsUnique = true)] // Índice único para el campo Email
public class Persona {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(100)] public string Nombre { get; set; } = string.Empty;

    [MaxLength(100)] [EmailAddress] public string Email { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    public override string ToString() {
        return
            $"Persona(Id={Id}, Nombre={Nombre}, Email={Email}, CreatedAt={CreatedAt:yyyy-MM-dd HH:mm:ss}, UpdatedAt={UpdatedAt:yyyy-MM-dd HH:mm:ss}, IsDeleted={IsDeleted}, DeletedAt={DeletedAt:yyyy-MM-dd HH:mm:ss})";
    }
}