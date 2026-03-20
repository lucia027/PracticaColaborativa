namespace Laboratorio_Digital_del_Palacio_Interior.Config;

public static class Configuracion {
    public static readonly string DataFolder = Path.Combine(Environment.CurrentDirectory, "data");
    public static readonly string SustanciaFile = Path.Combine(DataFolder, "sustanciaFile.json");
    public static readonly string CasosMedicosFile = Path.Combine(DataFolder, "casosMedicosFile.json");

}