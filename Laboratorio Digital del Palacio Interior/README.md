## 🌸 1. Introducción 
El Palacio Imperial se enfrenta a un caos administrativo en su botica. Jinshi, el gestor jefe, ha detectado múltiples errores en la identificación de sustancias y una falta crítica de orden en la atención de emergencias médicas. Se requiere el desarrollo de un sistema de software robusto para la boticaria que permita gestionar:


- **Sustancias** (medicinas, venenos y afrodisíacos)  
- **Casos médicos y sospechas de envenenamiento**  

---

## 🌿 1. Sustancias alquímicas

En el sistema existen únicamente **tres tipos de sustancias**, tal como en el mundo de Maomao:

### 🌱 Atributos comunes a todas las sustancias
- Identificador de la sustancia  
- Nombre  
- Descripción  
- Precio aproximado  
- Disponibilidad (común, rara, muy rara)  
- Nivel de peligro (nulo, bajo, medio, alto)  

---

### 💊 Medicinas
Sustancias destinadas a tratar enfermedades o aliviar síntomas.

**Atributos típicos:**
- Síntoma o enfermedad que tratan  
- Dosis recomendada  
- Efectos secundarios  
- Tiempo de efecto  

---

### ☠️ Venenos
Sustancias capaces de causar daño, desde malestar leve hasta intoxicaciones graves.

**Atributos típicos:**
- Vía de administración (oral, contacto, inhalación)  
- Tiempo de aparición de síntomas  
- Antídoto conocido  
- Grado de toxicidad  
- Probabilidad de supervivencia (depende del grado de toxicidad)

---

### 💘 Afrodisíacos
Sustancias que alteran el ánimo, la energía o el deseo.

**Atributos típicos:**
- Intensidad del efecto  
- Duración  
- Contraindicaciones  
- Riesgos por uso excesivo  

---


## 📜 2. Casos médicos y sospechas de envenenamiento

Los casos representan situaciones donde se observan síntomas, enfermedades o posibles intoxicaciones, tal como ocurre frecuentemente en el Palacio Interior.

### 🧾 Atributos de un caso
- Identificador del caso  
- Síntomas observados  
- Fecha de inicio  
- Gravedad (nulo, leve, moderada, grave)  
- Causa sospechada (enfermedad, veneno, desconocida)  
- Sustancias sospechosas 
- Tratamientos aplicados  
- Estado del caso (abierto, en investigación, resuelto)  

---

### 🔗 Relación con sustancias
- Colección de sustancias que podrían estar implicadas  
- Sustancias probadas como tratamiento  
- Sustancia que resolvió el caso (si se conoce)  

---

## 🔒 3. Funcionalidades del sistema

### 🌿 Gestión de sustancias
- Crear, modificar y eliminar sustancias  
- Filtrar por tipo (medicina, veneno, afrodisíaco)  
- Consultas personalizadas 
- Listado de sustancias raras o peligrosas  

---

### 📜 Gestión de casos
- Crear nuevos casos  
- Asociar síntomas y sustancias sospechosas 
- Registrar tratamientos aplicados 
- Resolver casos  
- Consultar casos por gravedad, estado o tipo de sustancia implicada  

---

### 📤 Leer y escribir JSON
El sistema debe permitir importar y exportar los datos tanto de las sustancias como de los casos medicos en formato JSON, garantizando que toda la información pueda guardarse y recuperarse fácilmente.

---

### 📊 Informes
- Sustancias más utilizadas  
- Casos resueltos  
- Sustancias más efectivas como tratamiento  

---