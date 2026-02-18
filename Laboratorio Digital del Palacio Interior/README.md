
--------------------------------------------------------------------------------
## 🌸 1. Introducción 
El Palacio Imperial se enfrenta a un caos administrativo en su botica. Jinshi, el gestor jefe, ha detectado múltiples errores en la identificación de sustancias y una falta crítica de orden en la atención de emergencias médicas. Se requiere el desarrollo de un sistema de software robusto para la boticaria **Maomao** que permita:

- **Gestionar el inventario** de frascos y preparados.
- **Automatizar auditorías** para detectar duplicados y discrepancias.
- **Organizar flujos de trabajo** del Pabellón de Jade para atención de emergencias y procesos rutinarios.
- **Garantizar trazabilidad y seguridad** en la manipulación y dispensación de sustancias.

El objetivo es entregar una solución profesional, segura y escalable que reduzca errores humanos, acelere la respuesta en crisis y facilite la gobernanza del herbolario imperial.

--------------------------------------------------------------------------------

## 🌿 2. Arquitectura Base (POO y Estructura)

### 🆔 2.1. Gestión de Identidad Global (GetId)
Para asegurar la trazabilidad absoluta en todo el programa, implemente una clase estática `GeneradorId`.

- Debe contener un campo `static` privado que actúe como contador global.
- Debe proveer un método que devuelva un identificador único numérico y ascendente para cada nueva sustancia creada, garantizando que no existan dos frascos con el mismo ID en la memoria.

### 🌱 2.2. Jerarquía de Sustancias (Herencia y Polimorfismo)
Diseñe una estructura basada en el principio **"ES UN" (IS-A)**:

1. **Clase Abstracta `Sustancia`** (no instanciable)  
   - **Estado:**  
     - `Id` (solo lectura)  
     - `Nombre` (string)  
     - `PrecioBase` (decimal)  
   - **Comportamiento:**  
     - Método abstracto `string ObtenerEfecto()`

2. **Clases Derivadas:**  
   - **Veneno:** Incluye `NivelToxicidad` (int). Su efecto describe el daño causado.  
   - **Medicina:** Incluye `ComponenteActivo` (string). Su efecto describe la curación.  
   - **Afrodisiaco:** Incluye `Potencia` (int). Su efecto indica la intensidad de la reacción.

3. **Reducción de Lógica Condicional:**  
   Utilice polimorfismo para que al recorrer una colección de sustancias, el sistema ejecute `ObtenerEfecto()` dinámicamente según el tipo real del objeto, evitando `if-else` o `switch`.

### 🫙 2.3. Herbolario Imperial (Composición y Genéricos)
Implemente la clase `HerbolarioImperial<T>`, donde `T : Sustancia`.

- **Composición (HAS-A):** Contiene una `List<T>` privada como almacén principal.  
- **Inyección de Dependencias:** La lista inicial debe ser inyectada por constructor para facilitar pruebas desacopladas.

--------------------------------------------------------------------------------
## 🔎 3. El Oráculo de Maomao (Programación Funcional)
Implemente en el herbolario métodos usando delegados (`Predicate<T>`, `Func<T,R>`), lambdas y métodos de extensión:

1. **Filtrar (Where):** Recibe una condición y devuelve una subcolección.  
2. **Proyectar (Select):** Transforma la lista en `List<string>` con solo los nombres.  
3. **Búsqueda (Find):** Localiza la primera sustancia que cumpla un criterio (ej. por ID).

--------------------------------------------------------------------------------
## 📦 4. Operaciones de Almacén (Colecciones y Conjuntos)

### 🫧 4.1. Limpieza de Suministros (HashSet)
- Vuelque una `List<T>` en un `HashSet<T>` para eliminar duplicados basándose en el ID.  
- **Obligatorio:** Sobrescribir `Equals` y `GetHashCode` en `Sustancia`.

### ➕ 4.2. Auditoría Imperial (Operaciones de Conjuntos)
- **Intersección:** Identificar medicinas compartidas con el Médico del Palacio.  
- **Diferencia:** Identificar venenos exclusivos de Maomao.

--------------------------------------------------------------------------------
## 💎 5. Flujos de Trabajo en el Pabellón de Jade (FIFO, LIFO y Prioridad)

1. **La Cata del Banquete (FIFO - Queue):**  
   Los platos llegan en fila; usar `Queue` para procesarlos en orden de llegada.

2. **El Maletín de Emergencias (LIFO - Stack):**  
   Los antídotos se apilan; usar `Stack` para que el último en entrar sea el primero en salir.

3. **Triage de Pacientes (PriorityQueue):**  
   Atender según prioridad: un caso grave (prioridad 1) antes que uno leve (prioridad 10).

--------------------------------------------------------------------------------
