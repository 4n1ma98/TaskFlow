# Financial Products

Aplicación web para la gestión de clientes y productos financieros asociados.

El proyecto está compuesto por un API desarrollado con **.NET 8** y un frontend desarrollado con **Angular**.

## Tecnologías

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Angular
- Visual Studio 2022

## Requisitos

Antes de ejecutar el proyecto se recomienda tener instalado:

- Visual Studio 2022
- .NET 8 SDK
- Node.js y npm
- Angular CLI
- SQL Server
- SQL Server Management Studio (SSMS)

## Base de datos

El proyecto incluye el archivo:

```text
DB.sql
```

Este archivo contiene el script necesario para crear y configurar la base de datos utilizada por la aplicación.

### Pasos

1. Abrir SQL Server Management Studio.
2. Conectarse al servidor de SQL Server.
3. Abrir el archivo `DB.sql`.
4. Ejecutar el script completo.
5. Verificar que la base de datos y sus tablas hayan sido creadas correctamente.

## Configuración del API

Antes de ejecutar el API, es necesario revisar la cadena de conexión configurada en:

```text
Api_TaskFlow/appsettings.json
```

La cadena de conexión debe coincidir con la instancia de SQL Server donde fue creada la base de datos.

Por ejemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SERVIDOR;Database=NOMBRE_BASE_DATOS;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Los valores de `Server` y `Database` deben ajustarse de acuerdo con la configuración del equipo donde se ejecute el proyecto.

## Ejecución del API

1. Abrir la solución en **Visual Studio 2022**.
2. Verificar la cadena de conexión en `appsettings.json`.
3. Establecer el proyecto `Api_TaskFlow` como proyecto de inicio.
4. Ejecutar el proyecto desde Visual Studio.

El API quedará disponible en la dirección indicada por Visual Studio al iniciar la aplicación.

## Ejecución del Frontend

El frontend se encuentra en el proyecto Angular.

Abrir una terminal dentro de la carpeta del frontend y ejecutar:

```bash
npm install
```

Una vez instaladas las dependencias, ejecutar:

```bash
ng serve
```

Luego abrir en el navegador:

```text
http://localhost:4200
```

## Funcionalidades

La aplicación permite:

- Consultar el listado de clientes.
- Crear clientes.
- Editar clientes.
- Eliminar clientes.
- Consultar los productos financieros asociados a un cliente.
- Crear y asociar productos financieros a un cliente.
- Consultar el catálogo de tipos de producto.

## Orden recomendado para ejecutar el proyecto

Para utilizar la aplicación correctamente:

1. Crear la base de datos ejecutando `DB.sql`.
2. Configurar la cadena de conexión del API en `appsettings.json`.
3. Ejecutar el API desde Visual Studio 2022.
4. Abrir una terminal en la carpeta del frontend.
5. Ejecutar `npm install` si es la primera ejecución o si las dependencias no están instaladas.
6. Ejecutar `ng serve`.
7. Abrir `http://localhost:4200` en el navegador.

## Versiones

- Backend: **.NET 8**
- Frontend: **Angular**
- IDE utilizado para el backend: **Visual Studio 2022**

