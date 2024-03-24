#SQL Setup
docker pull mcr.microsoft.com/azure-sql-edge
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 --name azuresqledge -d mcr.microsoft.com/azure-sql-edge
"MSSQLConnection": "Data Source=localhost,1433;Initial Catalog=AppDB;User=SA;Password=yourStrong(!)Password;TrustServerCertificate=True"
dotnet ef migrations add InitialCreate
dotnet ef database update