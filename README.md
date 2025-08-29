AuthProject API
API de exemplo construída com .NET 8 seguindo os princípios de Clean Architecture, CQRS e as melhores práticas do mercado. Este projeto serve como um modelo para a criação de aplicações robustas, escaláveis e de fácil manutenção.

✨ Visão Geral
O objetivo deste projeto é fornecer uma base sólida para sistemas que necessitam de autenticação, autorização e gerenciamento de usuários, incluindo funcionalidades modernas como verificação em duas etapas e recuperação de senha.

🚀 Tecnologias e Padrões Utilizados
.NET 8: Plataforma de desenvolvimento.

Entity Framework Core 8: ORM para acesso a dados.

Clean Architecture: Design de software para separação de responsabilidades.

CQRS (Command Query Responsibility Segregation): Padrão para separar operações de leitura e escrita.

MediatR: Implementação do padrão Mediator para comunicação desacoplada.

JWT (JSON Web Tokens): Para autenticação e autorização stateless.

Swagger (OpenAPI): Para documentação interativa da API.

xUnit: Framework para testes automatizados.

⚙️ Estrutura do Projeto
O projeto está dividido nas seguintes camadas:

AuthProject.Domain: Contém as entidades de negócio e a lógica de domínio mais pura.

AuthProject.Application: Orquestra os fluxos de trabalho (casos de uso) da aplicação.

AuthProject.Infrastructure: Implementa os detalhes técnicos como acesso a banco de dados, envio de e-mails, etc.

AuthProject.Api: Expõe a aplicação como uma API RESTful.

🏁 Como Começar
(Esta seção será preenchida com as instruções de como configurar e rodar o projeto localmente).