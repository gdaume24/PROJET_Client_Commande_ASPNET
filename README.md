# Client / Commande API — ASP.NET Core

Backend ASP.NET Core pour une application de gestion de clients et de commandes.

Ce projet est intéressant à garder : il montre une architecture backend plus professionnelle que les petits TP CRUD, avec séparation en couches, persistance SQL Server, authentification JWT, Swagger et tests automatisés.

## Fonctionnalités

- Inscription et connexion utilisateur.
- Génération de token JWT.
- Endpoints protégés par authentification.
- CRUD clients.
- CRUD commandes.
- Consultation des commandes d'un client.
- Validation des DTO avec FluentValidation.
- Gestion globale des exceptions via middleware.
- Documentation Swagger avec support Bearer JWT.

## Stack technique

- C# / .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Bearer Authentication
- Swagger / OpenAPI
- xUnit
- NSubstitute
- FluentAssertions
- Docker Compose pour SQL Server

## Architecture

```text
src/
  Domain/          Entités métier et interfaces de repositories
  Application/     Services applicatifs, DTO, validators, mappers
  Infrastructure/  EF Core, repositories, migrations, Unit of Work
  WebApi/          Controllers, middleware, configuration HTTP/JWT/Swagger

tests/
  Application.Tests/  Tests des services applicatifs
  WebApi.Tests/       Tests des controllers
```

Cette structure met en valeur une approche clean/layered architecture : l'API dépend de l'application, l'application dépend du domaine, et l'infrastructure porte la persistance.

## Projet front associé

Frontend Angular :
https://github.com/gdaume24/ClientCommande_Front

## Configuration locale

Créer un fichier `.env` dans `src/WebApi/` à partir de :

```bash
cp src/WebApi/.env.example src/WebApi/.env
```

Variables attendues :

```env
ASPNETCORE_ENVIRONMENT=Development
DB_SERVER=localhost
DB_PORT=1433
DB_NAME=ClientCommandeDb
DB_USER=sa
DB_PASSWORD=change_me_strong_password
JWT__KEY=change_me_with_a_long_random_secret_key_at_least_32_chars
```

## Lancer SQL Server

Depuis la racine du repo :

```bash
cd db
docker compose up -d
```

Le conteneur expose SQL Server sur `localhost:1433`.

## Lancer l'API

Depuis la racine du repo :

```bash
cd src/WebApi
dotnet run
```

Swagger est disponible en environnement Development :

```text
http://localhost:5000/swagger
```

Selon le profil de lancement local, l'URL peut aussi être :

```text
https://localhost:5001/swagger
```

## Tests

Depuis la racine du repo :

```bash
dotnet test TP_ASP_NET_CORE.sln
```

## Endpoints principaux

```text
POST   /auth/register
POST   /auth/login
GET    /auth/me

GET    /client
POST   /client
GET    /client/{clientId}
PUT    /client/{clientId}
DELETE /client/{clientId}
GET    /client/{clientId}/commandes

GET    /commande
POST   /commande
GET    /commande/{commandeId}
PUT    /commande/{commandeId}
DELETE /commande/{commandeId}
```

## Valeur portfolio

Ce projet montre une vraie base backend .NET : architecture en couches, API REST documentée, sécurité JWT, Entity Framework Core, SQL Server, Unit of Work, repositories et tests. Il est pertinent à présenter avec le frontend Angular associé pour former une application client/commande complète.
