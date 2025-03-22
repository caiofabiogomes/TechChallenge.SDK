# TechChallenge.SDK

A TechChallenge.SDK é uma biblioteca que fornece infraestrutura para persistência e gerenciamento de contatos, abrangendo desde a configuração do Entity Framework Core com SQL Server até a implementação do padrão repositório com políticas de retry via Polly. Além disso, a biblioteca define mensagens para operações de criação, remoção e atualização de contatos, bem como os modelos de domínio e os Value Objects necessários para garantir a integridade dos dados.

## Sumário

- [Visão Geral](#visão-geral)
- [Recursos](#recursos)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Pré-requisitos](#pré-requisitos)
- [Como Utilizar o Projeto](#como-utilizar-o-projeto)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Testes](#testes)
- [Configuração](#configuração)

## Visão Geral

O TechChallenge.SDK centraliza funcionalidades essenciais para aplicações que gerenciam contatos. Ele abstrai a persistência de dados por meio do Entity Framework Core e SQL Server, e implementa o padrão repositório para a entidade `Contact` com uma política de retry usando Polly. A biblioteca também define mensagens para integração com sistemas de mensageria, facilitando operações de criação, remoção e atualização de contatos. Os modelos de domínio e os Value Objects (como `Name`, `Phone` e `Email`) garantem a integridade e validação dos dados.

## Recursos

- **Persistência de Dados:** Configuração do EF Core por meio do `ContactsDBContext` para gerenciamento da entidade `Contact`.
- **Repositório de Contatos:** Implementação do padrão repositório (`IContactRepository` e `ContactRepository`), incluindo operações de adicionar, atualizar, remover e consultar contatos, com retry policy utilizando Polly.
- **Mensageria:** Definição das mensagens:
  - `CreateContactMessage`
  - `RemoveContactMessage`
  - `UpdateContactMessage`
- **Modelos de Domínio e Value Objects:** 
  - Modelo `Contact` com métodos para atualização dos dados.
  - Value Objects `Name`, `Phone` e `Email` com validações específicas.

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- Polly (para retry policies)
- C#

## Pré-requisitos

- .NET SDK 8.0
- SQL Server (ou outro SGBD compatível com EF Core configurado para SQL Server)
- Uma connection string válida para acesso ao banco de dados

## Como Utilizar o Projeto

Este projeto é uma biblioteca que deve ser integrada à sua aplicação .NET. Para registrar os serviços de persistência e os repositórios do TechChallenge.SDK, utilize o método de extensão `RegisterSdkModule` no container de injeção de dependências, passando a connection string do seu banco de dados.

Exemplo de configuração:

```
services.RegisterSdkModule("SuaConnectionStringAqui");
```

## Estrutura do Projeto

- **TechChallenge.SDK**
  - **SdkModule.cs:**  
    Contém o método de extensão `RegisterSdkModule`, que registra os serviços de persistência e os repositórios.
  - **Infrastructure**
    - **Persistence**
      - `ContactsDBContext.cs`: Contexto do Entity Framework Core configurado para a entidade `Contact`, incluindo definições de mapeamento e propriedades.
      - `ContactRepository.cs`: Implementação do repositório para `Contact` com operações assíncronas e retry policy via Polly.
      - `IContactRepository.cs`: Interface que define os métodos para gerenciamento dos contatos.
    - **Message**
      - `CreateContactMessage.cs`: Mensagem para criação de contatos.
      - `RemoveContactMessage.cs`: Mensagem para remoção de contatos.
      - `UpdateContactMessage.cs`: Mensagem para atualização de contatos.
  - **Domain**
    - **Models**
      - `Contact.cs`: Modelo de domínio que representa um contato, com métodos para atualizar nome, email e telefone, além de validações.
    - **ValueObjects**
      - `Name.cs`: Representa o nome de um contato com propriedades para o primeiro e último nome.
      - `Phone.cs`: Representa o telefone do contato, incluindo validações para DDD e número.
      - `Email.cs`: Representa o email do contato, com validação do formato.

## Configuração

- **Banco de Dados:**  
  Configure a connection string para conectar o EF Core ao SQL Server, garantindo que o `ContactsDBContext` seja inicializado corretamente.
  
- **Injeção de Dependências:**  
  Utilize o método de extensão `RegisterSdkModule` para registrar o contexto do banco de dados e os repositórios no container de serviços da sua aplicação.
  
- **Retry Policy:**  
  O `ContactRepository` utiliza Polly para implementar uma política de retry em operações de persistência, proporcionando maior resiliência contra falhas temporárias.
