# Teste Desenvolvedor .NET

Este projeto tem como objetivo demonstrar uma API para fornecer informações sobre inscrições de candidatos em um vestibular. O projeto foi desenvolvido utilizando .NET, seguindo os princípios de arquitetura limpa e aplicando práticas recomendadas de design de software.

## Arquitetura

### Camadas do Projeto

O projeto segue uma arquitetura em camadas, com separação clara entre as responsabilidades:

- **Domain**: Esta camada contém as entidades e regras de negócio do domínio, bem como os contratos (interfaces) dos repositórios. A lógica central de negócios está completamente isolada do restante da aplicação.
  
- **Application**: Esta camada contém os serviços que implementam a lógica de aplicação. Os serviços orquestram o fluxo de dados entre a camada de domínio e a camada de infraestrutura.

- **Infrastructure**: Esta camada contém a implementação de persistência de dados e outras dependências externas, como o Entity Framework Core para comunicação com o banco de dados.

- **API**: A camada de interface expõe os endpoints REST para interagir com as funcionalidades da aplicação, como o CRUD de entidades, além de consultas específicas, como inscrições por CPF ou por oferta. Esta camada utiliza o ASP.NET Core.

### Princípios Utilizados

- **SOLID**: 
  - **Single Responsibility Principle (SRP)**: Cada classe tem uma única responsabilidade. Por exemplo, o `InscricaoService` é responsável apenas pela lógica de inscrição, enquanto os repositórios lidam exclusivamente com a persistência de dados.
  - **Open/Closed Principle (OCP)**: O sistema foi projetado para ser aberto para extensão, mas fechado para modificação, facilitando a adição de novas funcionalidades sem alterar o comportamento existente.
  - **Dependency Inversion Principle (DIP)**: As classes de serviço dependem de abstrações, e não de implementações concretas, promovendo flexibilidade e testabilidade.

- **Domain-Driven Design (DDD)**: A lógica de negócios está centralizada nas entidades de domínio. Por exemplo, a entidade `InscricaoEntities` contém toda a lógica relacionada à inscrição, como a atualização de status.

- **Clean Architecture**: 
  - O projeto está organizado para que a lógica de negócios esteja isolada das camadas de infraestrutura, facilitando a manutenção e a escalabilidade da aplicação.
  - A camada de aplicação não conhece detalhes de persistência, e vice-versa, promovendo um alto nível de desacoplamento.

## Containerização com Docker e Docker Compose

### Dockerfile

O projeto foi containerizado utilizando Docker. O `Dockerfile` define as instruções para construir a imagem da API .NET. Aqui estão as etapas principais:

1. **Imagem Base**: Usa a imagem oficial do .NET 8.0 para o ambiente de execução e o SDK para compilação.
2. **Build**: A aplicação é compilada e publicada em uma pasta específica.
3. **Imagem Final**: Uma nova imagem é criada com o ambiente de runtime para rodar a aplicação a partir dos artefatos gerados na etapa de build.

### Docker Compose

O `docker-compose.yml` foi utilizado para orquestrar os containers da aplicação e do banco de dados SQL Server. Aqui estão as principais configurações:

- **Serviço de Banco de Dados (`db`)**: Utiliza a imagem do SQL Server 2022 e define as variáveis de ambiente, como usuário e senha. Além disso, expõe a porta 1433 para permitir a conexão.
  
- **Serviço da API (`app`)**: Define a imagem da API .NET gerada pelo Dockerfile, mapeia a porta 8080 para a máquina local e define a dependência do banco de dados, garantindo que a API só seja inicializada após o banco estar disponível.

Com o Docker Compose, a aplicação pode ser facilmente inicializada executando o comando:

```bash
docker-compose up --build
