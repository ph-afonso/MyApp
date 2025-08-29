#!/bin/bash
# Script para criar a estrutura de projetos da solução AuthProject

echo "Criando a solução..."
dotnet new sln -n AuthProject

echo "Criando os projetos..."
dotnet new classlib -n AuthProject.Domain -o src/AuthProject.Domain
dotnet new classlib -n AuthProject.Application -o src/AuthProject.Application
dotnet new classlib -n AuthProject.Infrastructure -o src/AuthProject.Infrastructure
dotnet new webapi -n AuthProject.Api -o src/AuthProject.Api
dotnet new xunit -n AuthProject.Domain.Tests -o tests/AuthProject.Domain.Tests
dotnet new xunit -n AuthProject.Application.Tests -o tests/AuthProject.Application.Tests

echo "Adicionando projetos à solução..."
dotnet sln AuthProject.sln add src/AuthProject.Domain/AuthProject.Domain.csproj
dotnet sln AuthProject.sln add src/AuthProject.Application/AuthProject.Application.csproj
dotnet sln AuthProject.sln add src/AuthProject.Infrastructure/AuthProject.Infrastructure.csproj
dotnet sln AuthProject.sln add src/AuthProject.Api/AuthProject.Api.csproj
dotnet sln AuthProject.sln add tests/AuthProject.Domain.Tests/AuthProject.Domain.Tests.csproj
dotnet sln AuthProject.sln add tests/AuthProject.Application.Tests/AuthProject.Application.Tests.csproj

echo "Adicionando referências entre os projetos..."
# Application -> Domain
dotnet add src/AuthProject.Application/AuthProject.Application.csproj reference src/AuthProject.Domain/AuthProject.Domain.csproj

# Infrastructure -> Application
dotnet add src/AuthProject.Infrastructure/AuthProject.Infrastructure.csproj reference src/AuthProject.Application/AuthProject.Application.csproj

# Api -> Infrastructure
dotnet add src/AuthProject.Api/AuthProject.Api.csproj reference src/AuthProject.Infrastructure/AuthProject.Infrastructure.csproj

# Tests -> Domain
dotnet add tests/AuthProject.Domain.Tests/AuthProject.Domain.Tests.csproj reference src/AuthProject.Domain/AuthProject.Domain.csproj

# Tests -> Application
dotnet add tests/AuthProject.Application.Tests/AuthProject.Application.Tests.csproj reference src/AuthProject.Application/AuthProject.Application.csproj

echo "Estrutura criada com sucesso!"
