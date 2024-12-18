# depsmvp-web-api 🚀

API desenvolvida para consumir e integrar dados de múltiplas APIs externas, otimizando a comunicação entre serviços.

## 🚧 Este projeto está em construção 🚧

## Requisitos 📋

Antes de executar o projeto, certifique-se de que o **PostgreSQL** está instalado e configurado na sua máquina. O banco de dados é necessário para rodar as migrações e armazenar os dados da aplicação.

## Configuração do `appsettings.json` 🛠️

Antes de iniciar o projeto, você precisa criar um arquivo chamado `appsettings.json` na raiz do seu projeto. Este arquivo deve conter as configurações de conexão com o banco de dados e serviços externos. Aqui está um exemplo do conteúdo esperado para o arquivo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5433;Database=DepsMvpV1;Username=root;Password=postgres"
  },
  "ExternalServices": {
    "BrasilApi": {
      "Url": "https://brasilapi.com.br/api/cnpj/v1/"
    },
    "PortalDaTrasparenciaApi": {
      "BaseUrl": "https://api.portaldatransparencia.gov.br/api-de-dados",
      "EndPoints": {
        "Peps": "/peps?cpf="
      },
      "Header": {
        "Authorization": {
          "Name": "chave-api-dados",
          "Value": "sua_chave_aqui"
        }
      }
    }
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### ⚠️ Importante:
1. Substitua os valores de `DefaultConnection` com os dados do seu banco de dados PostgreSQL.
2. Atualize o valor de `chave-api-dados` em `PortalDaTrasparenciaApi` com sua chave de API.

Certifique-se de que o arquivo está devidamente configurado antes de executar o projeto.

## Passos para rodar o projeto 📝

### 1. Executar as migrações ⚙️

Após clonar o repositório, é necessário rodar as migrações para configurar o banco de dados corretamente. Utilize o comando abaixo:

```bash
dotnet ef migrations add InitialMigration --project ../depsmvp.insfrastructure/depsmvp.insfrastructure.csproj --startup-project ../depsmvp-web-api
```

### 2. Atualizar o banco de dados 📦

Em seguida, rode o comando para aplicar as migrações e atualizar o banco de dados:

```bash
dotnet ef database update --project ../depsmvp.insfrastructure/depsmvp.insfrastructure.csproj --startup-project ../depsmvp-web-api
```

### 3. Inserir um usuário manualmente 👤

Após as migrações, você precisará inserir manualmente um usuário no banco de dados. Execute o seguinte comando SQL:

```sql
INSERT INTO "Users" ("Name", "Email", "Password", "CreatedBy", "CreatedAt")
VALUES ('John Doe', 'johndoe@example.com', 'hashed_password', 'Admin', '2024-10-11');
```

## Licença ⚖️

Este projeto está licenciado sob a [MIT License](LICENSE).

## Autor ✒️

 <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/111009157?s=400&u=ccf989df0bb9cf41495186f2bc0564c1b03b0d4e&v=4" width="100px;" alt=""/>

**Leandro Thiago Ribeiro** 👋

[![GitHub Badge](https://img.shields.io/badge/-LeandroTRibeiro-black?style=flat-square&logo=GitHub&logoColor=white&link=https://github.com/LeandroTRibeiro)](https://github.com/LeandroTRibeiro)

[![Linkedin Badge](https://img.shields.io/badge/-LeandroRibeiro-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/ribeiro-leandro/)](https://www.linkedin.com/in/ribeiro-leandro/)

[![Gmail Badge](https://img.shields.io/badge/-leandrothiago_ribeiro@hotmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:leandrothiago_ribeiro@hotmail.com)](mailto:leandrothiago_ribeiro@hotmail.com)
