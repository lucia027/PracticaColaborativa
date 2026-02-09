# 👑 Sistema de Gestión de Personal del Palacio Interior – “El Registro de Jinshi”

El Palacio Interior desea modernizar la gestión de su personal. **Jinshi**, responsable de mantener el orden y la eficiencia dentro del palacio, necesita un sistema que le permita administrar a los distintos tipos de trabajadores y sirvientes.

Tu misión es desarrollar una aplicación orientada a objetos que permita gestionar personajes, sus roles y sus tareas, siguiendo un diseño modular y avanzado.

---

## 🎯 Objetivo General
Implementar un sistema que permita:
* **Gestión Completa (CRUD):** Crear, listar, actualizar y eliminar personajes.
* **Principios POO:** Aplicar herencia, polimorfismo e interfaces.
* **Composición:** Asignar tareas dinámicamente a los personajes.
* **Arquitectura en Capas:**
    * `Modelos`
    * `Validador`
    * `Repositorio` (basado en arrays en memoria)
    * `Servicio`

---

## 🧩 1. Modelos

### 1.1. Personaje (Clase Abstracta)
Representa a cualquier persona dentro del palacio.
* **Atributos:** `id`, `nombre`, `edad`, `rol` (texto descriptivo).
* **Métodos abstractos:**
    ```java
    void realizarTarea();
    ```

### 1.2. Sirviente (Subclase de Personaje)
* **Atributos adicionales:** `nivel` (aprendiz, intermedio, experto).
* **Implementación:** Realiza una acción típica de sirviente en `realizarTarea()`.

### 1.3. Boticaria (Subclase de Personaje)
Representa a Maomao o cualquier boticario del palacio.
* **Atributos adicionales:** `especialidad` (venenos, hierbas, análisis).
* **Implementación:** Realiza una acción relacionada con medicina en `realizarTarea()`.

### 1.4. Noble (Subclase de Personaje)
Incluye a personajes de alto rango como Jinshi.
* **Atributos adicionales:** `rango` (bajo, medio, alto).
* **Implementación:** Realiza una acción acorde a su estatus en `realizarTarea()`.
---

## 🧪 2. Validador
El sistema debe validar los siguientes puntos antes de procesar los datos:
1. Que el **nombre** no esté vacío.
2. Que la **edad** sea mayor que 0.
3. Que el **rango, nivel o especialidad** sean valores válidos dentro de los parámetros definidos.

---

## 📚 3. Repositorio
Debe existir un repositorio por cada tipo principal
* Uso de `Array` como única colección de almacenamiento.
* Implementación de métodos CRUD básicos.

---

## ⚙️ 4. Servicio
El servicio coordina la lógica de negocio. Funciones mínimas requeridas:
* Crear personajes de distintos tipos.
* Listar personajes por tipo (aplicando polimorfismo).
* Ejecutar `realizarTarea()` de forma masiva o individual.
* Buscar personajes por criterios específicos (rango, nivel o especialidad).
* Listar tareas asignadas a un personaje concreto.

---

## 🏛️ 5. Requisitos de Polimorfismo
Cuando el servicio llame al método:
```c#
personaje.realizarTarea();