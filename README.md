# 🚀 TaskFlow API (.NET 8 + Docker)

## 📌 Descripción
Este proyecto consiste en una API REST desarrollada en .NET 8, implementando arquitectura en capas y utilizando Docker para la contenedorización.

Como parte de la entrega, se construyen dos contenedores que se comunican entre sí:
- API (.NET 8)
- Base de datos SQL Server

---

## 🧱 Arquitectura

El proyecto está organizado en capas:

- Api_TaskFlow → Controladores (Controllers)
- Business → Lógica de negocio (Services)
- DataAccess → Acceso a datos (Repositories)
- Models → Entidades y modelos

---

## 🐳 Uso de Docker

Se implementa docker-compose para levantar dos contenedores:
- Contenedor 1: API (.NET)
- Contenedor 2: SQL Server

Estos contenedores están conectados mediante la red interna de Docker.

## 🔗 Comunicación entre contenedores

La API se conecta a la base de datos usando el nombre del servicio:

Server=sqlserver;

Esto permite que ambos contenedores se comuniquen correctamente dentro de Docker.

---

## ▶️ Cómo ejecutar el proyecto

### 1. Clonar el repositorio

git clone https://github.com/4n1ma98/TaskFlow.git
cd TaskFlow

---

### 2. Ejecutar con Docker

docker-compose up --build

---

### 3. Acceder a la API

http://localhost:8080

Swagger:
http://localhost:8080/swagger

## 🗄️ Base de datos

- Motor: SQL Server
- Usuario: sa
- Password: Your_password123
- Puerto: 1433

---

## ✅ Cumplimiento de requisitos

✔ Proyecto en repositorio GitHub
✔ Uso de Docker
✔ Creación de 2 contenedores
✔ Comunicación entre contenedores
✔ Uso de docker-compose

---

## 📌 Notas

- La base de datos usa un volumen persistente (sql_data)
- Docker permite ejecutar el proyecto sin instalaciones adicionales
