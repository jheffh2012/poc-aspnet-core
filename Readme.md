# Poc de uso do AspNet MVC Core #

Este repositório contém código em AspNet MVC Core contendo as seguintes caracteristicas:

* Registro de usuários;
* Login de usuários;
* Cadastro de equipes;
* Cadastro de calendários;
* Cadastro de Eventos;
* Confirmação de eventos;
* Integração com API de previsão do tempo hgbrasil (Em ambiente local pode não funcionar, visto que a busca da previsão do tempo é pelo IP);


## Instalando local ##

O banco de dados esta disponível em: .\Database\Poc_AspNet_MVC_Core.mdf;
Também foi disponibilizado o arquivo bkp do banco de dados;
Certifique-se de que o SQL Server Express esteja instalado em sua máquina;
O Arquivo de configuração ".\poc.AspNet.Core.MVC\appsettings.Development.json" deve estar apontando para o banco de dados;