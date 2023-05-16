# DomainDrivenDesign-Demo
The source code of the clean coding course in ASP.NET Core

## Features
* Clean Architecture
* DDD Tactical Patterns
* CQRS using MediatR
* Multiple Database (SQL Server + MongoDB)
* FluentValidation
* Web API
* Unit Testing using FluentAssertions

## Packages
* AutoMapper.Extensions.Microsoft.DependencyInjection `v11.0.0`
* MediatR `v9.0.0`
* MediatR.Extensions.Microsoft.DependencyInjection `v9.0.0`
* Microsoft.AspNetCore.Authentication.JwtBearer `v6.0.1`
* Microsoft.AspNetCore.Mvc.Versioning `v5.0.0`
* Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer `v5.0.0`
* Swashbuckle.AspNetCore `v6.2.3`
* FluentValidation `v10.3.6`
* FluentValidation.DependencyInjectionExtensions `v10.3.6`
* Microsoft.AspNetCore.Http.Features `v5.0.13`
* Microsoft.Extensions.DependencyInjection.Abstractions `v6.0.0`
* Microsoft.EntityFrameworkCore.SqlServer `v6.0.1`
* Microsoft.EntityFrameworkCore.Tools `v6.0.1`
* MongoDB.Driver `v2.14.1`
* coverlet.collector `v3.1.0`
* FluentAssertions `v6.2.0`
* Microsoft.NET.Test.Sdk `v16.11.0`
* NSubstitute `v4.2.2`
* xunit `v2.4.1`
* xunit.runner.visualstudio `v2.4.3`

## Getting Started
To run the application:

1. Clone the Project
2. Open Visual Studio and load the Solution
3. Resolve any missing/required nuget package
4. Set `Endpoint.API` as startup project
5. Build Database. Open `Package Manager Console`, set `Clean-arch.Infrastructure` as defualt project and run the following commands: `update-database`
6. That's all... Run the Project!