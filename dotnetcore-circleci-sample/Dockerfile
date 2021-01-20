FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["dotnetcore-circleci-sample/dotnetcore-circleci-sample.csproj", "dotnetcore-circleci-sample/"]
RUN dotnet restore "dotnetcore-circleci-sample\dotnetcore-circleci-sample.csproj"
COPY . .
WORKDIR "/src/dotnetcore-circleci-sample"
RUN dotnet build "dotnetcore-circleci-sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnetcore-circleci-sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnetcore-circleci-sample.dll"]
