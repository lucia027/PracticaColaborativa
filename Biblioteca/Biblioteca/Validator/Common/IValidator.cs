namespace Biblioteca.Validator;

public interface IValidator<T> {
    T Validate(T item);
}