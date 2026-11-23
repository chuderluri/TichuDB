# TichuDB

## Local Development

### 1. Setup database container locally

```console
$ ./start-dev-db.sh
```

### 2. Make sure dotnet-ef is installed

```console
dotnet tool restore
```

### 3. Create Initial migration scripts if they not already exists

Execute the following command in the ProductionMetric folder:

```console
dotnet ef migrations add InitialCreate
```

### 4. Update database from migrations script

Execute the following command in the ProductionMetric folder:

```console
dotnet ef database update
```
