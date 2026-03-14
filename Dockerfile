# ---------- build ----------
    FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build

    WORKDIR /src
    
    COPY . .
    
    RUN dotnet restore "ChatSupport.API.csproj"
    
    RUN dotnet publish "ChatSupport.API.csproj" -c Release -o /app/publish
    
    
    # ---------- runtime ----------
    FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
    
    WORKDIR /app
    
    COPY --from=build /app/publish .
    
    EXPOSE 8080
    
    ENTRYPOINT ["dotnet", "ChatSupport.API.dll"]