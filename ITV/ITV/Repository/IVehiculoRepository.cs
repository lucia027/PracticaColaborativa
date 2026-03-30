using ITV.Models;
using ITV.Repository.Common;

namespace ITV.Repository;

public interface IVehiculoRepository : ICrudRepository<int, Vehiculo> {
    /// <summary>
    /// Elimina permanentemente un vehiculo del almacen.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Vehiculo? DeleteHard(int id);
}