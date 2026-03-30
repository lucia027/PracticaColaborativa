using System.Text.RegularExpressions;
using ITV.Enums;
using ITV.Models;
using ITV.Validator.Common;

namespace ITV.Validator;

public class VehiculoValidator : IValidator<Vehiculo> {
    
    /// <inheritdoc cref="IValidator.Validate" />
    public IEnumerable<string> Validate(Vehiculo entity) {
        
        var regexMatricula = @"^[0-9]{4}[BCDFGHJKLMNPRSTVWXYZ]{3}$";
        var regexDni = @"^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKE]$";
        
        var errores = new List<string>();

        if (Regex.IsMatch(entity.Matricula, regexMatricula)) {
            errores.Add("Error - La matricula proporcionada no cumple el formato.");
        }
        if (string.IsNullOrEmpty(entity.Marca)) {
            errores.Add("Error - La marca es nula o esta vacia.");
        }
        if (string.IsNullOrEmpty(entity.Modelo)) {
            errores.Add("Error - El modelo es nulo o esta vacio.");
        }
        if (entity.Cilindrada < 0) {
            errores.Add("Error - La cilindrada no puede ser negativa.");
        }
        if (!Enum.IsDefined(typeof(Motor), entity.Motor)) {
            errores.Add("Error - El tipo de motor no es valido.");
        }
        if (Regex.IsMatch(entity.DniDueño, regexDni) || ComprobarDniValido(entity.DniDueño)) {
            errores.Add("Error - El dni del dueño no cumple el formato.");
        }

        return errores;
    }

    private bool ComprobarDniValido(string dni) {
        char[] letrasPermitidas = ['T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'];

        try {
            string numeros = dni.Substring(0, 8);
            int numerosDni = int.Parse(numeros);
            
            char letraProporcionada = char.ToUpper(dni[8]);

            int indiceLetra = numerosDni % 23;

            char letraCorrecta = letrasPermitidas[indiceLetra];

            return letraProporcionada == letraCorrecta;
        }
        catch (Exception e) {
            return false;
        }
    }
}