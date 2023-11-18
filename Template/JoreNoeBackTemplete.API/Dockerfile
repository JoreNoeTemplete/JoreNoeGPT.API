#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
COPY . .
ENTRYPOINT ["dotnet", "JoreNoeBackTemplete.API.dll"]
# ENV ASPNETCORE_ENVIRONMENT Development