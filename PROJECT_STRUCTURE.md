AuthProject/
├── src/
│   ├── AuthProject.Domain/               # Camada de Domínio
│   │   ├── Entities/                     # Entidades de negócio (ex: User)
│   │   └── Enums/                        # Enums
│   │   └── ValueObjects/                 # Objetos de Valor
│   │   └── Interfaces/                   # Interfaces de repositórios
│   │
│   ├── AuthProject.Application/          # Camada de Aplicação
│   │   ├── Features/                     # Funcionalidades da aplicação (use cases)
│   │   │   └── Users/
│   │   │       ├── Commands/             # Comandos (Create, Update, Delete)
│   │   │       └── Queries/              # Consultas (GetById, GetAll)
│   │   ├── DTOs/                         # Data Transfer Objects
│   │   ├── Mappers/                      # Mapeamentos (ex: AutoMapper)
│   │   └── Interfaces/                   # Interfaces de serviços (ex: IEmailService)
│   │
│   ├── AuthProject.Infrastructure/       # Camada de Infraestrutura
│   │   ├── Persistence/                  # Configuração do banco de dados (EF Core)
│   │   │   ├── Repositories/             # Implementação dos repositórios
│   │   │   └── Migrations/               # Migrations do EF Core
│   │   ├── Services/                     # Implementação de serviços externos (Email, SMS)
│   │   └── Auth/                         # Lógica de autenticação (JWT)
│   │
│   └── AuthProject.Api/                  # Camada de Apresentação (API)
│       ├── Endpoints/                    # Definição dos Minimal Endpoints
│       ├── Middlewares/                  # Middlewares customizados
│       └── Program.cs                    # Configuração e inicialização da API
│
├── tests/
│   ├── AuthProject.Domain.Tests/         # Testes unitários para o Domínio
│   └── AuthProject.Application.Tests/    # Testes unitários para a Aplicação
│
└── AuthProject.sln                       # Arquivo da Solução