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
    private FunkoPop[] _funkos = FunkoPopFactory.DatosBase();
    
    private int NewId() {
        Log.Debug("Generando nuevo id..");
        return _contadorId++;
    }

    private void Aumentar() {
    }
    
    private void Disminuir() {
    }

    private FunkoPop Save(FunkoPop funko) {
        
    }

    private FunkoPop Update(FunkoPop funko) {
        
    }

    private FunkoPop? Delete(int id) {
    }

    private FunkoPop? GetById(int id) {
    }
}