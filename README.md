# dotnet-three-tier-architecture
 "Three-tier architecture not only remains relevant, but is widely adopted and recommended for most applications. It offers a simplified yet powerful approach, ensuring clear and adaptable interface segregation."

## Module 03 - Developing the Business Layer

### How to work with validation

- Using [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
    - Using the NuGet package manager console within Visual Studio run the following command:
    ```
    Install-Package FluentValidation
    ```
    - Using the .net core CLI from a terminal window:
    ```
    dotnet add package FluentValidation
    ```

Install the FluentValidation package into the DevIO.Business project.

:information_source: Note: We are installing this package directly into the Business project because FluentValidation only depends on the .Net Framework and no other external libraries.