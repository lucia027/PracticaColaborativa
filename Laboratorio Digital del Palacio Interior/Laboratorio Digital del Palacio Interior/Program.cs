using System.Text;
using System.Text.RegularExpressions;
using Laboratorio_Digital_del_Palacio_Interior.Enums;
using Laboratorio_Digital_del_Palacio_Interior.Factory;
using Laboratorio_Digital_del_Palacio_Interior.Models;
using Laboratorio_Digital_del_Palacio_Interior.Repository;
using Laboratorio_Digital_del_Palacio_Interior.Service;
using Laboratorio_Digital_del_Palacio_Interior.Storage;
using Laboratorio_Digital_del_Palacio_Interior.Validator;
using Serilog;
using static System.Console;

// ====================================================================
// CONFIGURACIÓN E INYECCIÓN DE DEPENDENCIAS
// ====================================================================

Title = "🌸 Laboratorio Digital del Palacio Interior 🌸";
OutputEncoding = Encoding.UTF8;
Clear();

Main();

Log.CloseAndFlush();
WriteLine("Pulse cualquier tecla para salir del programa.👋🏻");
ReadKey();
return;

// --------------------------------------------------------------------
//                          Flujo principal
// --------------------------------------------------------------------

void Main() {
    ILaboratorioService service = new LaboratorioService(
        SustanciasRepository.Instance,
        CasosMedicosRepository.Instance,
        new AfrodisiacoValidator(), 
        new MedicinaValidator(),
        new VenenoValidator(),
        new CasoMedicoValidator(),
        new SustanciaJsonStorage(), 
        new CasosMedicosJsonStorage()
    );
    
    SustanciaFactory.Seed().ToList().ForEach(s => service.CreateSustancia(s));
    CasosMedicosFactory.Seed().ToList().ForEach(c => service.CreateCasoMedico(c));

    string opcion;
    const string regexMenu = @"^([0-9]|1[0-3])$";
    
    do {
        MostrarMenu();
        opcion = LeerCadenaValidada("🔬 Elige una opción del menú valida: ", regexMenu, "Opción no válida (0-13).");

        switch (opcion) {
            case "1": ListarSustancias(service); break;
            case "2": BuscarSustancia(service); break;
            case "3": AnadirNuevaSustancia(service); break;
            case "4": ActualizarSustancia(service); break;
            case "5": EliminarSustancia(service); break;
            case "6": ListarCasosMedicos(service); break;
            case "7": BuscarCasoMedico(service); break;
            case "8": AbrirCasoMedico(service); break;
            case "9": ActualizarCasoMedico(service); break;
            case "10": FinalizarCasoMedico(service); break;
            case "11": MostrarInformeEstadistico(service); break;
            case "12": ImportarDatosLaboratorio(service); break;
            case "13": ExportarDatosLaboratorio(service); break;
            case "0": WriteLine("Cerrando laboratorio. ¡Buen trabajo, boticaria! 👋🏻"); break;
        }

        if (opcion != "0") {
            WriteLine("\n Presiona una tecla para salir.👋🏻");
            ReadKey();
            Clear();
        }
    } while (opcion != "0");
}

void MostrarMenu() {
    WriteLine();
    WriteLine("-----------------------------------------------");
    WriteLine("🌸 Laboratorio Digital Del Palacio Interior 🌸");
    WriteLine("-----------------------------------------------");
    WriteLine();
    WriteLine("🌿 GESTIÓN DE SUSTANCIAS ");
    WriteLine("1. 🌱 Listar Sustancias");
    WriteLine("2. 🔍 Buscar Sustancia");
    WriteLine("3. ➕ Registrar Nueva Sustancia");
    WriteLine("4. 📝 Modificar Sustancia Existente");
    WriteLine("5. 🗑️  Eliminar Sustancia del Registro");
    WriteLine();
    WriteLine("🩺 GESTIÓN DE CASOS MÉDICOS ");
    WriteLine("6. 📜 Listar Casos Médicos");
    WriteLine("7. 🔍 Buscar Caso Médico Específico");
    WriteLine("8. ➕ Registrar Nuevo Caso Médico");
    WriteLine("9. 📝 Modificar Caso Médico  Existente");
    WriteLine("10. ❌ Terminar investigacion Caso Médico  Existente");
    WriteLine("11. 📊 Informe");
    WriteLine();
    WriteLine("💾 ALMACENAMIENTO");
    WriteLine("12. 📥 Importar desde JSON");
    WriteLine("13. 📤 Exportar a JSON");
    WriteLine();
    WriteLine("0. 🔚 SALIR");
    WriteLine("-----------------------------------------------");
    WriteLine();
}


//--------------------------------------------------------------------
//                      Funciones de sustancias.
//--------------------------------------------------------------------

void ListarSustancias(ILaboratorioService service) {
    WriteLine();
    WriteLine("💊 INVENTARIO COMPLETO DE SUSTANCIAS");
    var sustancias = service.GetAllSustancia();
    var linea = new string('─', 110);
    WriteLine(linea);
    WriteLine($"{"ID", -5} | {"Nombre", -40} | {"Precio", -10} | {"Peligro", -10} | {"Disponibilidad", -15} | {"Tipo"}");
    WriteLine(linea);
    foreach (var sus in sustancias) {
        if (sus is Veneno v) {
            WriteLine($"{v.Id, -5} | {v.Nombre, -40} | {v.Precio, -10} | {v.NivelPeligro, -10} | {v.Disponibilidad, -15} | {"Veneno"}");
        }
        if (sus is Medicina m) {
            WriteLine($"{m.Id, -5} | {m.Nombre, -40} | {m.Precio, -10} | {m.NivelPeligro, -10} | {m.Disponibilidad, -15} | {"Medicina"}");
        }
        if (sus is Afrodisiaco a) {
            WriteLine($"{a.Id, -5} | {a.Nombre, -40} | {a.Precio, -10} | {a.NivelPeligro, -10} | {a.Disponibilidad, -15} | {"Afrodisiaco"}");
        }    
    }
    WriteLine();
}

Sustancia? BuscarSustancia(ILaboratorioService service) {
    WriteLine();
    var id = int.Parse(LeerCadenaValidada("🌱 Id de la sustancia: ", @"^\d+$", "Debe ser un número."));
    Sustancia? sus = null;
    try {
        sus = service.GetByIdSustancia(id);
        ImprimirFichaSustancia(sus);
    } catch (Exception ex) {
        WriteLine($"❌ ERROR: {ex.Message}");
    }
    WriteLine();
    return sus;
}

void AnadirNuevaSustancia(ILaboratorioService service) {
    WriteLine();
    WriteLine("➕ DAR DE ALTA UNA NUEVA SUSTANCIA");
    
    //Seleccionamos el tipo de la sustancia nueva.
    WriteLine("Seleccione el tipo: 1.Veneno, 2.Medicina, 3.Afrodisiaco");
    var tipo = LeerCadenaValidada("🎯 Tipo: ", "^[1-3]$", "Seleccione 1, 2 o 3.");

    //Datos comunes a todas las sustancias
    var nombre = LeerCadenaValidada("🍃 Nombre: ", @".+", "No puede estar vacío.");
    var descripcion = LeerCadenaValidada("📝 Descripcion: ", @".+", "No puede estar vacío.");
    var precio = decimal.Parse(LeerCadenaValidada("💰 Precio (ej: 12,50): ", @"^\d+([.,]\d{1,2})?$", "Formato numérico incorrecto."));
    var disponibilidad = (Disponibilidad)int.Parse(LeerCadenaValidada("🗝️ Disponibilidad: 1.Comun, 2.Rara, 3.Muy rara  ", "^[1-3]$", "Debe ser entre 1 y 3."));
    var peligro = (Peligro)int.Parse(LeerCadenaValidada("⚠️ Peligro: 1.Nulo, 2.Bajo, 3.Medio, 4.Alto ", "^[1-4]$", "Debe ser entre 1 y 4."));

    //Datos especificos para cada tipo.
    Sustancia nueva = new Medicina();
    switch (tipo) {
        case "1": // VENENO
            var viaDeAdministracion = (ViaDeAdministracion)int.Parse(LeerCadenaValidada("🧪 Vía de Administracion: 1.Oral, 2.Contacto, 3.Inhalación, 4.Inyección ", "^[1-4]$", "1-4."));
            var tiempo = int.Parse(LeerCadenaValidada("🕐 Tiempo aparición (min): ", @"^\d+$", "Número entero."));
            var antidoto = AsignarAntidoto(service);
            var gradoToxicidad = int.Parse(LeerCadenaValidada("🧬 Grado Toxicidad (1-10): ", "^([1-9]|10)$", "1-10."));
            
            nueva = new Veneno { Nombre = nombre, Descripcion = descripcion, Precio = precio, Disponibilidad = disponibilidad, NivelPeligro = peligro, ViaDeAdministracion = viaDeAdministracion, Antidoto = antidoto, TiempoAparicion = tiempo,  GradoToxicidad = gradoToxicidad};
            break;

        case "2": // MEDICINA
            var sintoma = LeerCadenaValidada("🤧 Síntoma que trata: ", @".+", "No puede estar vacío.");
            var dosisRecomendada = double.Parse(LeerCadenaValidada("💊 Dosis recomendada (ml/mg): ", @"^\d+([.,]\d{1,2})?$", "Número válido."));
            var efectos = LeerCadenaValidada("🧫 Efectos: ", @".+", "No puede estar vacío.");
            var tiempoEfecto = int.Parse(LeerCadenaValidada("🕐 Tiempo aparición (min): ", @"^\d+$", "Número entero."));

            nueva = new Medicina { Nombre = nombre, Descripcion = descripcion, Precio = precio, Disponibilidad = disponibilidad, NivelPeligro = peligro, Sintoma = sintoma, DosisRecomendada = dosisRecomendada, EfectosSecundarios = efectos, TiempoEfecto = tiempoEfecto};
            break;

        case "3": // AFRODISIACO
            var intensidadEfecto = int.Parse(LeerCadenaValidada("🩹 Intensidad (1-10): ", "^([1-9]|10)$", "1-10."));
            var duracion = int.Parse(LeerCadenaValidada("🕐 Tiempo de efecto (min): ", @"^\d+$", "Número entero."));
            var contraIndicaciones = LeerCadenaValidada("🚫 Contraindicaciones: ", @"3", "No puede estar vacío.");
            var riesgoUso = LeerCadenaValidada("💀 Riesgo de uso: ", @"3", "No puede estar vacío.");


            nueva = new Afrodisiaco { Nombre = nombre, Descripcion = descripcion, Precio = precio, Disponibilidad = disponibilidad, NivelPeligro = peligro, IntensidadEfecto = intensidadEfecto, Duracion = duracion, ContraIndicaciones = contraIndicaciones, RiegosUso = riesgoUso };
            break;
        
        default:
            WriteLine($"❌ ERROR, tipo invalido.");
            break;
    }

    // 4. Intento de creación en el servicio
    try {
        service.CreateSustancia(nueva);
        WriteLine($"✅ '{nueva.Nombre}' se ha registrado correctamente en el inventario.");
    } catch (Exception ex) {
        WriteLine($"❌ ERROR DE VALIDACIÓN: {ex.Message}");
    }
    WriteLine();
}

void ActualizarSustancia(ILaboratorioService service) {
    WriteLine();
    WriteLine("📝 MODIFICAR SUSTANCIA");
    var id = int.Parse(LeerCadenaValidada("🌱 Id de la sustancia a editar: ", @"^\d+$", "Id no válido."));
    try {
        var sustanciaAntigua = service.GetByIdSustancia(id);
        Sustancia sustanciaNueva = new Medicina();
        ImprimirFichaSustancia(sustanciaAntigua);

        var nombre = LeerCadenaValidada("🍃 Nombre: ", @".+", "No puede estar vacío.");
        var descripcion = LeerCadenaValidada("📝 Descripcion: ", @".+", "No puede estar vacío.");
        var precio = decimal.Parse(LeerCadenaValidada("💰 Precio (ej: 12,50): ", @"^\d+([.,]\d{1,2})?$", "Formato numérico incorrecto."));
        var disponibilidad = (Disponibilidad)int.Parse(LeerCadenaValidada("🗝️ Disponibilidad: 1.Comun, 2.Rara, 3.Muy rara  ", "^[1-3]$", "Debe ser entre 1 y 3."));
        var peligro = (Peligro)int.Parse(LeerCadenaValidada("⚠️ Peligro: 1.Nulo, 2.Bajo, 3.Medio, 4.Alto ", "^[1-4]$", "Debe ser entre 1 y 4."));

        if (sustanciaAntigua is Veneno) {
            var viaDeAdministracion = (ViaDeAdministracion)int.Parse(LeerCadenaValidada("🧪 Vía de Administracion: 1.Oral, 2.Contacto, 3.Inhalación, 4.Inyección ", "^[1-4]$", "1-4."));
            var tiempo = int.Parse(LeerCadenaValidada("🕐 Tiempo aparición (min): ", @"^\d+$", "Número entero."));
            var antidoto = AsignarAntidoto(service);
            var gradoToxicidad = int.Parse(LeerCadenaValidada("🧬 Grado Toxicidad (1-10): ", "^([1-9]|10)$", "1-10."));
            
            sustanciaNueva = new Veneno { Nombre = nombre, Descripcion = descripcion, Precio = precio, Disponibilidad = disponibilidad, NivelPeligro = peligro, ViaDeAdministracion = viaDeAdministracion, Antidoto = antidoto, TiempoAparicion = tiempo,  GradoToxicidad = gradoToxicidad};
        }
        if (sustanciaAntigua is Medicina) {
            var sintoma = LeerCadenaValidada("🤧 Síntoma que trata: ", @".+", "No puede estar vacío.");
            var dosisRecomendada = double.Parse(LeerCadenaValidada("💊 Dosis recomendada (ml/mg): ", @"^\d+([.,]\d{1,2})?$", "Número válido."));
            var efectos = LeerCadenaValidada("🧫 Efectos: ", @".+", "No puede estar vacío.");
            var tiempoEfecto = int.Parse(LeerCadenaValidada("🕐 Tiempo aparición (min): ", @"^\d+$", "Número entero."));

            sustanciaNueva = new Medicina { Nombre = nombre, Descripcion = descripcion, Precio = precio, Disponibilidad = disponibilidad, NivelPeligro = peligro, Sintoma = sintoma, DosisRecomendada = dosisRecomendada, EfectosSecundarios = efectos, TiempoEfecto = tiempoEfecto};
        }
        if (sustanciaAntigua is Afrodisiaco) {
            var intensidadEfecto = int.Parse(LeerCadenaValidada("🩹 Intensidad (1-10): ", "^([1-9]|10)$", "1-10."));
            var duracion = int.Parse(LeerCadenaValidada("🕐 Tiempo de efecto (min): ", @"^\d+$", "Número entero."));
            var contraIndicaciones = LeerCadenaValidada("🚫 Contraindicaciones: ", @"3", "No puede estar vacío.");
            var riesgoUso = LeerCadenaValidada("💀 Riesgo de uso: ", @"3", "No puede estar vacío.");
            
            sustanciaNueva = new Afrodisiaco { Nombre = nombre, Descripcion = descripcion, Precio = precio, Disponibilidad = disponibilidad, NivelPeligro = peligro, IntensidadEfecto = intensidadEfecto, Duracion = duracion, ContraIndicaciones = contraIndicaciones, RiegosUso = riesgoUso };
        }

        service.UpdateSustancia(id, sustanciaNueva);
        WriteLine("✅ Registro actualizado.");
    } catch (Exception ex) { WriteLine($"❌ ERROR: {ex.Message}"); }
    WriteLine();
}

void EliminarSustancia(ILaboratorioService service) {
    WriteLine();
    var id = int.Parse(LeerCadenaValidada("🗑️ Id de la sustancia a eliminar: ", @"^\d+$", "Id no válido."));

    try {
        var sus = service.GetByIdSustancia(id);
        if (PedirConfirmacion($"¿Eliminar {sus.Nombre} permanentemente?")) {
            service.DeleteSustancia(id);
            WriteLine("✅ Eliminado.");
        }
    } catch (Exception ex) { WriteLine($"❌ ERROR: {ex.Message}"); }
    WriteLine();
}

void ImprimirFichaSustancia(Sustancia s) {
    WriteLine();
    WriteLine("-----------------------------------------------");
    WriteLine($"🌿 Id: {s.Id}");
    WriteLine($"🍃 Nombre: {s.Nombre}");
    WriteLine($"📝 Descripcion: {s.Descripcion}");
    WriteLine($"💰 Precio: {s.Precio:C2}");
    WriteLine($"🗝️Disponibilidad: {s.Disponibilidad}");
    WriteLine($"⚠️ Peligro: {s.NivelPeligro}");
    
    if (s is Veneno v) {
        var nombreAntidoto = (v.Antidoto?.Nombre != null) ? v.Antidoto.Nombre : "No hay antidoto." ;
        WriteLine($"🧪 Via de Administracion: {v.ViaDeAdministracion}");
        WriteLine($"🕐 Tiempo de aparicion: {v.TiempoAparicion}");
        WriteLine($"🌿 Nombre del Antidoto: {nombreAntidoto}");
        WriteLine($"☠️ Toxicidad: {v.GradoToxicidad}");
        WriteLine($"🧬 Probabilidad de supervivencia: {v.ProbabilidadSupervivencia}%");
    }
    if (s is Medicina m) {
        WriteLine($"🤧 Sintomas: {m.Sintoma}");
        WriteLine($"💊 Dosis recomendada: {m.DosisRecomendada}");
        WriteLine($"🧫 Efectos secundarios: {m.EfectosSecundarios}");
        WriteLine($"🕐 Tiempo de efecto: {m.TiempoEfecto}%");
    }
    if (s is Afrodisiaco a) {
        WriteLine($"🩹 Intensidad del efecto: {a.IntensidadEfecto}");
        WriteLine($"🕐 Duracion: {a.Duracion}");
        WriteLine($"🚫 Contraindicaciones: {a.ContraIndicaciones}");
        WriteLine($"💀 Riesgo de uso: {a.RiegosUso}%");
    }
    WriteLine("-----------------------------------------------");
    WriteLine();
}

Medicina? AsignarAntidoto(ILaboratorioService service) {
    WriteLine();
    WriteLine("☠️ Antidoto: ");
    WriteLine("‼️ Debes buscar en el almacen la medicina: ");
    var medicina = BuscarSustancia(service);
    if (medicina is Medicina m) {
        return m;
    }
    WriteLine();
    return null;
}


//--------------------------------------------------------------------
//                    Funciones de casos médicos.
//--------------------------------------------------------------------

void ListarCasosMedicos(ILaboratorioService service) {
    WriteLine();
    WriteLine("📜 HISTORIAL DE CASOS MÉDICO DEL PALACIO");
    var casosMedico = service.GetAllCasoMedico();
    var linea = new string('─', 80);
    WriteLine(linea);
    WriteLine($"{"ID",-5} | {"Fecha",-20} | {"Estado",-15} | {"Gravedad",-12} | {"Sospecha"}");
    WriteLine(linea);
    foreach (var caso in casosMedico) {
        WriteLine($"{caso.Id,-5} | {caso.FechaInicio, -20} | {caso.Estado,-15} | {caso.Gravedad,-12} | {caso.CausaSospecha}");
    }
    WriteLine();
}

void BuscarCasoMedico(ILaboratorioService service) {
    WriteLine();
    var id = int.Parse(LeerCadenaValidada("🧾 Id del caso médico: ", @"^\d+$", "Debe ser un número."));
    try {
        var caso = service.GetByIdCasoMedico(id);
        ImprimirFichaCaso(caso);
    } catch (Exception ex) {
        WriteLine($"❌ ERROR: {ex.Message}");
    }
    WriteLine();
}

void AbrirCasoMedico(ILaboratorioService service) {
    WriteLine();
    WriteLine("➕ AÑADIR CASO MEDICO");

    var sintomas = LeerCadenaValidada("🤒 Sintomas: ", @".+", "No puede estar vacío.");
    var gravedad = (Gravedad)int.Parse(LeerCadenaValidada("🧨 Gravedad: 1.Nulo, 2.Leve, 3.Moderada, 4.Grave ", "^[1-4]$", "Debe ser entre 1 y 4."));
    var causaSospecha = (CausaSospecha)int.Parse(LeerCadenaValidada("❓ Causa sospecha: 1.Enfermedad, 2.Veneno, 3.Desconocida", "^[1-3]$", "Debe ser entre 1 y 3."));
    var sustanciasSospechas = AsignarSustanciasSospechosas(service);
    var tratamientos = AsignarTratamientos(service);
    var estado = (EstadoCasoMedico)int.Parse(LeerCadenaValidada("📋 Estado: 1.Abierto, 2.Resuelto, 3.En Investigacion", "^[1-3]$", "Debe ser entre 1 y 3."));

    var nuevo = new CasoMedico { Sintomas = sintomas, Gravedad = gravedad, CausaSospecha = causaSospecha, SustanciasSospechosas = sustanciasSospechas, Tratamientos = tratamientos, Estado = estado};
    try {
        service.CreateCasoMedico(nuevo);
        WriteLine("✅ Caso abierto. Iniciando investigación...");
        ImprimirFichaCaso(nuevo);
    } catch (Exception ex) {
        WriteLine($"❌ ERROR: {ex.Message}");
    }
    WriteLine();
}

void ActualizarCasoMedico(ILaboratorioService service) {
    WriteLine();
    WriteLine("📝 MODIFICAR CASO MEDICO");
    var id = int.Parse(LeerCadenaValidada("📜 Id del caso médico a editar: ", @"^\d+$", "Id no válido."));

    try {
        var casoMedicoAntiguo = service.GetByIdCasoMedico(id);
        ImprimirFichaCaso(casoMedicoAntiguo);
        
        var sintomas = LeerCadenaValidada("🤒 Sintomas: ", @".+", "No puede estar vacío.");
        var gravedad = (Gravedad)int.Parse(LeerCadenaValidada("🧨 Gravedad: 1.Nulo, 2.Leve, 3.Moderada, 4.Grave ", "^[1-4]$", "Debe ser entre 1 y 4."));
        var causaSospecha = (CausaSospecha)int.Parse(LeerCadenaValidada("❓ Causa sospecha: 1.Enfermedad, 2.Veneno, 3.Desconocida", "^[1-3]$", "Debe ser entre 1 y 3."));
        var sustanciasSospechas = AsignarSustanciasSospechosas(service);
        var tratamientos = AsignarTratamientos(service);
        var estado = (EstadoCasoMedico)int.Parse(LeerCadenaValidada("📋 Estado: 1.Abierto, 2.Resuelto, 3.En Investigacion", "^[1-3]$", "Debe ser entre 1 y 3."));

        var casoMedicoNuevo = new CasoMedico { Sintomas = sintomas, Gravedad = gravedad, CausaSospecha = causaSospecha, SustanciasSospechosas = sustanciasSospechas, Tratamientos = tratamientos, Estado = estado};

        service.UpdateCasoMedico(id, casoMedicoNuevo);
        WriteLine("✅ Registro actualizado.");
    } catch (Exception ex) {
        WriteLine($"❌ ERROR: {ex.Message}");
    }
    WriteLine();
}

void FinalizarCasoMedico(ILaboratorioService service) {
    WriteLine();
    WriteLine("❌ FINALIZAR CASO MEDICO");
    var id = int.Parse(LeerCadenaValidada("📜 Id del caso médico a editar: ", @"^\d+$", "Id no válido."));

    try {
        var casoMedico = service.GetByIdCasoMedico(id);
        if (PedirConfirmacion($"¿Desea marcar como finalizado el caso medico con id: {casoMedico.Id}, permanentemente?")) {
            service.DeleteCasoMedico(id);
            WriteLine("✅ Marcado como finalizado..");
        }

    } catch (Exception ex) {
        WriteLine($"❌ ERROR: {ex.Message}");
    }
    WriteLine();
}

void ImprimirFichaCaso(CasoMedico caso) {
    var sustanciasSospechosas = (caso.SustanciasSospechosas != null)
        ? caso.SustanciasSospechosas.Select(v => v.Nombre).ToString()
        : "No hay sustancias sospechosas.";
    var tratamientos = (caso.Tratamientos != null)
        ? caso.Tratamientos.Select(m => m.Nombre).ToString()
        : "No hay tratamientos.";
    
    WriteLine();
    WriteLine("-----------------------------------------------");
    WriteLine($"📃 Id: {caso.Id}");
    WriteLine($"🤒 Sintomas: {caso.Sintomas}");
    WriteLine($"📅 Fecha de inicio: {caso.FechaInicio}");
    WriteLine($"🧨 Gravedad: {caso.Gravedad}");
    WriteLine($"❓ Causa de sospecha: {caso.CausaSospecha}");
    WriteLine($"🌿 Sustancias sospechosas: {sustanciasSospechosas}");
    WriteLine($"🛡️ Tratamientos: {tratamientos}");
    WriteLine($"📋 Estado: {caso.Estado}");
    WriteLine("-----------------------------------------------");
    WriteLine();
}

void MostrarInformeEstadistico(ILaboratorioService service) {
    var informe = service.GetInforme();
    WriteLine("📊 RESUMEN DE ACTIVIDAD");
    WriteLine("-----------------------------------------------");
    WriteLine($"🔹Casos Resueltos:      {informe.CasosMedicosResueltos}");
    WriteLine($"🔹Sustancia recurrente: {informe.SutanciaMasUtilizada?.Nombre ?? "No hay."}");
    WriteLine($"🔹Medicina clave:       {informe.SustanciaMasEfectivaTratamiento?.Nombre ?? "No hay."}");
    WriteLine("-----------------------------------------------");
}

HashSet<Veneno>? AsignarSustanciasSospechosas(ILaboratorioService service) {
    WriteLine();
    WriteLine("🌿 Sustancias sospechosas: ");
    if (PedirConfirmacion("¿Quieres añadir venenos a la lista?")) {
        WriteLine("‼️ Debes buscar en el almacen los venenos que quieras añadir: ");
        var venenos = new HashSet<Veneno>();
        do {
            var veneno = BuscarSustancia(service);
            if (veneno is Veneno v) {
                venenos.Add(v);
            } else {
                WriteLine("La sustancia que has seleccionado no es un veneno valido.");
            }
        } while (PedirConfirmacion("¿Quieres añadir mas venenos?"));

        return venenos;
    }
    return null;
}

HashSet<Medicina>? AsignarTratamientos(ILaboratorioService service) {
    WriteLine();
    WriteLine("🛡️ Tratamientos: ");
    if (PedirConfirmacion("¿Quieres añadir medicinas a la lista?")) {
        WriteLine("‼️ Debes buscar en el almacen las medcinas que quieras añadir: ");
        var medicinas = new HashSet<Medicina>();
        do {
            var medicina = BuscarSustancia(service);
            if (medicina is Medicina m) {
                medicinas.Add(m);
            } else {
                WriteLine("La sustancia que has seleccionado no es una medicina valida.");
            }
        } while (PedirConfirmacion("¿Quieres añadir mas medicinas?"));

        return medicinas;
    }
    return null;
}

//--------------------------------------------------------------------
//                  Funciones de importar y exportar.
//--------------------------------------------------------------------

void ImportarDatosLaboratorio(ILaboratorioService service) {
    try {
        int numSustancias = service.ImportarDatosSustancias();
        int numCasosMedicos = service.ImportarDatosCasosMedicos();
        WriteLine($"✅ Éxito: {numSustancias} sustancias y {numCasosMedicos} casos cargados.");
    } catch (Exception ex) { WriteLine($"❌ ERROR: {ex.Message}"); }
}

void ExportarDatosLaboratorio(ILaboratorioService service) {
    try {
        service.ExportarDatosSustancias();
        service.ExportarDatosCasosMedicos();
        WriteLine("✅ Datos salvados en ficheros JSON.");
    } catch (Exception ex) { WriteLine($"❌ ERROR: {ex.Message}"); }
}

//--------------------------------------------------------------------
//                        Funciones de extras.
//--------------------------------------------------------------------


string LeerCadenaValidada(string prompt, string regex, string error) {
    while (true) {
        Write(prompt);
        var input = ReadLine()?.Trim() ?? "";
        if (Regex.IsMatch(input, regex)) return input;
        WriteLine($"❌ ERROR: {error}");
    }
}

bool PedirConfirmacion(string mensaje) {
    Write($"⚠️ {mensaje} (S/N): ");
    var res = char.ToUpper(ReadKey(false).KeyChar) == 'S';
    WriteLine();
    return res;
}