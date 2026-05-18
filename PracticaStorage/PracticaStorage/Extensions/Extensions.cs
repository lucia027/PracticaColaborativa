namespace PracticaStorage.Extensions;

public static class Extensions {
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> lista, Predicate<T> predicado) {
        var resultado = new List<T>();
        foreach (var elemento in lista)
            if (predicado(elemento))
                resultado.Add(elemento);
        return resultado;
    }
    
    public static IEnumerable<TK> Select<T, TK>(this IEnumerable<T> lista, Func<T, TK> selector) {
        var resultado = new List<TK>();
        foreach (var elemento in lista)
            resultado.Add(selector(elemento));
        return resultado;
    }
}