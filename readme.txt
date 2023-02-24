Packages to be installed for running this project

dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

and install the below in startup project in case of multiple projects in a solution

dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package BCrypt.Net-Next

extra commands for adding and executing migarations

dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update

also install JwtBearer

latest
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.2

works with .net 6.0
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 6.0.13

dotnet ef dbcontext scaffold "Server=.\sqlexpress;Database=SportsEventManagement;TrustServerCertificate=Yes;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models


go to this url for post request

https://localhost:5001/api/auth/login

use the below json for testing in postman

{ 
    "UserName":"johndoe", 
    "Password": "def@123" 
}

dotnet add package BCrypt.Net-Next --version 4.0.3