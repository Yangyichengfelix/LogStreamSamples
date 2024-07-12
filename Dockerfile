#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["Mac2sAPI/Mac2sAPI.csproj", "Mac2sAPI/"]
#RUN dotnet restore "Mac2sAPI/Mac2sAPI.csproj"
#COPY . .
#WORKDIR "/src/Mac2sAPI"
#RUN dotnet build "Mac2sAPI.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Mac2sAPI.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Mac2sAPI.dll"]

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
RUN apk add -U tzdata
ENV TZ=Europe/Paris
RUN cp /usr/share/zoneinfo/Europe/Paris /etc/localtime
WORKDIR /app
COPY --from=build /app/published-app /app
ENTRYPOINT [ "dotnet", "/app/Mac2sAPI.dll" ]