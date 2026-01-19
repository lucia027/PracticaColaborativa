# 🧑‍💼 Sistema de Gestión de Trabajadores

Este proyecto consiste en diseñar un sistema orientado a objetos para representar distintos tipos de trabajadores dentro de una empresa. El objetivo es practicar herencia, reutilización de código y organización de clases.

---

## 🏗️ Descripción del Enunciado

En nuestra empresa existen **tres tipos de trabajadores**:

- **Fijos**
- **PorHoras**
- **AComision**

Dado que todos comparten ciertos atributos, se propone crear una **clase base** llamada `Trabajador`, que incluya los atributos comunes:

- `nombre`
- `apellidos`

A partir de esta clase general, se deben crear las clases derivadas correspondientes a cada tipo de trabajador, cada una con sus atributos específicos:

---

## 🧩 Clases Derivadas y Atributos

### 🔸 Fijos
Atributos:
- `nombre`
- `apellidos`
- `sueldo`

### 🔸 PorHoras
Atributos:
- `nombre`
- `apellidos`
- `horas`
- `sueldoHora`

### 🔸 AComision
Atributos:
- `nombre`
- `apellidos`
- `ventas`
- `porcentaje`

---

## 🎯 Objetivo

Crear todas las clases necesarias aplicando correctamente herencia y diferenciando los atributos comunes de los específicos.
