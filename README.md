# CHECKPOINT 2
# DOTNET - API DE FORNECEDORES E VENDEDORES

Este repositório contém o código-fonte do projeto **Checkpoint 2**, desenvolvido como parte da disciplina **Advanced Business Development with .NET**. O objetivo deste projeto é criar uma aplicação em .NET Core com uma API RESTful utilizando boas práticas de arquitetura e desenvolvimento.

## Estrutura do Projeto

O projeto é dividido em diferentes partes, conforme descrito abaixo:

- **CP2.API**: Este é o projeto principal que contém a API desenvolvida utilizando .NET 8.0. Ele expõe os endpoints para operações de CRUD (Create, Read, Update, Delete).
- **CP2.IoC**: Contém a configuração para Injeção de Dependência (IoC - Inversion of Control), facilitando a integração de diferentes serviços dentro da aplicação.

## Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [Git](https://git-scm.com/)

## Clonando o Repositório

Para obter o código, clone o repositório utilizando o seguinte comando:

```bash
git clone https://github.com/nicolasinohue/CP2_DOTNET_API.git
```

## Configuração e Execução

1. **Instale as dependências**:
   No diretório raiz do projeto, execute o seguinte comando para restaurar os pacotes NuGet:
   ```bash
   dotnet restore
   ```

2. **Compilando o projeto**:
   Após a restauração das dependências, compile o projeto executando:
   ```bash
   dotnet build
   ```

3. **Executando a aplicação**:
   Para rodar a aplicação, utilize o comando:
   ```bash
   dotnet run --project CP2.API
   ```

4. **Acessando a API**:
   Após a execução, você pode acessar a API em: `https://localhost:55775/swagger/index.html` (ou outra porta definida).

## Endpoints da API

A API disponibiliza os seguintes endpoints:

- `GET /api/Fornecedor` - Retorna todos os Fornecedores.
- `GET /api/Vendedor` - Retorna todos os Vendedores.
- `GET /api/Fornecedor/{id}` - Retorna um Fornecedor específica.
- `GET /api/Vendedor/{id}` - Retorna um Vendedor específica.
- `POST /api/Fornecedor` - Cria um novo Fornecedor.
- `POST /api/Vendedor` - Cria um novo Vendedor.
- `PUT /api/Fornecedor/{id}` - Atualiza um Fornecedor existente.
- `PUT /api/Vendedor/{id}` - Atualiza um Vendedor existente.
- `DELETE /api/Fornecedor/{id}` - Remove um Fornecedor.
- `DELETE /api/Vendedor/{id}` - Remove um Vendedor.

## Testes

O projeto contém um conjunto de testes unitários para garantir a funcionalidade básica da aplicação. Para executar os testes, utilize:

```bash
dotnet test
```
