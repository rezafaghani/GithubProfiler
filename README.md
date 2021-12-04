<p align="center">
  <a href="" rel="noopener">
 <img width=200px height=200px src="https://i.imgur.com/6wj0hh6.jpg" alt="Project logo"></a>
</p>

<h3 align="center">Github Profile</h3>

<div align="center">

[![Status](https://img.shields.io/badge/status-active-success.svg)]()
[![GitHub Issues](https://img.shields.io/github/issues/kylelobo/The-Documentation-Compendium.svg)](https://github.com/kylelobo/The-Documentation-Compendium/issues)
[![GitHub Pull Requests](https://img.shields.io/github/issues-pr/kylelobo/The-Documentation-Compendium.svg)](https://github.com/kylelobo/The-Documentation-Compendium/pulls)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](/LICENSE)

</div>

---

<p align="center"> This Project is a sample how to use Github Api to get user profile and user repositories
    <br> 
</p>

## 📝 Table of Contents

- [About](#about)
- [Getting Started](#getting_started)
- [Deployment](#deployment)
- [Usage](#usage)
- [Built Using](#built_using)
- [TODO](../TODO.md)
- [Contributing](../CONTRIBUTING.md)
- [Authors](#authors)
- [Acknowledgments](#acknowledgement)

## 🧐 About <a name = "about"></a>

This Project is a sample how to use Github Api to get user profile and user repositories with C# and .Net Core 

## 🏁 Getting Started <a name = "getting_started"></a>

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See [deployment](#deployment) for notes on how to deploy the project on a live system.

### Prerequisites


Install 
- .Net Core 5 
- PostgreSql
- VsCode  ( Or other IDE )


### Installing

A step by step series of examples that tell you how to get a development env running.

- Install .NetCore 5 (sdk)
- Install PostgreSql
- Install VsCode
- Change connectionstring in /Profiler.Api/appsettings.json && /Profiler.Api/appsettings.Development.json
- Move to /Profiler.Api and run this command "dotnet restore"
- Then run "dotnet run" to start application

## 🔧 Running the tests <a name = "tests"></a>

Go to /Profiler.UnitTests and run this command "dotnet test"
### Break down into end to end tests

This test check if the data that get from Github insert correctly to database or not

### And coding style tests

This unit test mock the CreateProfileCommandHandler

## 🎈 Usage <a name="usage"></a>

This is a sample code that usage MediatR pattern and show how to use DDD and versioning on api

## 🚀 Deployment <a name = "deployment"></a>

You can deploy this project on cloude with docker

## ⛏️ Built Using <a name = "built_using"></a>

- [PostgreSql](https://www.postgresql.org/) - Database
- [DotnetCore 5](https://dotnet.microsoft.com/download/) - Server Framework
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Server Environment

## ✍️ Authors <a name = "authors"></a>

- [@rezafaghani](https://github.com/rezafaghani) - Idea & Initial work

See also the list of [contributors](https://github.com/rezafaghani/GithubProfiler/graphs/contributors) who participated in this project.

## 🎉 Acknowledgements <a name = "acknowledgement"></a>

- Hat tip to anyone whose code was used
- Inspiration
- References
