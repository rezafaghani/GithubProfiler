# GithubProfiler
sample-toread-and-save-user-repo-in-github

How to run project

1- In first step you need to install .net core version 5 in your os
2- Then install postgresql in your os
3- You need internet to comminucate with github api
4- In project Profiler.Api and files appsettings.Development.json and appsettings.json , change database user and password to your postgresql pass
5- After all if you have a jetbrain rider or visual studio (2019) you can run project Profiler.Api
6- If you just wnt to run projects without IDE you shoul run terminal in directory Profiler.Api and execute this command " dotnet run " then you can access api on 
  address https://localhost:5001 or http:localhost:5000
  
About structure
1- Project IntegrationEventLogEF is for handle logs in sulotion
2- Project Profiler.Api is the rest api and contain commands and query and other bussiness logic
3- Project Profiler.Domain is for domain and aggregate models and all the things that you need to create context
4- Project Profiler.Infrastructure is for comminucate to databse and repositories
5- Project Profiler.UnitTests is for unit tests

About Technologies
1- I use #MediatR, #Dapper, #.netCore-5 Api Versionning ( two version 1 for post data and 2 for search submmited data), #CQRS
2-You can implemented bus event such as RabbitMq to the project
