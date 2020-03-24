![TailorITChallenge](http://www.tailorit.com.br/img/tailor-logo.png)

# ASP.NET Core Challenge
Testing application required by TailorIT

## Features

* .NET Core WebAPI 3.1 + JWT Authentication + Angular 9 SPA
* Application structured in DDD
   * Presentation Layer
   * Application Layer
   * Domain Layer
   * Infrastructure Layer
   * Infrastructure - Data Layer
   * Infrastructure - IoC Layer
* EntityFramework Core as ORM

## Installation

### Git

First of all, clone the repository:
```
git clone https://github.com/fabriciodsr/tailorit-challenge.git YOURFOLDERNAME
cd YOURFOLDERNAME
```

## Project Folder Structure

* [tailorit-challenge - Folder containing the project itself](./tailorit-challenge/)
   * [Presentation Layer](./tailorit-challenge/TailorITChallenge.Presentation/)
   * [Application Layer](./tailorit-challenge/TailorITChallenge.Application/)
   * [Domain Layer](./tailorit-challenge/TailorITChallenge.Domain/)
   * [Infrastructure Layer](./tailorit-challenge/TailorITChallenge.Infra/)
   * [Infrastructure - Data Layer](./tailorit-challenge/TailorITChallenge.Infra/TailorITChallenge.Infra.Data/)
   * [Infrastructure - IoC Layer](./tailorit-challenge/TailorITChallenge.Infra/TailorITChallenge.Infra.IoC/)
* [.gitignore - File which contains some files/folder that shouldn't be in Git](./.gitignore)
* [tailorit-challenge.sln - Visual Studio solution](./tailorit-challenge.sln)
* [README.md -- The current text that you're reading now! :)](./README.md)


### Setting up the application

You can simply run the project using the VSCode or the VStudio.
To run the Angular 9 SPA, You can choose between the common way, using ng serve or You can run it directly from the VStudio setting up the Presentation Layer as startup project and then pressing F5.

### Generating the database

Just change the connection in the following file to match your settings: 
* [appsettings.json](./src/StefaniniChallenge.Presentation/appsettings.json)

Now you need to run the migration to generate the whole structure with the following command:
```
dotnet ef database update
```
If you're using Visual Studio (and if you're prefer), just type the following command in the Package Manager Console:
```
Update-Database
```

### When you run the application, it's going to Seed the database with all you need to start using the system.

## URLs

The application is running under the following URL 
```
http://localhost:62226
```


## Credentials

### Application

* JWT User to generate tokens (It's generating automatically by the Angular SPA application at the first request):
```
Username: test
Password: test
```

```