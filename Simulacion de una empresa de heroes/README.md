
# 🧠 Simulación de una Empresa de Héroes

## 📘 Enunciado

Una empresa especializada en la gestión de héroes desea desarrollar una aplicación que permita administrar sus
operaciones diarias. La organización entrena distintos tipos de héroes, los envía a misiones y evalúa su desempeño para
mejorar sus habilidades y estadísticas.

El sistema deberá permitir la creación de héroes con características particulares, la gestión de misiones con distintos
niveles de dificultad y la asignación estratégica de héroes a cada desafío. Además, deberá simular el resultado de las
misiones en función del poder combinado del equipo y mostrar estadísticas actualizadas tras cada participación.

---

## 🏗️ Funcionamiento General

La aplicación se ejecutará en consola y ofrecerá un menú interactivo que permita al usuario:

- Crear nuevos héroes.
- Visualizar los héroes registrados.
- Crear nuevas misiones.
- Asignar héroes a una misión.
- Simular el desarrollo de una misión.
- Mostrar un ranking de héroes.
- Buscar héroes o misiones según distintos criterios.
- Salir del programa.

---

## 🦸‍♂️ Modelo del Sistema

Todos los héroes comparten ciertas características básicas:

- Nombre
- Nivel
- Energía
- Experiencia
- Poder base

Cada héroe puede:

- Entrenar para mejorar sus capacidades.
- Descansar para recuperar energía.
- Calcular su poder total según sus atributos particulares.
- Mostrar su información actual.

Existen distintos tipos de héroes, cada uno con una habilidad especial predominante (por ejemplo, fuerza física,
inteligencia estratégica, precisión o equilibrio general). Cada tipo calculará su poder de manera diferente y podrá
progresar de forma particular tras participar en misiones.

Durante una misión, los héroes realizarán acciones que influirán en el resultado final.

---

## 🎯 Misiones

Cada misión tendrá:

- Un nombre identificador.
- Un nivel de dificultad del 1 al 10.
- Un estado (pendiente o completada).
- Un grupo de héroes asignados.

Una misión se considerará superada si el poder total del equipo alcanza o supera un valor determinado por la dificultad.

### ✔ Si la misión es exitosa:

- Los héroes ganarán experiencia.
- Podrán subir de nivel al alcanzar ciertos umbrales.

### ❌ Si la misión fracasa:

- Los héroes perderán energía.

---

## 🔎 Búsquedas

El sistema deberá permitir:

- Buscar héroes por nombre.
- Buscar héroes que superen un nivel mínimo.
- Consultar misiones pendientes.

---

## 📊 Estadísticas y Ordenación

Se deberá mostrar información ordenada, como:

- Héroes ordenados por nivel.
- Héroes ordenados por experiencia.
- Ranking según poder total.

---

## 🚀 Posibles Ampliaciones

Para enriquecer la aplicación, se podrían incorporar mejoras como:

- Restricción por fatiga (héroes con baja energía no pueden participar).
- Misiones que requieran colaboración obligatoria.
- Sistema de rareza o categorías especiales de héroes.
- Registro histórico de resultados.
- Eventos aleatorios que modifiquen el resultado de una misión.

---

## 🎯 Objetivo del Ejercicio

Este ejercicio busca desarrollar una aplicación completa que simule una gestión estratégica, fomentando el diseño
estructurado, la organización lógica y la implementación de mecánicas de progresión y evaluación.

La solución puede abordarse de manera sencilla o ampliarse con mayor profundidad, permitiendo distintos niveles de
complejidad y creatividad.