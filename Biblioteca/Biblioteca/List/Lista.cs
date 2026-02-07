namespace Biblioteca.List;

public class Lista<T> : ILista<T> {
    private Nodo<T>? _cabeza;
    private int _contador;
    
    public void AgregarInicio(T valor) {
        var nodoNuevo = new Nodo<T>(valor);
        if (_cabeza == null) {
            _cabeza = nodoNuevo;
        } else {
            nodoNuevo.Siguiente = _cabeza;
            _cabeza = nodoNuevo;
        }

        _contador++;
    }

    public void AgregarEnMedio(T valor, int indice) {
        var nodoNuevo = new Nodo<T>(valor);
        
        if (_cabeza == null) {
            AgregarInicio(valor);
        }

        if (indice < 0 || indice > _contador) {
            throw new ArgumentOutOfRangeException(nameof(indice), "Indice fuera de rango");
        }
        else {
            var actual = _cabeza;
            for (int i = 0; i < indice; i++) {
                actual = actual?.Siguiente;
            }

            nodoNuevo.Siguiente = actual?.Siguiente;
            actual?.Siguiente = nodoNuevo;
        }

        _contador++;
    }

    public void AgregarFinal(T valor) {
        var nodoNuevo = new Nodo<T>(valor);
        if (_cabeza == null) {
            _cabeza = nodoNuevo;
        } else {
            var actual = _cabeza;
            while (actual.Siguiente != null) {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nodoNuevo;
        }
        _contador++;
    }

    public void EliminarInicio() {
        if (_cabeza == null) {
            throw new InvalidOperationException("No se puede eliminar la cabeza si es nula.");
        }
        
        // Forma de hacerlo 1
        // var nodoNuevo = _cabeza.Siguiente;
        // _cabeza = nodoNuevo;

        _cabeza = _cabeza?.Siguiente;
        _contador--;
    }

    public void EliminarEnMedio(int indice) {
        if (_cabeza == null) {
            throw new InvalidOperationException("No se puede eliminar si la cabeza es nula.");
        }

        if (indice < 0 || indice > _contador) {
            throw new ArgumentOutOfRangeException(nameof(indice), "EL indice se sale del rango");
        } else {
            var actual = _cabeza; 
            for (int i = 0; i < _contador; i++) {
                actual = actual?.Siguiente;
            }

            actual?.Siguiente = actual?.Siguiente?.Siguiente;
        }
        _contador--;
    }

    public void EliminarFinal() {
        if (_cabeza == null) {
            throw new InvalidOperationException("No se puede eliminar si la cabeza es nula.");
        } else {
            var actual = _cabeza;
            while (actual.Siguiente != null) {
                actual = actual.Siguiente;
            }

            actual = null;
        }
        _contador--;
    }

    public T ObtenerPrimero() {
        if (_cabeza == null) {
            throw new InvalidOperationException("LA opercaion no se puede realizar si la cabeza es nula");
        }
        return _cabeza.Valor!;
    }

    public T ObtenerEnMedio(int indice) {
        if (_cabeza == null) {
            throw new InvalidOperationException("La operación no se puede realizar si la cabeza es nula");
        }
        if (indice < 0 || indice > _contador) {
            throw new ArgumentOutOfRangeException(nameof(indice), "EL indice se sale del rango");
        } else {
            var actual = _cabeza; 
            for (int i = 0; i < indice; i++) {
                actual = actual?.Siguiente;
            }
            return actual!.Valor!;
        }
    }

    public T ObtenerUltimo() {
        if (_cabeza == null) {
            throw new InvalidOperationException("LA opercaion no se puede realizar si la cabeza es nula");
        } else {
            var actual = _cabeza;
            while (actual.Siguiente != null) {
                actual = actual.Siguiente;
            }
            return actual!.Valor!;
        }
    }

    public bool Existe(T valor) {
        var actual = _cabeza;

        while (actual != null) {
            if (actual.Valor!.Equals(valor))
                return true;
            actual = actual.Siguiente;
        }
        return false;    
    }

    public int Contar() {
        return _contador;
    }

    public bool EstaVacia() {
        if (_cabeza == null) {
            return true;
        } else {
            return false;
        }
    }

    public void Limpiar() {
        _cabeza = null;
    }

    public void Mostrar() {
        if (_cabeza == null) {
            Console.WriteLine("No hay elementos para mostrar.");
        } else {
            var actual = _cabeza;
            for (int i = 0; i < _contador; i++) {
                Console.WriteLine($"{actual!.Valor}");
                actual = actual?.Siguiente;
            }
        }
    }
    
    public IEnumerator<T> GetEnumerator() {
        // Recorremos la lista devolviendo los valores
        var actual = _cabeza;
        while (actual != null) {
            // Yield devuelve un valor y pausa la ejecución, para que el ciclo foreach pueda continuar
            yield return actual.Valor!;
            // Avanzamos al siguiente nodo
            actual = actual.Siguiente;
        }
    }
}