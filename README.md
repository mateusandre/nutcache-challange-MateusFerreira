
# Nutcache challange

This is a challange from the company Nutcache where i had to create an API and UI for employees CRUD operations.

## Dependencies

 - .NET 6 
 - EF Core 
 - InMemoryDatabase 
 - FluentValidation 
 - MediatR 
 - AutoMapper
 - Newtonsoft.Json     
 - XUnit     
 - Bogus     
 - Docker

**Front-End**: Blazor

**API**: .NET Core WebApi

# How to execute

Clone this repository to your local machine, open the root directory with terminal and execute: 

    docker-compose up

This will up the WebUi and WebApi containers.

Now the application is avaliable  with these urls:

**UI**: https://localhost:15000/

**API**: https://localhost:8081/swagger/index.html

## Concepts used

 - DDD 
 - Object-oriented programming 
 - SOLID 
 - Mediator pattern 
 - RESTful api design 
 - Repository pattern

## How to execute the tests
From root directory type the following commands:
**Unit tests:**

     cd tests\Nutcache.Application.UnitTests
     dotnet test

**Integration tests:**

    cd tests\Nutcache.WebApi.IntegrationTests
     dotnet test
