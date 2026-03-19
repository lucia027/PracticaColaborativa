// See https://aka.ms/new-console-template for more information

public static class ListaExtensions {
    public static ILista<T> Filter<T>(this ILista<T> lista, Predicate<T> predicado) {
        var resultado = new Lista<T>();
        foreach (var elemento in lista)
            if (predicado(elemento))
                resultado.AddLast(elemento);

        return resultado;
    }

    extension<T>(ILista<T> lista) where T : class {
        public ILista<T> Where(Predicate<T> predicado) {
            var resultado = new Lista<T>();
            foreach (var elemento in lista)
                if (predicado(elemento))
                    resultado.AddLast(elemento);

            return resultado;
        }

        public ILista<TK> Select<TK>(Func<T, TK> selector) {
            var resultado = new Lista<TK>();
            foreach (var elemento in lista)
                resultado.AddLast(selector(elemento));
            return resultado;
        }

    }
}