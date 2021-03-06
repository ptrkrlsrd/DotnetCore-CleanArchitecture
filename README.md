 <img align="left" width="116" height="116" src="https://raw.githubusercontent.com/jasontaylordev/CleanArchitecture/master/.github/icon.png" />
 
 # .NET CORE - Clean Architecture Solution Template
![.NET Core](https://github.com/jasontaylordev/CleanArchitecture/workflows/.NET%20Core/badge.svg) [![Build status](https://codingflow.visualstudio.com/CleanArchitecture/_apis/build/status/CleanArchitecture-CI)](https://codingflow.visualstudio.com/CleanArchitecture/_build/latest?definitionId=23) [![Clean.Architecture.Solution.Template NuGet Package](https://img.shields.io/badge/nuget-1.1.1-blue)](https://www.nuget.org/packages/Clean.Architecture.Solution.Template) [![NuGet](https://img.shields.io/nuget/dt/Clean.Architecture.Solution.Template.svg)](https://www.nuget.org/packages/Clean.Architecture.Solution.Template) [![Twitter Follow](https://img.shields.io/twitter/follow/jasontaylordev.svg?style=social&label=Follow)](https://twitter.com/jasontaylordev)

<br/>

This is a solution template for creating an REST API with ASP.NET Core following the principles of Clean Architecture. Create a new project based on this template by clicking the above **Use this template** button or by installing and running the associated NuGet package (see Getting Started for full details). 

Note: This is a fork of Jason Taylor's [project](https://github.com/jasontaylordev/CleanArchitecture) but without Angular, NSwag and with Postgres as a default database instead of SQL Server.

## Technologies

* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1
* MediatR
* AutoMapper
* FluentValidation
* NUnit, FluentAssertions, Moq & Respawn

<!--## Getting Started

The easiest way to get started is to install the [NuGet package](https://www.nuget.org/packages/Clean.Architecture.Solution.Template) and run `dotnet new ca-sln`:

1. Install the latest [.NET Core SDK](https://dotnet.microsoft.com/download)
2. Run `dotnet new --install Clean.Architecture.Solution.Template` to install the project template
3. Create a folder for your solution and cd into it (the template will use it as project name)
4. Run `dotnet new ca-sln` to create a new project
5. Navigate to `src/API` and run `dotnet run` to launch the back end (ASP.NET Core Web API)-->

### Database Configuration

The template is configured to use an in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. Postgres).

If you would like to use Postgres, you will need to update **API/appsettings.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance. 

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

### Database Migrations

To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

* `--project src/Infrastructure` (optional if in this folder)
* `--startup-project src/API`
* `--output-dir Persistence/Migrations`

For example, to add a new migration from the root folder:

 `dotnet ef migrations add "SampleMigration" --project src/Infrastructure --startup-project src/API --output-dir Persistence/Migrations`

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### API

This layer is responsible for the REST API. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.

<img src="https://gist.githubusercontent.com/ptrkrlsrd/f00014f2b953a06926d0b9ad519f1c6f/raw/a9a1c774e6251986e81d78e7184693913a3acd34/domain.svg" />

## License

This project is licensed with the [MIT license](LICENSE).
