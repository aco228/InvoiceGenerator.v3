FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InvoiceGenerator/InvoiceGenerator.csproj", "InvoiceGenerator/"]
RUN dotnet restore "InvoiceGenerator/InvoiceGenerator.csproj"
COPY . .
WORKDIR "/src/InvoiceGenerator"
RUN dotnet build "InvoiceGenerator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InvoiceGenerator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InvoiceGenerator.dll"]
