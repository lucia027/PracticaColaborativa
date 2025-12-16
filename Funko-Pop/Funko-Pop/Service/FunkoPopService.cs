using Funko_Pop.Models;
using Funko_Pop.Repositories;
using Funko_Pop.Validator;

namespace Funko_Pop.Service;

public class FunkoPopService(FunkoPopRepository repository, FunkoPopValidator validator) {

    public void DatosBaseFunkoPop() {
        repository.IniciarDatosBase();
    }

    /// <summary>
    ///  Ordena el vector de FunkoPops en base al precio tanto acendente como descendete.
    /// </summary>
    /// <param name="tipoOrden">Tipo de orden(ascendete o descendente).</param>
    /// <param name="funkos">Vector donde almacenamor los FunkoPops</param>
    /// <returns>Vector ordenado.</returns>
    private FunkoPop[] OrdenarFunkoPop(string tipoOrden, FunkoPop[] funkos) {
        if (tipoOrden == "ASC") {
            for (int i = 0; i < funkos.Length; i++) {
                for (int j = 0; j < funkos.Length; j++) {
                    if (funkos[j].Precio > funkos[j + 1].Precio) {
                        (funkos[j], funkos[j+1]) = (funkos[j+1], funkos[j]);
                    }
                }
            }
        }

        if (tipoOrden == "DSC") {
            for (int i = 0; i < funkos.Length; i++) {
                for (int j = 0; j < funkos.Length; j++) {
                    if (funkos[j].Precio < funkos[j + 1].Precio) {
                        (funkos[j], funkos[j+1]) = (funkos[j+1], funkos[j]);
                    }
                }
            }
        }

        return funkos;
    }

    /// <summary>
    /// Muestra todos los FunkoPops ordenados por precio.
    /// </summary>
    /// <param name="tipoOrden">Tipo de ordenamiento</param>
    /// <returns>Vector ordenado.</returns>
    public FunkoPop[] GetAll(string tipoOrden) {
        var funkos = repository.GetAll();
        return OrdenarFunkoPop(tipoOrden, funkos);
    }

    /// <summary>
    ///  Obtiene el FunkoPop en base a su id.
    /// </summary>
    /// <param name="id"> Id del objeto a buscar.</param>
    /// <returns>Objeto con el id especificado.</returns>
    public FunkoPop GetById(int id) {
        return repository.GetById(id) ?? throw new KeyNotFoundException($"El FunkoPop con id={id} no se puede econtrar.");
    }

    /// <summary>
    /// Elimina el FunkoPop con el id indicado. 
    /// </summary>
    /// <param name="id">id del objeto a eliminar.</param>
    /// <returns>Devuelve el objeto eliminado.</returns>
    public FunkoPop DeleteFunkoPop(int id) {
        return repository.Delete(id) ?? throw new KeyNotFoundException($"El FunkoPop con id={id} no se puede econtrar.");
    }

    /// <summary>
    ///  Cuarda el FunoPop ya validado.
    /// </summary>
    /// <param name="funko">Objeto a guardar.</param>
    /// <returns>Objeto guardado.</returns>
    public FunkoPop SaveFunkoPop(FunkoPop funko) {
        var funkoValidado = validator.FunkoValidate(funko);
        return repository.Save(funkoValidado);
    }

    /// <summary>
    ///  Actualiza el FunkoPop en caso de encontrarlo.
    /// </summary>
    /// <param name="funko"> Objeto a actualizar.</param>
    /// <returns>Objeto actualizado</returns>
    public FunkoPop UpdateFunkoPop(FunkoPop funko) {
        var funkoValidado = validator.FunkoValidate(funko);
        return repository.Update(funkoValidado) ?? throw new KeyNotFoundException($"El FunkoPop con id={funko.Id} no se puede econtrar.");
    }
}