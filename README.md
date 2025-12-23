# 🎮 API de Entrenadores Pokémon y Pokémon

Sistema de gestión con dos APIs RESTful construidas con ASP.NET Core 8.0, Entity Framework Core y MySQL para administrar entrenadores Pokémon y sus pokémon capturados.

---

## 📋 Tabla de Contenidos

- [Características](#-características)
- [Tecnologías](#-tecnologías)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Configuración Inicial](#-configuración-inicial)
- [Ejecución Paso a Paso](#-ejecución-paso-a-paso)
- [Endpoints de la API](#-endpoints-de-la-api)
- [Ejemplos de Uso](#-ejemplos-de-uso)
- [Validaciones](#-validaciones)

---

## ✨ Características

### API de Entrenadores (`CadastroTrenadores.Api`)
- ✅ CRUD completo de entrenadores Pokémon
- ✅ Validación de email y teléfono
- ✅ Control de nivel de experiencia (1-100)
- ✅ Gestión de ubicación por ciudad
- ✅ Registro de fecha de inscripción

### API de Pokémon (`CadastroPokemons.Api`)
- ✅ CRUD completo de pokémon
- ✅ Gestión de tipos y estadísticas
- ✅ Control de HP, ataque y defensa
- ✅ Registro de fecha de captura
- ✅ Descripción personalizable

---

## 🛠 Tecnologías

- **Framework**: .NET 8.0
- **ORM**: Entity Framework Core 8.0
- **Base de Datos**: MySQL 8.0 (Pomelo Provider)
- **Documentación**: Swagger/OpenAPI
- **Contenedores**: Docker & Docker Compose
- **Variables de Entorno**: DotNetEnv

---

## 📁 Estructura del Proyecto

```
ApiPokemon/
├── CadastroTrenadores.Api/          # API de Entrenadores
│   ├── Controllers/
│   │   └── EntrenadoresController.cs
│   ├── Models/
│   │   └── Entrenador.cs
│   ├── DTOs/
│   │   └── EntrenadorDto.cs
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Program.cs
│   └── CadastroTrenadores.Api.http
│
├── CadastroPokemons.Api/            # API de Pokémon
│   ├── Controllers/
│   │   └── PokemonsController.cs
│   ├── Models/
│   │   └── Pokemon.cs
│   ├── DTOs/
│   │   └── PokemonDto.cs
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Program.cs
│   └── CadastroPokemons.Api.http
│
├── ApiPokemon.sln
├── docker-compose.yml
├── .env (crear este archivo)
└── README.md
```

---

## ⚙ Configuración Inicial

### 1. Requisitos Previos

Asegúrate de tener instalados:
- [.NET SDK 8.0.416](https://dotnet.microsoft.com/download) o superior
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- Editor de código (VS Code, Visual Studio, etc.)

### 2. Clonar o Descargar el Proyecto

```bash
cd "C:\Users\TuUsuario\Documents"
# Asume que el proyecto ya está en la carpeta ApiPokemon
```

### 3. Crear el Archivo `.env`

En la raíz del proyecto, crea un archivo llamado `.env` con el siguiente contenido:

```env
# Configuración MySQL
MYSQL_HOST=localhost
MYSQL_PORT=3306
MYSQL_ROOT_PASSWORD=root
MYSQL_USER=user
MYSQL_PASSWORD=root
MYSQL_DATA_PATH=./Data

# URLs de las APIs (opcional)
ENTRENADORES_API_URL=http://localhost:5001
POKEMONS_API_URL=http://localhost:5002
```

### 4. Crear la Carpeta de Datos

```bash
mkdir Data
```

---

## 🚀 Ejecución Paso a Paso

### Paso 1: Iniciar MySQL con Docker

```bash
# Navegar a la carpeta del proyecto
cd "C:\Users\Mitthernatch\Documents\Trabajo API\ApiPokemon"

# Iniciar el contenedor MySQL
docker compose up -d mysql
```

**⏱ Espera 30-60 segundos** para que MySQL se inicie completamente.

### Paso 2: Verificar que MySQL está corriendo

```bash
docker ps
```

Deberías ver un contenedor de MySQL corriendo en el puerto 3306.

### Paso 3: Crear las Bases de Datos con Migraciones

```bash
# Crear base de datos para Entrenadores
dotnet ef migrations add InitialCreate --project CadastroTrenadores.Api
dotnet ef database update --project CadastroTrenadores.Api

# Crear base de datos para Pokémon
dotnet ef migrations add InitialCreate --project CadastroPokemons.Api
dotnet ef database update --project CadastroPokemons.Api
```

✅ Esto creará las tablas `Entrenadores` y `Pokemons` en sus respectivas bases de datos.

### Paso 4: Ejecutar las APIs

**Opción A: Ejecutar en terminales separados**

Terminal 1 - API de Entrenadores:
```bash
dotnet run --project CadastroTrenadores.Api
```

Terminal 2 - API de Pokémon:
```bash
dotnet run --project CadastroPokemons.Api
```

**Opción B: Ejecutar en modo background (solo en Linux/Mac)**
```bash
dotnet run --project CadastroTrenadores.Api &
dotnet run --project CadastroPokemons.Api &
```

### Paso 5: Acceder a Swagger

Una vez que las APIs estén ejecutándose:

- **API de Entrenadores**: http://localhost:5001/swagger
- **API de Pokémon**: http://localhost:5002/swagger

---

## 📡 Endpoints de la API

### 🧑‍🦰 API de Entrenadores (Puerto 5001)

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/v1/entrenadores` | Listar todos los entrenadores |
| `GET` | `/api/v1/entrenadores/{id}` | Obtener entrenador por ID |
| `POST` | `/api/v1/entrenadores` | Crear nuevo entrenador |
| `PUT` | `/api/v1/entrenadores/{id}` | Actualizar entrenador |
| `DELETE` | `/api/v1/entrenadores/{id}` | Eliminar entrenador |

### 🐉 API de Pokémon (Puerto 5002)

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/v1/pokemons` | Listar todos los pokémon |
| `GET` | `/api/v1/pokemons/{id}` | Obtener pokémon por ID |
| `POST` | `/api/v1/pokemons` | Registrar nuevo pokémon |
| `PUT` | `/api/v1/pokemons/{id}` | Actualizar pokémon |
| `DELETE` | `/api/v1/pokemons/{id}` | Eliminar pokémon |

---

## 💡 Ejemplos de Uso

### Crear un Entrenador

**Request:**
```http
POST http://localhost:5001/api/v1/entrenadores
Content-Type: application/json

{
  "nome": "Ash Ketchum",
  "email": "ash@pokemon.com",
  "nivel": 50,
  "cidade": "Pueblo Paleta",
  "telefone": "11999887766",
  "dataRegistro": "2025-01-15"
}
```

**Response (201 Created):**
```json
{
  "id": 1,
  "nome": "Ash Ketchum",
  "email": "ash@pokemon.com",
  "nivel": 50,
  "cidade": "Pueblo Paleta",
  "telefone": "11999887766",
  "dataRegistro": "2025-01-15T00:00:00"
}
```

### Registrar un Pokémon

**Request:**
```http
POST http://localhost:5002/api/v1/pokemons
Content-Type: application/json

{
  "nome": "Pikachu",
  "tipo": "Elétrico",
  "nivel": 25,
  "hp": 100,
  "ataque": 55,
  "defesa": 40,
  "dataCaptura": "2025-01-15",
  "descricao": "Pokémon tipo elétrico muy popular"
}
```

**Response (201 Created):**
```json
{
  "id": 1,
  "nome": "Pikachu",
  "tipo": "Elétrico",
  "nivel": 25,
  "hp": 100,
  "ataque": 55,
  "defesa": 40,
  "dataCaptura": "2025-01-15T00:00:00",
  "descricao": "Pokémon tipo elétrico muy popular"
}
```

### Listar Todos los Pokémon

**Request:**
```http
GET http://localhost:5002/api/v1/pokemons
```

**Response (200 OK):**
```json
[
  {
    "id": 1,
    "nome": "Pikachu",
    "tipo": "Elétrico",
    "nivel": 25,
    "hp": 100,
    "ataque": 55,
    "defesa": 40,
    "dataCaptura": "2025-01-15T00:00:00",
    "descricao": "Pokémon tipo elétrico muy popular"
  },
  {
    "id": 2,
    "nome": "Charizard",
    "tipo": "Fogo/Voador",
    "nivel": 55,
    "hp": 180,
    "ataque": 130,
    "defesa": 85,
    "dataCaptura": "2025-02-20T00:00:00",
    "descricao": "Evolução final de Charmander"
  }
]
```

---

## ✅ Validaciones

### Entrenador

| Campo | Validación |
|-------|-----------|
| **nome** | Requerido, 3-200 caracteres |
| **email** | Requerido, formato de email válido, máx. 255 caracteres |
| **nivel** | Requerido, entre 1 y 100 |
| **cidade** | Requerido, 2-100 caracteres |
| **telefone** | Requerido, formato: `11999887766` (DDD + número) |
| **dataRegistro** | Requerido, formato de fecha válido |

### Pokémon

| Campo | Validación |
|-------|-----------|
| **nome** | Requerido, 3-150 caracteres |
| **tipo** | Requerido, máx. 100 caracteres |
| **nivel** | Requerido, entre 1 y 100 |
| **hp** | Requerido, entre 1 y 500 |
| **ataque** | Requerido, entre 1 y 200 |
| **defesa** | Requerido, entre 1 y 200 |
| **dataCaptura** | Requerido, formato de fecha válido |
| **descricao** | Opcional, máx. 500 caracteres |

---

## 🧪 Testing con Archivos .http

El proyecto incluye archivos `.http` para pruebas rápidas con la extensión REST Client de VS Code:

- `CadastroTrenadores.Api/CadastroTrenadores.Api.http`
- `CadastroPokemons.Api/CadastroPokemons.Api.http`

Abre estos archivos en VS Code y haz clic en "Send Request" sobre cada petición.

---

## 🐛 Troubleshooting

### Error: "No se puede conectar a MySQL"
- Verifica que Docker esté corriendo: `docker ps`
- Espera 60 segundos después de iniciar MySQL
- Revisa que el puerto 3306 no esté ocupado

### Error: "Database does not exist"
- Ejecuta las migraciones: `dotnet ef database update --project [Proyecto]`

### Puerto ya en uso
- Cambia los puertos en el archivo `.env`:
  ```env
  ENTRENADORES_API_URL=http://localhost:5003
  POKEMONS_API_URL=http://localhost:5004
  ```

---

## 📝 Notas

- Las APIs usan middleware global para manejo de excepciones
- Los errores se devuelven en formato `ProblemDetails` (RFC 7807)
- La documentación Swagger se genera automáticamente
- Las validaciones se aplican tanto en el modelo como en el DTO

---

## 🎯 Próximos Pasos

1. Agregar autenticación JWT
2. Implementar relación entre Entrenadores y Pokémon
3. Agregar filtros y paginación
4. Implementar caché con Redis
5. Crear tests unitarios y de integración

---

**Desenvolvido con ❤️ y ⚡ por el equipo Pokémon API**
