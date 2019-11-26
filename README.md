# :art: Elluris

Elluris é um projeto prova de conceito desenvolvido para a ultima atividade do curso de Analise e Desenvolvimento de Sistemas da Faculdade de Informatica e Administração Paulista (FIAP) em 2019. O objetivo do projeto é apresentar os conhecimentos adquiridos pelos membros do grupo Nodus durantes os estudos da Fase 7 - Ubiquitous Technology.

Elluris é composta de uma aplicação web desenvolvida com Microsoft .NetCore, uma aplicação mobile desenvolvida com Google Flutter, integração entre os sistemas utilizando arquitetura de WebServices no padrão REST e a implementação de um dispositivo de IoT, o Bluetooth Beacon.

Além disso, juntamente com a aplicação será apresentado uma documentação no modelo Bussiness Model Canvas e um video com um Pitch sobre o projeto.

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
1. No terminal "PM >", execute os dois comandos descritos na seção "Comandos/Migrations" deste documento para criar as tabelas.

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
