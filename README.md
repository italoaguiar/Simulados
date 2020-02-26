
# Simulados
Simulados é um WebSite escrito em C# e asp.net. 

Demo: http://simulados.azurewebsites.net


O Objetivo deste projeto foi criar um website onde os usuários pudessem gerar simulados de provas como Enem, Detran, Concursos, ou até mesmo certificações, com questões aleatórias. Dentro do próprio website, o usuário poderia responder às questões e em seguida obter gráficos acerca de seu desempenho.

![HomePage do Website](https://1.bp.blogspot.com/-PVvsZnnz4e8/XlbCs0HrvNI/AAAAAAAACic/2YjbqQIc28kl6lNAUP9kg1RQYUQlXqyeACLcBGAsYHQ/s1600/simulados.png)

O frontend do website foi escrito utilizando o framework CSS [Metro UI](https://metroui.org.ua/), enquanto o backend, utilizando o já consagrado [bootstrap](https://getbootstrap.com/).

O Banco de dados utilizado neste projeto é o MS SQL Server, utilizando o Entity Framework, uma biblioteca de mapeamento objeto-relacional, para acessar do banco de dados e realizar as operações de CRUD.

[Google Charts](https://developers.google.com/chart) é utilizado para exibir para o usuário as pontuações de cada um dos simulados realizados, através de integração direta via javascript.
![Exemplo simulado enem](https://1.bp.blogspot.com/-QH_pOxvmJLo/XlbDY_omNTI/AAAAAAAACik/WZugIC0mkBgmiDTTfKhhoyXVT-LGfAQTACLcBGAsYHQ/s1600/sim6.png)
