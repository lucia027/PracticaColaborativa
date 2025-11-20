# 🕵️ Agencia WISE – Gestión de Misiones Secretas

La organización secreta **WISE** necesita una aplicación para gestionar las misiones de sus agentes.  
Tu tarea será implementar un sistema **CRUD** (Crear, Leer, Actualizar, Eliminar) que permita administrar estas misiones, además de incluir funciones de **ordenación** y **validación de datos**.

---

## 📌 Requisitos

### 1. CRUD de misiones
Cada misión debe tener:
- `id` → único, numérico
- `nombre` → texto, obligatorio
- `nivel_riesgo` → entero entre 1 y 5
- `agente_asignado` → texto, obligatorio (*Loid*, *Yor* o *Anya*)

Operaciones básicas:
- Crear una nueva misión
- Listar todas las misiones
- Actualizar datos de una misión existente
- Eliminar una misión

---

### 2. Ordenación
El sistema debe permitir ordenar las misiones por:
- `nivel_riesgo` (ascendente y descendente)
- `nombre` (alfabéticamente)

---

### 3. Validación de entradas
- El `nivel_riesgo` debe ser un número entero entre 1 y 5.
- El `nombre` no puede estar vacío.
- El `agente_asignado` debe ser uno de los nombres válidos (*Loid*, *Yor*, *Anya*).

---

### 4. Extras opcionales 🎁
- Mostrar un mensaje especial si la misión está asignada a *Anya*:  
  **⚠ Atención: misión infantil detectada**
- Evitar que se creen dos misiones con el mismo `id`.

---

## 🎯 Objetivo
Con este ejercicio practicarás:
- Implementación de un CRUD básico.
- Métodos de ordenación.
- Validación de entradas de datos.
- Ambientación temática divertida inspirada en *SPY x Family*.
