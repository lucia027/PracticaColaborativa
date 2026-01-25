using Biblioteca.Models;
using Biblioteca.Repository.Common;

namespace Biblioteca.Repository;

public interface IDvdRepository : ICrudRepository<Dvd, int> { }