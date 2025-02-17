# Piscine et Poney

Piscine et Poney is a web application meant to organize the transportation of kids to their activities between their parents.

## Launch project

To launch the backend:

```bash
dotnet run --project PiscineEtPoney.Api
```

## Database

The DB is MariaDb. In case entities or relationships are created or updated, the DB must be updated. Command line to do so is:

```bash
dotnet ef migrations add MigrationLabel --project PiscineEtPoney.Infrastructure --startup-project PiscineEtPoney.Api
dotnet ef database update --project PiscineEtPoney.Infrastructure --startup-project PiscineEtPoney.Api
```

