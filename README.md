# 🎮 API de Entrenadores Pokémon y Pokémon

Sistema de gestión con dos APIs RESTful construidas con ASP.NET Core 8.0, Entity Framework Core y SQLite para administrar entrenadores Pokémon y sus pokémon capturados.

---

## 📋 Tabla de Contenidos

- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Ejecución Paso a Paso](#-ejecución-paso-a-paso)
- [Endpoints de la API](#-endpoints-de-la-api)

---

## 🛠 Tecnologías

- **Framework**: .NET 8.0
- **ORM**: Entity Framework Core 8.0
- **Base de Datos**: SQLite (desarrollo local)
- **Documentación**: Swagger/OpenAPI

---

## 📁 Estructura del Proyecto

```
API-Pokemon/
├── CadastroTrenadores.Api/          # API de Entrenadores (Puerto 5001)
│   ├── Controllers/
│   │   └── EntrenadoresController.cs
│   ├── Models/
│   │   └── Entrenador.cs
│   ├── DTOs/
│   │   └── EntrenadorDto.cs
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── CadastroTrenadores.Api.http
│
├── CadastroPokemons.Api/            # API de Pokémon (Puerto 5002)
│   ├── Controllers/
│   │   └── PokemonsController.cs
│   ├── Models/
│   │   └── Pokemon.cs
│   ├── DTOs/
│   │   └── PokemonDto.cs
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Program.cs
│   ├── appsettings.json
│   └── CadastroPokemons.Api.http
│
├── ApiPokemon.sln
├── docker-compose.yml
├── .env
└── README.md
```

---

## 🚀 Ejecución Paso a Paso

### Paso 1: Requisitos Previos

Asegúrate de tener instalados:
- [.NET SDK 8.0](https://dotnet.microsoft.com/download) o superior
- Editor de código (VS Code, Visual Studio, etc.)

### Paso 2: Navegar al Proyecto

```bash
cd "C:\Users\TuUsuario\Documents\Trabajo API\API-Pokemon-"
```

### Paso 3: Compilar el Proyecto

```bash
dotnet build
```

### Paso 4: Ejecutar las APIs

Abre dos terminales separados:

**Terminal 1 - API de Entrenadores:**
```bash
cd CadastroTrenadores.Api
dotnet run
```

**Terminal 2 - API de Pokémon:**
```bash
cd CadastroPokemons.Api
dotnet run
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



