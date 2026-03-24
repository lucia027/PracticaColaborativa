using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Laboratorio_Digital_del_Palacio_Interior.Config;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Models;
using Laboratorio_Digital_del_Palacio_Interior.Repository;
using Laboratorio_Digital_del_Palacio_Interior.Storage.Common;
using Laboratorio_Digital_del_Palacio_Interior.Validator.Common;

namespace Laboratorio_Digital_del_Palacio_Interior.Service;

/// <summary>
/// Servicio general para la gestion de sustancias y casos médicos.
/// </summary>
public class LaboratorioService(
    ISustanciasRepository sustanciasRepository,
    ICasosMedicosRepository casosMedicosRepository,
    IValidator<Sustancia> afrodisiacosValidator,
    IValidator<Sustancia> medicinaValidator,
    IValidator<Sustancia> venenoValidator,
    IValidator<CasoMedico> casosMedicosValidator,
    IStorage<Sustancia> sustanciaStorage,
    IStorage<CasoMedico> casoMedicoStorage
    ) : ILaboratorioService{
    
    /// <inheritdoc cref="ILaboratorioService.GetAllSustancia"/>
    public IEnumerable<Sustancia> GetAllSustancia() {
        return sustanciasRepository.GetAll();
    }
    
    /// <inheritdoc cref="ILaboratorioService.GetByIdSustancia"/>
    public Sustancia GetByIdSustancia(int id) {
        return sustanciasRepository.GetById(id) ?? throw new KeyNotFoundException($"No se encuentra el id: {id}.");
    }

    /// <inheritdoc cref="ILaboratorioService.CreateSustancia"/>
    public Sustancia CreateSustancia(Sustancia sustancia) {
        ValidateSustancias(sustancia);
        return sustanciasRepository.Create(sustancia) ?? throw new InvalidOperationException("La sustancia ya existe.");
    }

    /// <inheritdoc cref="ILaboratorioService.UpdateSustancia"/>
    public Sustancia UpdateSustancia(int id, Sustancia sustancia) {
        ValidateSustancias(sustancia);
        return sustanciasRepository.Update(id, sustancia) ?? throw new InvalidOperationException("La sustancia a actualizar no existe.");
    }

    /// <inheritdoc cref="ILaboratorioService.DeleteSustancia"/>
    public Sustancia DeleteSustancia(int id) {
        return sustanciasRepository.Delete(id) ?? throw new InvalidOperationException("La sustancia a eliminar no existe.");
    }

    /// <inheritdoc cref="ILaboratorioService.GetAllCasoMedico"/>
    public IEnumerable<CasoMedico> GetAllCasoMedico() {
        return casosMedicosRepository.GetAll();
    }

    /// <inheritdoc cref="ILaboratorioService.GetByIdCasoMedico"/>
    public CasoMedico GetByIdCasoMedico(int id) {
        return casosMedicosRepository.GetById(id) ?? throw new KeyNotFoundException($"No se encuentra el id: {id}.");
    }

    /// <inheritdoc cref="ILaboratorioService.CreateCasoMedico"/>
    public CasoMedico CreateCasoMedico(CasoMedico casoMedico) {
        ValidateCasosMedico(casoMedico);
        return casosMedicosRepository.Create(casoMedico) ?? throw new InvalidOperationException("El caso médico ya existe.");
    }

    /// <inheritdoc cref="ILaboratorioService.UpdateCasoMedico"/>
    public CasoMedico UpdateCasoMedico(int id, CasoMedico casoMedico) {
        ValidateCasosMedico(casoMedico);
        return casosMedicosRepository.Update(id, casoMedico) ?? throw new InvalidOperationException("El caso médico  a actualizar no existe.");
    }

    /// <inheritdoc cref="ILaboratorioService.DeleteCasoMedico"/>
    public CasoMedico DeleteCasoMedico(int id) {
        return casosMedicosRepository.Delete(id) ?? throw new InvalidOperationException("El caso médico a eliminar no existe o ya esta resuelto.");
    }

    /// <inheritdoc cref="ILaboratorioService.GetInforme"/>
    public Informe GetInforme() {
        var almacenCasosMedicos = casosMedicosRepository.GetAll();
        var almacenSustancias = sustanciasRepository.GetAll();

        var venenoPeligroso = almacenSustancias.MaxBy(v => v.Precio).Nombre;
        var casosMedicosResueltos = almacenCasosMedicos.Count(c => c.Estado == EstadoCasoMedico.Resuelto);
        var casosMedicosVenenos = almacenCasosMedicos
            .Where(c => c.CausaSospecha == CausaSospecha.Veneno)
            .Select(c => new { c.Id, c.CausaSospecha })
            .ToDictionary();
        var afrodisiacoIntensidad = almacenSustancias.OfType<Afrodisiaco>().MaxBy(a => a.IntensidadEfecto).Nombre;

        Informe informe = new Informe(venenoPeligroso, casosMedicosResueltos, casosMedicosVenenos, afrodisiacoIntensidad);
        return informe;
    }

    public int ImportarDatosSustancias() {
        try {
            var sustancias = sustanciaStorage.Cargar(Configuracion.SustanciaFile);
            sustanciasRepository.DeleteAll();
            var contador = 0;

            foreach (var sustancia in sustancias) {
                CreateSustancia(sustancia);
                contador++;
            }

            return contador;
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public int ExportarDatosSustancias() {
        try {
            var sustancias = sustanciasRepository.GetAll();
            var numSustancias = sustancias.Count();
            
            sustanciaStorage.Salvar(sustancias, Configuracion.SustanciaFile);
            return numSustancias;
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public int ImportarDatosCasosMedicos() {
        try {
            var casosMedicos = casoMedicoStorage.Cargar(Configuracion.CasosMedicosFile);
            casosMedicosRepository.DeleteAll();
            var contador = 0;

            foreach (var casoMedico in casosMedicos) {
                CreateCasoMedico(casoMedico);
                contador++;
            }

            return contador;
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public int ExportarDatosCasosMedicos() {
        try {
            var casosMedicos = casosMedicosRepository.GetAll();
            var numCasosMedicos = casosMedicos.Count();
            
            casoMedicoStorage.Salvar(casosMedicos, Configuracion.CasosMedicosFile);
            return numCasosMedicos;
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    private void ValidateSustancias(Sustancia sustancia) {
        var errores = sustancia switch {
            Medicina => medicinaValidator.Validate(sustancia),
            Veneno => venenoValidator.Validate(sustancia),
            Afrodisiaco => afrodisiacosValidator.Validate(sustancia),
            _ => ["El tipo de entidad no se puede validar."]
        };

        if (errores.Any()) {
            throw new ValidationException("Hay errores encontrados en la validación.");
        }
    }

    private void ValidateCasosMedico(CasoMedico casoMedico) {
        var errores = casosMedicosValidator.Validate(casoMedico);
        
        if (errores.Any()) {
            throw new ValidationException("Hay errores encontrados en la validación.");
        }
    }
}