# 📦 Examen Práctico: Dawazon 2.0 (Edición POO Pura)

## 📝 Contexto del Problema
La empresa de logística **Dawazon** necesita renovar su sistema de gestión de paquetería. El sistema antiguo no soportaba diferentes tipos de envíos y era muy rígido. Se requiere una nueva solución en **C#** que aplique estrictamente los pilares de la Programación Orientada a Objetos.

---

## ⚠️ Restricciones Técnicas (MUY IMPORTANTE)
Para que el ejercicio sea válido, debes cumplir estas reglas de oro:
1.  **NO** utilizar colecciones genéricas (`List<T>`, `Dictionary`, etc.). Debes usar **Arrays estáticos (`[]`)**.
2.  **NO** utilizar LINQ ni Expresiones Lambda.
3.  **NO** utilizar Ficheros ni Bases de Datos.
4.  El código debe controlar los espacios vacíos (`null`) dentro del array manualmente.

---

## 🛠️ Requerimientos del Sistema

### 1. Modelado de Datos (Clases y Relaciones)

#### A. Composición: El Cliente
Todo paquete debe tener asociado un destinatario. Crea la clase `Destinatario`:
* **Atributos:** `Nombre`, `Direccion`, `Dni`.
* **Métodos:** Sobrescribir `ToString()` para mostrar los datos del cliente en una línea.

#### B. Interfaz: El Contrato
Crea una interfaz llamada `IPagable` que obligue a implementar el método:
* `double CalcularPrecioEnvio();`

#### C. Herencia y Abstracción: El Paquete
Crea una clase base **abstracta** llamada `Paquete` que implemente `IPagable`.
* **Propiedades:**
    * `Id` (int).
    * `Peso` (double).
    * `CodigoBarras` (string).
    * `Cliente` (Tipo `Destinatario` -> **Composición**).
* **Métodos:**
    * **Constructor:** Debe recibir los datos para inicializar el paquete y su destinatario.
    * `Equals(object obj)`: Sobrescríbelo para que dos paquetes sean iguales si tienen el mismo `CodigoBarras`.
    * `ToString()`: Sobrescríbelo para devolver la información del paquete concatenada con la del `Cliente`.
    * `GetHashCode()`: Sobrescríbelo basándote en el `CodigoBarras`.
    * `CalcularPrecioEnvio()`: Definido como **abstracto**.

#### D. Polimorfismo: Tipos de Paquetes
Crea dos clases que hereden de `Paquete`:

1.  **`PaqueteNormal`**:
    * Precio de envío: `Peso * 1.5€`.
    * En su `ToString` debe indicar "Envío Normal".
2.  **`PaqueteUrgente`**:
    * Tiene un atributo extra: `CosteSeguro` (double).
    * Precio de envío: `(Peso * 4€) + CosteSeguro`.
    * En su `ToString` debe indicar "Envío Urgente".

---

### 2. Lógica de Negocio (Servicio)

Crea la clase `AlmacenService` que gestionará la lógica.

* **Estructura de datos:** Un **Array** de `Paquete` con capacidad para **50 elementos**.

#### Funciones Requeridas:

1.  **`AltaReparto(Paquete nuevoPaquete)`**
    * Debe validar que el paquete no sea nulo.
    * Debe buscar la primera posición libre (`null`) en el array.
    * Si hay sitio, guarda el paquete. Si el almacén está lleno, avisa por consola.

2.  **`EntregarPremium()`**
    * Recorre el array buscando el paquete con el **precio de envío más alto** (usando `CalcularPrecioEnvio()` polimórficamente).
    * Muestra sus datos y lo elimina del array (asigna `null` a su posición).

3.  **`EntregarUrgentes()`**
    * Recorre el array y detecta todos los paquetes que sean de la clase `PaqueteUrgente` (Usa `is` o `GetType`).
    * Muestra sus datos y los elimina del array (asigna `null`).

4.  **`SalidaPorCodigo(string codigo)`**
    * Recorre el array buscando un paquete que coincida con el código proporcionado.
    * Debes utilizar el método `Equals` que sobrescribiste anteriormente.
    * Si lo encuentra, lo elimina (asigna `null`).

5.  **`GenerarInforme()`**
    * Muestra por consola un listado de todos los paquetes que actualmente están en el almacén (saltando los `null`).

---

### 3. Validación
Simula una clase estática `Validador` con un método `EsPaqueteValido(Paquete p)` que devuelva `true` solo si:
* El peso es mayor a 0.
* El código de barras tiene al menos 5 caracteres.
* El objeto `Cliente` dentro del paquete no es nulo.
* *Usa este validador antes de llamar a `AltaReparto`.*