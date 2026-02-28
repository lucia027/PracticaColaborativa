using El_registro_de_Jinshi.Models;
using El_registro_de_Jinshi.Repository;
using El_registro_de_Jinshi.Validator;

namespace El_registro_de_Jinshi.Service;

public class PersonajeService(
    BoticariaValidator boticariaValidator, 
    SirvientaValidator sirvientaValidator,
    NobleValidator nobleValidator,
    BoticariaRepository boticariaRepository,
    SirvientaRepository sirvientaRepository,
    NobleRepository nobleRepository) {

    public void Create(Personaje personaje) {
        if (personaje is Boticaria boticaria) {
            var boticariaValidada = boticariaValidator.Validate(boticaria);
            boticariaRepository.Create(boticariaValidada);
        }
        if (personaje is Sirvienta sirvienta) {
            var sirvientaValidada = sirvientaValidator.Validate(sirvienta);
            sirvientaRepository.Create(sirvientaValidada);
        }
        if (personaje is Noble noble) {
            var nobleValidado = nobleValidator.Validate(noble);
            nobleRepository.Create(nobleValidado);
        }
    }

    public void Update(Personaje personaje) {
        if (personaje is Boticaria boticaria) {
            try {
                boticariaRepository.GetById(boticaria.Id);
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            var boticariaValidada = boticariaValidator.Validate(boticaria);
            boticariaRepository.Update(boticariaValidada);
        }
        if (personaje is Sirvienta sirvienta) {
            try {
                sirvientaRepository.GetById(sirvienta.Id);
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            var sirvientaValidada = sirvientaValidator.Validate(sirvienta);
            sirvientaRepository.Update(sirvientaValidada);
        }
        if (personaje is Noble noble) {
            try {
                nobleRepository.GetById(noble.Id);
            } catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
            var nobleValidado = nobleValidator.Validate(noble);
            nobleRepository.Update(nobleValidado);
        }
    }
    
    
}