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
    private static FunkoPopRepository? _instance;
    private int _contadorId = Configuracion.DatosDefecto;
    private int _totalFunkoPops = Configuracion.DatosDefecto;
    private FunkoPop?[] _funkos = FunkoPopFactory.DatosBase();

    private int NewId() {
        Log.Debug("Generando nuevo id..");
        return _contadorId++;
    }

    /// <summary>
    ///  Guarda los datos base en el almacenamiento.
    /// </summary>
    public void IniciarDatosBase() {
        var datosBase = FunkoPopFactory.DatosBase();
        foreach (var funko in datosBase) {
            Save(funko!);
        }
    }

    public static FunkoPopRepository GetInstance() {
        return _instance ??= new FunkoPopRepository();
    }

    private void Aumentar() {
    }

    private void Disminuir() {
    }

    /// <summary>
    ///  Limpia el vector de FunkoPops de posibles nulos.
    /// </summary>
    /// <returns> Array de FunkoPops</returns>
    private FunkoPop[] AlmacenamientoCompacto() {
        var vectorCompacto = new FunkoPop[_totalFunkoPops];
        var indexVector = 0;

        foreach (var funko in _funkos)
        {
            if (funko != null)
            {
                vectorCompacto[indexVector] = funko!;
                indexVector++;
            }
        }

        return vectorCompacto;
    }

    /// <summary>
    ///  Almacena un nuevo FunkoPop.
    /// </summary>
    /// <param name="funko">Objeto para almacenar</param>
    /// <returns>Devuelve el objeto</returns>
    public FunkoPop Save(FunkoPop funko) {
        var newFunko = funko with { Id = NewId() };
        Aumentar();
        for (int i = 0; i < _funkos.Length; i++)
        {
            if (_funkos[i] != null)
            {
                _funkos[i] = newFunko;
                _totalFunkoPops++;
            }
        }

        return newFunko;
    }

    /// <summary>
    /// Actualiza un objeto FunkoPop ya existente.
    /// </summary>
    /// <param name="funko">Objeto a actualizar.</param>
    /// <returns>Devuelve el objeto en caso de encontrarlo y nulo en caso contrario.</returns>
    public FunkoPop? Update(FunkoPop funko) {
        for (int i = 0; i < _funkos.Length; i++)
        {
            if (funko.Id == _funkos[i]?.Id)
            {
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
    public FunkoPop? Delete(int id) {
        for (int i = 0; i < _funkos.Length; i++)
        {
            if (_funkos[i]?.Id == id)
            {
                _funkos[i] = null;
                Disminuir();
                _totalFunkoPops--;
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
    public FunkoPop? GetById(int id) {
        foreach (var funko in _funkos)
        {
            if (funko?.Id == id)
            {
                return funko;
            }
        }

        return null;
    }

    /// <summary>
    ///  Devuelve el almacenamiento de todos los FunkoPops.
    /// </summary>
    /// <returns>Array de FunkoPops</returns>
    public FunkoPop[] GetAll() {
        return AlmacenamientoCompacto();
    }
}