# dotnet-three-tier-architecture
 "Three-tier architecture not only remains relevant, but is widely adopted and recommended for most applications. It offers a simplified yet powerful approach, ensuring clear and adaptable interface segregation."

## Module 03 - Developing the Business Layer

### How to work with validation

Install the FluentValidation package into the DevIO.Business project.

- Using [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
    - Using the NuGet Package Manager Console within Visual Studio run the following command:
    ```
    Install-Package FluentValidation
    ```
    - Using the .net core CLI from a terminal window:
    ```
    dotnet add package FluentValidation
    ```


:information_source: Note: We are installing this package directly into the Business project because FluentValidation only depends on the .Net Framework and no other external libraries.

## Module 04 - Developing the Data Access Layer

Install the Entity Framework Core packages into the DevIO.Data project.

- Using the NuGet Package Manager Console within Visual Studio run the following command:
```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Relational
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

Install the Entity Framework Core tools into the DevIO.Data project.
- Using the NuGet Package Manager Console within Visual Studio run the following command:
```
Install-Package Microsoft.EntityFrameworkCore.Tools
```

Install the Entity Framework Core Design package into the DevIO.Api project.
- Using the NuGet Package Manager Console within Visual Studio run the following command:
```
Install-Package Microsoft.EntityFrameworkCore.Design
```

Command to create the initial migration:
```
Add-Migration InitialMigration
```

Command to update the database:
```
update-database
```
:information_source: Note: We will use the local SQL Server installed by default by Visual Studio. *"Server=(localdb)\\mssqllocaldb"*

## Module 05 - Connecting the Application to the Architecture

Install the AutoMapper packages into the DevIO.Api project.
- Using the NuGet Package Manager Console within Visual Studio run the following command:
```
Install-Package AutoMapper
```
:information_source: Note: The last free version is *"14.0.0"*