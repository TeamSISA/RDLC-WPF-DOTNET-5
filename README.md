# RDLC-WPF-DOTNET-5
RLDC Reports for .NET WPF apps using ReportViewerCore by Ikosson and db from RJ Code Advance.
## Requisites:
1. SQL Server at least 2017.
2. Microsoft SQL Server Management Studio 18 (recommended).
3. .NET SDK 5.0.100 at least: (https://dotnet.microsoft.com/download).

### After cloning the repo, 
1. Go to SSMS, restore the database from the .bak file.
2. Go to the root folder containing the solution and the projects.
3. Open a terminal, it can be PowerShell, cmd or Git Bash for Windows.
4. You can type `dotnet --version` and the ouptut should be familiar as: `5.0.102`.
5. Type `dotnet restore`.
6. Type `dotnet build Presentation`
7. Type `dotnet run --project Presentation`.
#### Hope you like it!
