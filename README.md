# Projeto: API de Inscrições para Vestibular

## Descrição
Este projeto consiste em uma API desenvolvida em **C# com ASP.NET Core** para gerenciar inscrições de candidatos em um vestibular. A API permite a gestão de **candidatos, processos seletivos, ofertas de cursos e inscrições**, garantindo a integridade dos dados e o gerenciamento eficiente das informações.

A API foi projetada para ser escalável e de fácil integração com sistemas externos, oferecendo endpoints RESTful para operações CRUD e consultas personalizadas.

## Tecnologias Utilizadas
- **C# .NET 8.0**
- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server**
- **Swagger (Swashbuckle)** para documentação da API
- **Postman** para testes e documentação adicional

## Funcionalidades
- **Gerenciamento de Candidatos**: Cadastro e consulta de candidatos.
- **Processos Seletivos**: Controle de datas de início e término.
- **Ofertas de Cursos**: Registros de cursos e suas respectivas vagas.
- **Inscrições**: Registro de inscrições, verificação de status e filtragem por CPF.

## Endpoints Principais

### Candidatos
- `POST /api/Lead` - Cadastrar um novo candidato.
- `GET /api/Lead` - Listar todos os candidatos.
- `GET /api/Lead/{id}` - Buscar um candidato pelo ID.
- `PUT /api/Lead/{id}` - Atualizar informações de um candidato.
- `DELETE /api/Lead/{id}` - Remover um candidato.

### Ofertas
- `POST /api/Oferta` - Cadastrar uma nova oferta.
- `GET /api/Oferta` - Listar todas ofertas.
- `GET /api/Oferta/{id}` - Buscar uma oferta pelo ID.
- `PUT /api/Oferta/{id}` - Atualizar informações de uma oferta.
- `DELETE /api/Oferta/{id}` - Remover uma oferta.

### Processos Seletivos
- `POST /api/ProcessoSeletivo` - Criar um novo processo seletivo.
- `GET /api/ProcessoSeletivo` - Listar todos os processos seletivos.
- `GET /api/ProcessoSeletivo/{id}` - Buscar um processo seletivo pelo ID.
- `PUT /api/ProcessoSeletivo/{id}` - Atualizar um processo seletivo.
- `DELETE /api/ProcessoSeletivo/{id}` - Remover um processo seletivo.

### Inscrições
- `POST /api/Inscricao` - Realizar uma nova inscrição.
- `GET /api/Inscricao` - Listar todas as inscrições.
- `GET /api/Inscricao/{id}` - Buscar uma inscrição pelo ID.
- `GET /api/Inscricao/cpf/{cpf}` - Buscar inscrições de um candidato pelo CPF.
- `GET /api/Inscricao/oferta/{id}`- Buscar inscrições relacionadas a uma oferta.
- `PUT /api/Inscricao/{id}` - Alterar o status da inscrição
- `DELETE /api/Inscricao/{id}` - Cancelar uma inscrição.

## Como Executar o Projeto
1. **Clonar o Repositório**
   ```bash
   git clone https://github.com/bielaugusto/VestibularApi.git
   ```

2. **Configurar o Banco de Dados**
   - Atualizar a string de conexão no `appsettings.json`.
   - Executar as migrações do Entity Framework:
     ```bash
     dotnet ef database update
     ```

3. **Executar a API**
   ```bash
   dotnet run
   ```

## Link para Explicação do Projeto
[Explicação Detalhada](https://youtu.be/P2c4K0iUiJA)

## Link para a Documentação da API
[Documentação Adicional](https://documenter.getpostman.com/view/29694328/2sAYX2Nj9e#77f229b3-9a47-487d-8669-d1b8c17af7ce)

