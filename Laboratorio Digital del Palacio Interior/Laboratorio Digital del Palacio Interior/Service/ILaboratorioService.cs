using Laboratorio_Digital_del_Palacio_Interior.Models;

namespace Laboratorio_Digital_del_Palacio_Interior.Service;

/// <summary>
/// Contrato para el servicio que gestiones las sustancias y los casos medicos.
/// </summary>
public interface ILaboratorioService {
    
    /// <summary>
    ///  Obtiene todas las sustancias.
    /// </summary>
    /// <returns>Enumerable de sustancias.</returns>
    IEnumerable<Sustancia> GetAllSustancia();
    
    /// <summary>
    /// Obtiene una sustancia buscando por su ID.
    /// </summary>
    /// <param name="id">Id de la sustancia.</param>
    /// <returns>Sustancia encontrada.</returns>
    Sustancia GetByIdSustancia(int id);
    
    /// <summary>
    /// Crea una nueva sustancia comprobando sus validaciones.
    /// </summary>
    /// <param name="sustancia">Sustancia a crear.</param>
    /// <returns>Sustancia creada.</returns>
    Sustancia CreateSustancia(Sustancia sustancia);
    
    /// <summary>
    /// Actualiza una sustancia ya existente comprobando la validacion.
    /// </summary>
    /// <param name="id">Id de la sustancia a actualizar.</param>
    /// <param name="sustancia">Sustancia actualizada.</param>
    /// <returns>Sustancia actual.</returns>
    Sustancia UpdateSustancia(int id, Sustancia sustancia);
    
    /// <summary>
    /// Elimina una sustancia ya existente.
    /// </summary>
    /// <param name="id">Id de la sustancia.</param>
    /// <returns>Sustancia eliminada.</returns>
    Sustancia DeleteSustancia(int id);
    
    /// <summary>
    ///  Obtiene todos los casos medicos.
    /// </summary>
    /// <returns>Enumerable de caso médico.</returns>
    IEnumerable<CasoMedico> GetAllCasoMedico();
    
    /// <summary>
    /// Obtiene un caso médico buscando por su ID.
    /// </summary>
    /// <param name="id">Id del caso médico.</param>
    /// <returns>Caso médico encontrado.</returns>
    CasoMedico GetByIdCasoMedico(int id);
    
    /// <summary>
    /// Crea un nuevo caso médico comprobando sus validaciones.
    /// </summary>
    /// <param name="casoMedico">Caso medico a crear.</param>
    /// <returns>Caso médico creado.</returns>
    CasoMedico CreateCasoMedico(CasoMedico casoMedico);
    
    /// <summary>
    /// Actualiza un caso médico ya existente comprobando la validacion.
    /// </summary>
    /// <param name="id">Id del caso médico a actualizar.</param>
    /// <param name="casoMedico">Caso médico actualizado.</param>
    /// <returns>Caso médico actual.</returns>
    CasoMedico UpdateCasoMedico(int id, CasoMedico casoMedico);
    
    /// <summary>
    /// Marca un caso médico ya existente como finalizado.
    /// </summary>
    /// <param name="id">Id del caso médico.</param>
    /// <returns>Caso médico eliminado.</returns>
    CasoMedico DeleteCasoMedico(int id);

    
    /// <summary>
    /// Obtiene un informe general sobre sustancias y casos médicos.
    /// </summary>
    /// <returns>Informe creado.</returns>
    Informe GetInforme();

    int ImportarDatosSustancias();
    
    int ExportarDatosSustancias();

    int ImportarDatosCasosMedicos();
    
    int ExportarDatosCasosMedicos();
}