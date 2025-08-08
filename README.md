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
