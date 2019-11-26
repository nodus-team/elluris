## :coffee: Requisitos

- Visual Studio 17 / Visual Studio 19 / Visual Studio Code
- .NetCore 2.2 SDK
- Microsoft SQL Server Express
- SQL Server Management Studio / Azure Data Studio

## :electric_plug: Instruções

#### Banco de dados

1. Crie um novo banco de dados no seu servidor local.
1. Execute o comando descrito na seção "Comandos/DataBase" deste documento.

#### Visual Studio

1. Clique com o botão direito no projeto web "Nodus.Elluris.Mvc" e defina como projeto inicial de inicialização.
1. Abra o arquivo "appsettings.json" e redefina a string de conexão para o seu banco de dados local.
1. Clique no menu "Ferramentas" > "Gerenciador de Pacotes do NuGet" > "Console do Gerenciador de Pacotes".
1. No terminal "PM >", execute os dois comandos descritos na seção "Comandos/Migrations" deste documento.
1. Desta forma, os tabelas necessárias serão criadas no seu banco de dados.

#### CommandLine

Em Breve.

## :scroll: Comandos

:heavy_check_mark: Database:

```SQL
CREATE DATABASE <NomeDoBancoDeDados>
```

:heavy_check_mark: Migrations:

```SQL
Update-Database -Context NodusArtDbContext -v
Update-Database -Context ApplicationDbContext -v
```
