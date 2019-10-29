FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
ENV flower="rose"
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["helloDocker.csproj", ""]
RUN dotnet restore "./helloDocker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "helloDocker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "helloDocker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "helloDocker.dll"]