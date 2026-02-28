using Biblioteca.Models;
using Biblioteca.Repository.Common;

namespace Biblioteca.Repository;

public interface ILibroRepository : ICrudRepository<Libro, int> { }