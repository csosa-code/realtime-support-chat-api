# ---------- build ----------
    FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

    WORKDIR /src
    
    COPY *.sln .
    COPY ChatSupport.API/*.csproj ./ChatSupport.API/
    
    RUN dotnet restore
    
    COPY . .
    
    WORKDIR /src/ChatSupport.API
    
    RUN dotnet publish -c Release -o /app/publish
    
    
    # ---------- runtime ----------
    FROM mcr.microsoft.com/dotnet/aspnet:10.0
    
    WORKDIR /app
    
    COPY --from=build /app/publish .
    
    EXPOSE 8080
    
    ENTRYPOINT ["dotnet", "ChatSupport.API.dll"]