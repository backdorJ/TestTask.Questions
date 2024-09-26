FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TestWorkQuestions.API/TestWorkQuestions.API.csproj", "TestWorkQuestions.API/"]
COPY ["TestWorkQuestions.Core/TestWorkQuestions.Core.csproj", "TestWorkQuestions.Core/"]
COPY ["TestWorkQuestions.DAL/TestWorkQuestions.DAL.csproj", "TestWorkQuestions.DAL/"]
RUN dotnet restore "TestWorkQuestions.API/TestWorkQuestions.API.csproj"
COPY . .
WORKDIR "/src/TestWorkQuestions.API"
RUN dotnet build "TestWorkQuestions.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TestWorkQuestions.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestWorkQuestions.API.dll"]
