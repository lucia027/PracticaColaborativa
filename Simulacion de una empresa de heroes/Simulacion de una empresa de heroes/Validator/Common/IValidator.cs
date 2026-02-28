namespace Simulacion_de_una_empresa_de_heroes.Validator;

public interface IValidator<T> {
    IEnumerable<string> Validate(T entidad);
}