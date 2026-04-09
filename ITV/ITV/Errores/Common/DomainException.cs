namespace ITV.Errores.Common;

public abstract class DomainException(string message) : Exception(message) { }