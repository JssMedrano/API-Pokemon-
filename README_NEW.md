# 🎮 API de Entrenadores Pokémon y Pokémon

Sistema de gestión con dos APIs RESTful construidas con ASP.NET Core 8.0, Entity Framework Core y SQLite para administrar entrenadores Pokémon y sus pokémon capturados.

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

### Requisitos Previos
- [.NET SDK 8.0](https://dotnet.microsoft.com/download) o superior

### Paso 1: Navegar al Proyecto

```bash
cd "C:\Users\TuUsuario\Documents\Trabajo API\API-Pokemon-"
```

### Paso 2: Compilar el Proyecto

```bash
dotnet build
```

### Paso 3: Ejecutar las APIs

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

**Salida esperada:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5001
```

### Paso 4: Acceder a Swagger

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

## 📝 Notas

- Las APIs usan bases de datos SQLite locales
- La documentación Swagger se genera automáticamente
- Los archivos `.http` incluidos permiten pruebas rápidas con VS Code

---

**Desenvolvido con ❤️ y ⚡**
