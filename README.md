# Client / Commande API — ASP.NET Core

Backend C#/.NET pour une application de gestion clients/commandes.

Ce projet sert de démonstrateur backend enterprise : architecture en couches, API REST, Entity Framework Core, SQL Server, authentification JWT et tests automatisés.

## Stack

- C# / ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT authentication
- Docker
- xUnit
- FluentAssertions
- Architecture en couches : Domain, Application, Infrastructure, WebApi

## Fonctionnalités

- Authentification utilisateur et génération de JWT
- Gestion des clients
- Gestion des commandes
- Repositories et Unit of Work
- DTO / requests / responses séparés
- Tests unitaires Application
- Tests de controllers WebApi

## Structure

```text
src/
  Domain/          Entités et interfaces métier
  Application/     Services applicatifs et DTO
  Infrastructure/  EF Core, repositories, migrations
  WebApi/          Controllers, configuration API, auth
tests/
  Application.Tests/
  WebApi.Tests/
```

## Projet front associé

Frontend Angular : https://github.com/gdaume24/ClientCommande_Front

## Valeur portfolio

Ce projet montre ma capacité à concevoir un backend .NET structuré selon des standards professionnels : séparation des responsabilités, persistance EF Core, sécurité JWT, tests automatisés et logique métier client/commande.

## Améliorations possibles

- Ajouter un `docker-compose` complet API + SQL Server.
- Ajouter une documentation Swagger plus détaillée.
- Ajouter une section screenshots via le frontend Angular.
- Nettoyer les tests placeholder `UnitTest1`.
