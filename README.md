![GitHub Logo](/logo.png)
# Sativa
A revolutionary database framework on .NET technology

> Supported DBMS
- MySQL
- PostgreSQL
- SQL Server
- ODBC

> Installation

Package Reference
```xml
<PackageReference Include="Sativa" Version="1.0.0" />
```
Package Manager
```bash
PM> Install-Package Sativa -Version 1.0.0
```
.NET CLI
```bash
> dotnet add package Sativa --version 1.0.0
```
Paket CLI
```bash
> paket add Sativa --version 1.0.0
```
Script & Interactive
```bash
> #r "nuget: Sativa, 1.0.0"
```
Cake Addin
```bash
#addin nuget:?package=Sativa&version=1.0.0
```
Cake Tool
```bash
#tool nuget:?package=Sativa&version=1.0.0
``` 
> Setup Now

Add the connection string according to the database used in *appsettings.json*

- **Database connection example**
```json
{
  "ConnectionStrings": {
     "connstr": "server=localhost; port=3306; database=example; user=root; password=password"
  }
}
```
Fill in the connection string of the `connstr` key according to the database you are using.

Set connection on Startup in *Startup.cs*
```c#
namespace Application
{
    public class Startup
    {
        // Add static property declaration
        public static string connStr
        {
            get;
            private set;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ...
            // Add initialize property
            connStr = Configuration.GetConnectionString("connstr");
        }
    }
}
```