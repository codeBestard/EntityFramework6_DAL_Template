# Entity Framework 6 DAL Template
Generic Repository and Unit of Work Pattern With Entity Framework 6

**Testing projects are coming soon...**

#### Introduction
The Repository Pattern is one of the most popular patterns in an N Layered application. An example of N layer system may consists of Presentation Layer, Service layoer, Business Layer and Data Access Layer. The Repository is an abstraction on top of the Data Access layer. Using Repository/Unit of work pattern, we can hide EF implementation from business layer, and thus it makes our code more test friendly.

If you plan to use **Entity Framework Core**, please checkout [Repository and unit of work patterns for EF Core](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/advanced#repository-and-unit-of-work-patterns) and [In-Memory Database Provider](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory).


##### Pre-reqs and Main Libraries
- [.NET Framework 4.7 C# 7](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7)
- [Entity Framework 6](https://msdn.microsoft.com/en-us/library/aa937723(v=vs.113).aspx)
- [SQL 2008 or above] (https://docs.microsoft.com/en-us/sql/)

#### Steup
1. Open the project/solution in Visual Studio, and open the console using the **Tools > **NuGet Package Manager** > **Package Manager Console command**

2. Enable DB migration
```bash
$ Add-Migration init
```

3. Create dabase
```bash
$ Update-Database –Verbose
```