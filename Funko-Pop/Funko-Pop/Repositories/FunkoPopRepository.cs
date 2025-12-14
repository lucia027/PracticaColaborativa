using Funko_Pop.Config;
using Funko_Pop.Factories;
using Funko_Pop.Models;
using Serilog;

namespace Funko_Pop.Repositories;
/// <summary>
///  Clase que gestiona el almacenamiento de los FunkoPops.
/// </summary>
public class FunkoPopRepository {
    
    private readonly ILogger _log = Log.ForContext<FunkoPopRepository>();
    private int _contadorId = Configuracion.DatosDefecto;
    private FunkoPop?[] _funkos = FunkoPopFactory.DatosBase();
    
    private int NewId() {
        Log.Debug("Generando nuevo id..");
        return _contadorId++;
    }

    /// <summary>
    ///  Guarda los datos base en el almacenamiento.
    /// </summary>
    private void IniciarDatosBase() {
        var datosBase = FunkoPopFactory.DatosBase();
        foreach (var funko in datosBase) {
            Save(funko!);
        }
    }

    private void Aumentar() {
    }
    
    private void Disminuir() {
    }

    private FunkoPop[] AlmacenamientoCompacto() {
        return _funkos!;  // Para que no de error por el return antes de desarrollarla.
    }

    /// <summary>
    ///  Almacena un nuevo FunkoPop.
    /// </summary>
    /// <param name="funko">Obejto para almacenar</param>
    /// <returns>Devuelve el objeto</returns>
    private FunkoPop Save(FunkoPop funko) {
        var newFunko = funko with { Id = NewId() };
        Aumentar();
        for (int i = 0; i < _funkos.Length; i++) {
            if (_funkos[i] != null) {
                _funkos[i] = newFunko;
            }
        }
        return newFunko;
    }

    /// <summary>
    /// Actualiza un objeto FunkoPop ya existente.
    /// </summary>
    /// <param name="funko">Objeto a actualizar.</param>
    /// <returns>Devuelve el objeto en caso de encontralo y nulo en caso contrario.</returns>
    private FunkoPop? Update(FunkoPop funko) {
        for (int i = 0; i < _funkos.Length; i++) {
            if (funko.Id == _funkos[i]?.Id) {
                _funkos[i] = funko;
                return funko;
            }
        }
        return null;
    }

    /// <summary>
    ///  Elimina un FunkoPop del alamcenamiento.
    /// </summary>
    /// <param name="id"> Id del FunkoPop a eliminar.</param>
    /// <returns>Devuelve la celda del objeto a nula. O nulo directamente.</returns>
    private FunkoPop? Delete(int id) {
        for(int i = 0; i < _funkos.Length; i++) {
            if (_funkos[i]?.Id == id) {
                _funkos[i] = null;
                Disminuir();
                return _funkos[i];
            }
        }
        return null;
    }

    /// <summary>
    ///  Busca un FunkoPop según el id en el almacenamiento.
    /// </summary>
    /// <param name="id"> Id del objeto a buscar.</param>
    /// <returns>Devuelve el objeto en caso de ser encontrado y nulo en caso contrario.</returns>
    private FunkoPop? GetById(int id) {
        foreach (var funko in _funkos) {
            if (funko?.Id == id) {
                return funko;
            }
        }
        return null;
    }
}