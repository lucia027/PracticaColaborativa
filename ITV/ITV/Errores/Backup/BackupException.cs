using ITV.Errores.Common;

namespace ITV.Errores.Backup;

public abstract class BackupException(string message) : DomainException(message) {

    public sealed class FileNotFound(string details)
        : BackupException("No se ha encontrado el archivo de backup");
    
    public sealed class InvalidBackupFile(string details)
        : BackupException("El archivo es invalido o esta corrupto.");
    
    public sealed class CreationError(string details)
        : BackupException("Error al crear el backup.");
    
    public sealed class RestorationError(string details)
        : BackupException("Error al restaurar el backup.");
    
    public sealed class DirectoryError(string details)
        : BackupException("Error con el directorio del backup.");
}