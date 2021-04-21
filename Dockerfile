FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /workspace
COPY . .

RUN dotnet test
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /workspace
COPY --from=build /workspace/out ./

ENTRYPOINT ["dotnet", "Akka.HostApp.dll"]