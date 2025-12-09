# AlfabetizaçãoJá 📚 - Plataforma de Incentivo à Leitura

O **AlfabetizaçãoJá** é uma aplicação web desenvolvida em **.NET 6.0 (MVC)** voltada para o incentivo à leitura e alfabetização infantil. O sistema permite o gerenciamento de histórias ilustradas, salas de aula virtuais e acompanhamento de alunos, oferecendo uma interface amigável para professores e uma área de leitura interativa para os estudantes.

---

## 🛠️ Instalação

Siga os passos abaixo para configurar e rodar o projeto localmente.

### Pré-requisitos

Certifique-se de ter instalado:

* **SDK do .NET 6.0**
* **SQL Server**

### 1. Configuração do Banco de Dados

1.  Crie um novo banco de dados no seu SQL Server (sugerido: `AlfabetizaDB`).
2.  Execute o script principal em `Database/AlfabetizaJaDB.sql` para criar as tabelas (`Login`, `Historia`, `Salas`, `Alunos`) e inserir o usuário administrador padrão.
3.  (Opcional) Execute o script `Database/InsertsHistoria.sql` para popular o banco com histórias iniciais.

### 2. Configuração da Conexão

1.  Navegue até o arquivo `src/AlfabetizaJa/AlfabetizaJa/DAL/ConexaoBD.cs`.
2.  Localize a linha com `new SqlConnection("")` e insira sua string de conexão do SQL Server:
    ```csharp
    banco = new SqlConnection("Server=SEU_SERVER;Database=AlfabetizaDB;User Id=sa;Password=SUA_SENHA;");
    ```

### 3. Execução do Projeto

1.  Navegue até a pasta do projeto:
    ```bash
    cd src/AlfabetizaJa/AlfabetizaJa
    ```
2.  Execute a aplicação:
    ```bash
    dotnet run
    ```
3.  Acesse pelo navegador (geralmente em `http://localhost:5169` ou `https://localhost:7193`).

---

## 🚀 Uso

O sistema é dividido em módulos para gestão e consumo de conteúdo.

### Módulos Principais

* **Login (`/Login`)**: Acesso restrito para professores e administradores.
* **Histórias (`/Historia`)**: CRUD completo de livros/histórias, permitindo upload de capas ilustrativas, título, autor e o texto da obra.
* **Leitura (`/Leitura`)**: Área visual onde as histórias cadastradas são apresentadas para leitura.
* **Salas e Alunos (`/Sala`, `/Professor`)**: Gerenciamento de salas de aula virtuais (com links de reunião) e acompanhamento de alunos e suas notas.

---

## 🎨 Estilo de Codificação

O projeto utiliza o padrão **MVC (Model-View-Controller)** clássico do ASP.NET Core, focando em simplicidade e funcionalidade:

### Backend (.NET 6)

* **DAL (Data Access Layer)**: Acesso a dados centralizado na pasta `DAL`, utilizando `ADO.NET` (SqlClient) e `Dapper` para execução de queries SQL diretas.
* **Controllers**: Controladores separados por responsabilidade (`HistoriaController`, `SalaController`), gerenciando as requisições HTTP e a lógica de upload de arquivos (imagens das histórias).
* **Autenticação**: Uso de **Cookie Authentication** simples para proteger as rotas administrativas.

### Frontend (Razor Views)

* **Razor Views (`.cshtml`)**: Renderização dinâmica de HTML no servidor.
* **Estilização**: Uso de **Bootstrap** para layout responsivo e arquivos CSS customizados (`wwwroot/css/style.css`, `leitor.css`) para a identidade visual infantil e amigável.
* **Interatividade**: Scripts simples em JavaScript/jQuery para validações e manipulação do DOM.
