using ITV.Errores.Backup;
using ITV.Errores.Common;

namespace ITV.Errores.Vehiculos;

public abstract class VehiculoException(string message) : DomainException(message) {

    public sealed class NotFound(string details)
        : BackupException("No se ha encontrado el vehiculo.");
    
    public sealed class InvalidBackupFile(string details)
        : BackupException("El archivo es invalido o esta corrupto.");
    
    public sealed class Validation(IEnumerable<string> errors)
        : BackupException("Hay errores en la validacion.");
    
    public sealed class AlreadyExists(string matricula)
        : BackupException("Hay un conflicto por que ya existe la matricula.");
    
    public sealed class StorageError(string details)
        : BackupException("Error en el almacenamiento.");
}