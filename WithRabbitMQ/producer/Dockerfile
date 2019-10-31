#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 81

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["rabbitProducer.csproj", ""]
RUN dotnet restore "./rabbitProducer.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "rabbitProducer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "rabbitProducer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "rabbitProducer.dll"]