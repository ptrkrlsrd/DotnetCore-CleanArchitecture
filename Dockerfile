FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app
# TODO: Improve copying and restoring to allow Docker to cache each step
COPY . .
RUN dotnet restore ./src/API/API.csproj
RUN dotnet restore ./src/Application/Application.csproj
RUN dotnet restore ./src/Infrastructure/Infrastructure.csproj
RUN dotnet restore ./src/Domain/Domain.csproj
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CleanArchitecture.API.dll"]./tests/Application.UnitTests
