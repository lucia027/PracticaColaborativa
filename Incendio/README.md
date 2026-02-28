# 🔥 Simulación de Incendios – Propagación en Bosques

El bosque necesita un sistema que permita **simular la propagación de un incendio** en una matriz bidimensional.  
Tu tarea será implementar un módulo que gestione el avance del fuego utilizando un esquema de **Doble Búfer**, garantizando que cada nueva generación se calcule sobre un estado consistente.  
Además, deberás aplicar el mecanismo de **Intercambio (Swap)** de referencias para asegurar que la actualización sea eficiente y coherente.

---

## 📌 Requisitos

### 1. Representación del bosque
Cada celda de la matriz puede estar en uno de los siguientes estados:
- `🌲 árbol` → susceptible de arder
- `🔥 fuego` → celda en combustión
- `⬛ vacío` → celda quemada o sin árbol

---

### 2. Propagación del incendio
El sistema debe aplicar reglas de propagación:
- Un `🌲 árbol` se convierte en `🔥 fuego` si al menos un vecino está ardiendo.
- Una celda en `🔥 fuego` pasa a `⬛ vacío` en la siguiente generación.
- Las celdas `⬛ vacío` permanecen sin cambios.

---

### 3. Doble Búfer
- Usar dos matrices idénticas:  
  - **actual** → lectura del estado presente  
  - **siguiente** → escritura de la nueva generación  
- Al finalizar cada paso, realizar un **Swap** de referencias entre ambas matrices.

---

### 4. Parámetros configurables
- Tamaño de la matriz (ej. 20x20, 50x50).  
- Probabilidad de ignición inicial.  
- Número de pasos de simulación.  

---

### 5. Extras opcionales 🎁
- Visualizar la evolución del incendio paso a paso.  
- Permitir reiniciar la simulación con diferentes parámetros.  
- Mostrar estadísticas: porcentaje de bosque quemado, número de generaciones hasta extinguirse el fuego.  

---

## 🎯 Objetivo
Con este ejercicio practicarás:
- Uso de **doble búfer** y mecanismo de **Swap**.  
- Implementación de reglas de propagación en matrices bidimensionales.  
- Configuración de parámetros dinámicos.  
- Ambientación temática inspirada en la simulación de incendios forestales.
