# 📋 Sistema de Gestão de Demandas (Departamento Pessoal) - API

## 💻 Sobre o Projeto
Esta é uma API RESTful desenvolvida em **ASP.NET Core (C#)**, projetada para otimizar e organizar o fluxo de trabalho de um Departamento Pessoal (DP). 

O sistema substitui listas de tarefas genéricas por um gerenciador de demandas corporativas, permitindo o rastreamento de solicitações como "Processar Férias", "Validar Admissão" ou "Atualizar Contratos", controlando o ciclo de vida de cada demanda desde a sua criação até a conclusão.

> **Nota:** Este projeto foi arquitetado tendo como base os requisitos técnicos do desafio "Bootcamp Web Front (Angular + ASP.NET)" da Avanade, aplicando os conceitos exigidos em um cenário real de negócios (B2B).

---

## 🚀 Tecnologias Utilizadas
O back-end foi construído focando em performance, código limpo e padrões de mercado:
* **Framework:** .NET 8 (ASP.NET Core Web API)
* **Linguagem:** C#
* **Banco de Dados:** SQL Server
* **ORM:** Entity Framework Core (Code-First)
* **Documentação:** Swagger (OpenAPI)

---

## ⚙️ Funcionalidades e Endpoints (CRUD)
A API expõe endpoints para gerenciar a entidade principal `Tarefa` (Demanda de DP):

* `POST /api/tarefas` - Cria uma nova demanda no sistema.
* `GET /api/tarefas` - Lista todas as demandas (para alimentar o painel Kanban no Front-end).
* `GET /api/tarefas/{id}` - Busca os detalhes de uma demanda específica.
* `PUT /api/tarefas/{id}` - Atualiza dados ou o status da demanda (Pendente ↔ Concluída).
* `DELETE /api/tarefas/{id}` - Remove uma demanda lançada indevidamente.

---

## 🏗️ Arquitetura e Modelagem de Dados
A entidade central foi modelada para garantir a integridade da regra de negócio:
- `Id` (Inteiro, Chave Primária Autoincremento)
- `Titulo` (Texto, Resumo da solicitação)
- `Descricao` (Texto, Detalhes técnicos e operacionais)
- `Status` (Texto, Padrão: "Pendente")
- `DataCriacao` (DateTime, gerada automaticamente no momento do registro)

A separação de responsabilidades foi aplicada dividindo o projeto em **Models** (Regras e Entidades), **Data** (Contexto e Persistência) e **Controllers** (Roteamento e Respostas HTTP).

---

## 🛠️ Como executar o projeto localmente

### Pré-requisitos
* [.NET SDK](https://dotnet.microsoft.com/download) instalado.
* Instância do **SQL Server** rodando localmente (Express ou LocalDB).

### Passos
1. Clone este repositório:
   ```bash
   git clone [https://github.com/mateusfelixl/gestao-demandas-dp.git](https://github.com/mateusfelixl/gestao-demandas-dp.git)

   Navegue até a pasta do projeto da API.

No arquivo appsettings.json, configure a sua DefaultConnection apontando para o seu SQL Server local.

Abra o terminal na raiz do projeto e execute as Migrations para criar as tabelas no banco de dados:

Bash
dotnet ef database update
Inicie a aplicação:

Bash
dotnet run
Acesse a documentação interativa da API no navegador através da URL gerada no terminal (ex: https://localhost:7xxx/swagger).

Desenvolvido como portfólio para demonstração de habilidades em desenvolvimento .NET e arquitetura de software.
