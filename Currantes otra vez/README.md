# 🧑‍💼 Ejercicio 8: Currantes y Cálculo de Salario

Este ejercicio amplía el sistema de trabajadores incorporando un método obligatorio para todos los tipos de currantes, así como un nuevo tipo de empleado. El objetivo es profundizar en el diseño orientado a objetos, la abstracción y la organización de clases.

---

## 🧩 Requisito Principal: `calculaSalario()`

Todos los currantes del sistema deberán implementar un método obligatorio:

- **`calculaSalario()`**  
  Método que cada tipo de currante deberá definir según sus propias reglas.

---

## 🆕 Nuevo Tipo de Currante: `Becario`

Se añade un nuevo tipo de currante con un comportamiento específico:

- El **Becario** debe implementar el método `calculaSalario()`.
- Su salario será siempre **100**.

---

## 🧠 Análisis de Diseño

El ejercicio debe contemplarse bajo dos posibles enfoques:

### 🔹 1. Suponiendo que la clase base **sí** debe poder instanciarse
En este caso, la clase base representaría un currante genérico y debería incluir una implementación válida o por defecto de `calculaSalario()`.

### 🔹 2. Suponiendo que la clase base **no** debe poder instanciarse
Aquí la clase base actuaría como una abstracción pura, obligando a todas las clases derivadas a implementar su propia versión de `calculaSalario()`.

---

## 🔗 Atributos Comunes

Independientemente del diseño elegido, existe un atributo común entre algunos tipos de currantes:

- Los currantes **PorHoras** y **Becarios** comparten un valor común:  
  **`TIEMPO`**

Este atributo deberá formar parte del diseño final.

---

## 🎯 Objetivo

Diseñar la jerarquía de clases, definir el método obligatorio `calculaSalario()` y estructurar correctamente los atributos comunes y específicos, considerando ambos enfoques de diseño para la clase base.
