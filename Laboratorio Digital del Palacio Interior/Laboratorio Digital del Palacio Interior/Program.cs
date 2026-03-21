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
WriteLine("\n Pulse cualquier tecla para salir del programa.👋🏻");
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
    const string regexMenu = @"^([0-9]|1[0-1])$";
    
    do {
        MostrarMenu();
        opcion = LeerCadenaValidada("🔬 Elige una opción del menú valida: ", regexMenu, "Opción no válida (0-11).");

        switch (opcion) {
            case "1": ListarSustancias(service); break;
            case "2": BuscarSustancia(service); break;
            case "3": AnadirNuevaSustancia(service); break;
            case "4": ActualizarSustancia(service); break;
            case "5": EliminarSustancia(service); break;
            case "6": ListarCasosMedicos(service); break;
            case "7": BuscarCasoMedico(service); break;
            case "8": AbrirCasoMedico(service); break;
            case "9": MostrarInformeEstadistico(service); break;
            case "10": ImportarDatosLaboratorio(service); break;
            case "11": ExportarDatosLaboratorio(service); break;
            case "0": WriteLine("\n👋 Cerrando laboratorio. ¡Buen trabajo, boticaria!"); break;
        }

        if (opcion != "0") {
            WriteLine("\n Presiona una tecla para salir.👋🏻");
            ReadKey();
            Clear();
        }
    } while (opcion != "0");
}

void MostrarMenu() {
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
    WriteLine("9. 📊 Informe");
    WriteLine();
    WriteLine("💾 ALMACENAMIENTO");
    WriteLine("10. 📥 Importar desde JSON");
    WriteLine("11. 📤 Exportar a JSON");
    WriteLine();
    WriteLine("0. 🔚 SALIR");
    WriteLine("-----------------------------------------------");
}


//--------------------------------------------------------------------
//                      Funciones de sustancias.
//--------------------------------------------------------------------

void ListarSustancias(ILaboratorioService s) {
    WriteLine();
    WriteLine("💊 INVENTARIO COMPLETO DE SUSTANCIAS");
    var lista = s.GetAllSustancia();
    var line = new string('─', 110);
    WriteLine(line);
    WriteLine($"{"ID", -5} | {"Nombre", -40} | {"Precio", -10} | {"Peligro", -10} | {"Disponibilidad", -15} | {"Tipo"}");
    WriteLine(line);
    foreach (var sus in lista) {
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

Sustancia? BuscarSustancia(ILaboratorioService s) {
    WriteLine();
    var id = int.Parse(LeerCadenaValidada("🌱 Id de la sustancia: ", @"^\d+$", "Debe ser un número."));
    Sustancia? sus = null;
    WriteLine("-----------------------------------------------");
    try {
        sus = s.GetByIdSustancia(id);
        ImprimirFichaSustancia(sus);
    } catch (Exception ex) {
        WriteLine($"❌ ERROR: {ex.Message}");
    }
    WriteLine("-----------------------------------------------");
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
    WriteLine("🍃 Nombre: ");
    var nombre = ReadLine() ?? "";
    WriteLine("📝 Descripcion: ");
    var descripcion = ReadLine() ?? "";
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
            WriteLine($"\n❌ ERROR, tipo invalido.");
            break;
    }

    // 4. Intento de creación en el servicio
    try {
        service.CreateSustancia(nueva);
        WriteLine($"\n✅ '{nueva.Nombre}' se ha registrado correctamente en el inventario.");
    } catch (Exception ex) {
        WriteLine($"\n❌ ERROR DE VALIDACIÓN: {ex.Message}");
    }
    WriteLine();
}

void ActualizarSustancia(ILaboratorioService s) {
    WriteLine("\n📝 --- MODIFICAR SUSTANCIA ---");
    var id = int.Parse(LeerCadenaValidada("🆔 ID a editar: ", @"^\d+$", "ID no válido."));
    try {
        var vieja = s.GetByIdSustancia(id);
        ImprimirFichaSustancia(vieja);
        
        var nNom = LeerCadenaValidada($"Nombre [{vieja.Nombre}] (Enter mant.): ", @"^.*$", "");
        var nPre = LeerCadenaValidada($"Precio [{vieja.Precio}] (Enter mant.): ", @"^(\d+([.,]\d{1,2})?)?$", "Error.");

        var actualizada = vieja switch {
            Veneno v => v with { 
                Nombre = string.IsNullOrWhiteSpace(nNom) ? v.Nombre : nNom,
                Precio = string.IsNullOrWhiteSpace(nPre) ? v.Precio : decimal.Parse(nPre)
            },
            Medicina m => m with { 
                Nombre = string.IsNullOrWhiteSpace(nNom) ? m.Nombre : nNom,
                Precio = string.IsNullOrWhiteSpace(nPre) ? m.Precio : decimal.Parse(nPre)
            },
            Afrodisiaco a => a with { 
                Nombre = string.IsNullOrWhiteSpace(nNom) ? a.Nombre : nNom,
                Precio = string.IsNullOrWhiteSpace(nPre) ? a.Precio : decimal.Parse(nPre)
            },
            _ => vieja
        };

        s.UpdateSustancia(id, actualizada);
        WriteLine("✅ Registro actualizado.");
    } catch (Exception ex) { WriteLine($"❌ ERROR: {ex.Message}"); }
}

void EliminarSustancia(ILaboratorioService s) {
    var id = int.Parse(LeerCadenaValidada("\n🗑️ ID a eliminar: ", @"^\d+$", "ID no válido."));
    try {
        var sus = s.GetByIdSustancia(id);
        if (PedirConfirmacion($"¿Eliminar {sus.Nombre} permanentemente?")) {
            s.DeleteSustancia(id);
            WriteLine("✅ Eliminado.");
        }
    } catch (Exception ex) { WriteLine($"❌ ERROR: {ex.Message}"); }
}

void ImprimirFichaSustancia(Sustancia p) {
    WriteLine($"🌿 Id: {p.Id}");
    WriteLine($"🍃 Nombre: {p.Nombre}");
    WriteLine($"📝 Descripcion: {p.Descripcion}");
    WriteLine($"💰 Precio: {p.Precio:C2}");
    WriteLine($"🗝️Disponibilidad: {p.Disponibilidad}");
    WriteLine($"⚠️ Peligro: {p.NivelPeligro}");
    
    if (p is Veneno v) {
        var nombreAntidoto = (v.Antidoto?.Nombre != null) ? v.Antidoto.Nombre : "No hay antidoto." ;
        WriteLine($"🧪 Via de Administracion: {v.ViaDeAdministracion}");
        WriteLine($"🕐 Tiempo de aparicion: {v.TiempoAparicion}");
        WriteLine($"🌿 Nombre del Antidoto: {nombreAntidoto}");
        WriteLine($"☠️ Toxicidad: {v.GradoToxicidad}");
        WriteLine($"🧬 Probabilidad de supervivencia: {v.ProbabilidadSupervivencia}%");
    }
    if (p is Medicina m) {
        WriteLine($"🤧 Sintomas: {m.Sintoma}");
        WriteLine($"💊 Dosis recomendada: {m.DosisRecomendada}");
        WriteLine($"🧫 Efectos secundarios: {m.EfectosSecundarios}");
        WriteLine($"🕐 Tiempo de efecto: {m.TiempoEfecto}%");
    }
    if (p is Afrodisiaco a) {
        WriteLine($"🩹 Intensidad del efecto: {a.IntensidadEfecto}");
        WriteLine($"🕐 Duracion: {a.Duracion}");
        WriteLine($"🚫 Contraindicaciones: {a.ContraIndicaciones}");
        WriteLine($"💀 Riesgo de uso: {a.RiegosUso}%");
    }
}

Medicina? AsignarAntidoto(ILaboratorioService service) {
    WriteLine("☠️ Antidoto: ");
    WriteLine("‼️ Debes buscar en el almacen la medicina: ");
    var medicina = BuscarSustancia(service);
    if (medicina is Medicina m) {
        return m;
    }
    return null;
}


//--------------------------------------------------------------------
//                    Funciones de casos médicos.
//--------------------------------------------------------------------

void ListarCasosMedicos(ILaboratorioService s) {
    WriteLine("\n📜 --- HISTORIAL MÉDICO DEL PALACIO ---");
    var casos = s.GetAllCasoMedico();
    var line = new string('─', 80);
    WriteLine(line);
    WriteLine($"{"ID",-5} | {"Fecha",-12} | {"Estado",-15} | {"Gravedad",-12} | {"Sospecha",-15}");
    WriteLine(line);
    foreach (var c in casos) {
        WriteLine($"{c.Id,-5} | {c.FechaInicio:dd/MM/yyyy} | {c.Estado,-15} | {c.Gravedad,-12} | {c.CausaSospecha}");
    }
    WriteLine(line);
}

void BuscarCasoMedico(ILaboratorioService s) {
    var id = int.Parse(LeerCadenaValidada("\n🆔 ID del Caso: ", @"^\d+$", "Número requerido."));
    try {
        var caso = s.GetByIdCasoMedico(id);
        ImprimirFichaCaso(caso);
    } catch (Exception ex) { WriteLine($"❌ ERROR: {ex.Message}"); }
}

void AbrirCasoMedico(ILaboratorioService s) {
    WriteLine("\n🚨 --- APERTURA DE EXPEDIENTE ---");
    var sin = LeerCadenaValidada("📝 Síntomas: ", @".{5,}", "Mínimo 5 car.");
    
    WriteLine("⚖️ Gravedad: 0.Nulo, 1.Leve, 2.Moderada, 3.Grave");
    var grav = (Gravedad)int.Parse(LeerCadenaValidada("🎯 Selección: ", "^[0-3]$", "0-3."));

    var nuevo = new CasoMedico {
        Sintomas = sin,
        FechaInicio = DateTime.Now,
        Gravedad = grav,
        Estado = EstadoCasoMedico.Abierto,
        CausaSospecha = CausaSospecha.Desconocida
    };

    try {
        var creado = s.CreateCasoMedico(nuevo);
        WriteLine("✅ Caso abierto. Iniciando investigación...");
        ImprimirFichaCaso(creado);
    } catch (Exception ex) { WriteLine($"❌ ERROR: {ex.Message}"); }
}

void MostrarInformeEstadistico(ILaboratorioService s) {
    var inf = s.GetInforme();
    WriteLine("\n📊 --- RESUMEN DE ACTIVIDAD ---");
    WriteLine(new string('═', 40));
    WriteLine($"🔹 Casos Resueltos:      {inf.CasosMedicosResueltos}");
    WriteLine($"🔹 Sustancia recurrente: {inf.SutanciaMasUtilizada?.Nombre ?? "N/A"}");
    WriteLine($"🔹 Medicina clave:       {inf.SustanciaMasEfectivaTratamiento?.Nombre ?? "N/A"}");
    WriteLine(new string('═', 40));
}

//--------------------------------------------------------------------
//                  Funciones de importar y exportar.
//--------------------------------------------------------------------

void ImportarDatosLaboratorio(ILaboratorioService s) {
    try {
        int nS = s.ImportarDatosSustancias();
        int nC = s.ImportarDatosCasosMedicos();
        WriteLine($"✅ Éxito: {nS} sustancias y {nC} casos cargados.");
    } catch (Exception ex) { WriteLine($"❌ ERROR: {ex.Message}"); }
}

void ExportarDatosLaboratorio(ILaboratorioService s) {
    try {
        s.ExportarDatosSustancias();
        s.ExportarDatosCasosMedicos();
        WriteLine("✅ Datos salvados en ficheros JSON.");
    } catch (Exception ex) { WriteLine($"❌ ERROR: {ex.Message}"); }
}

//--------------------------------------------------------------------
//                        Funciones de extras.
//--------------------------------------------------------------------
void ImprimirFichaCaso(CasoMedico c) {
    var line = new string('═', 60);
    WriteLine($"\n{line}");
    WriteLine($"  EXPEDIENTE: {c.Id} | ESTADO: {c.Estado}");
    WriteLine(new string('─', 60));
    WriteLine($"  📅 INICIO: {c.FechaInicio:G}");
    WriteLine($"  ⚖️ GRAVEDAD: {c.Gravedad} | CAUSA: {c.CausaSospecha}");
    WriteLine($"  📝 SÍNTOMAS: {c.Sintomas}");
    WriteLine($"{line}\n");
}

string LeerCadenaValidada(string prompt, string regex, string error) {
    while (true) {
        Write(prompt);
        var input = ReadLine()?.Trim() ?? "";
        if (Regex.IsMatch(input, regex)) return input;
        WriteLine($"❌ ERROR: {error}");
    }
}

bool PedirConfirmacion(string mensaje) {
    Write($"\n⚠️ {mensaje} (S/N): ");
    var res = char.ToUpper(ReadKey(false).KeyChar) == 'S';
    WriteLine();
    return res;
}