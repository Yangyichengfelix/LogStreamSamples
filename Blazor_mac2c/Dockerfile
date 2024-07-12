
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["Blazor_mac2c/Blazor_mac2c.csproj", "Blazor_mac2c/"]
#RUN dotnet restore "Blazor_mac2c/Blazor_mac2c.csproj"
#COPY . .
#WORKDIR "/src/Blazor_mac2c"
#RUN dotnet build "Blazor_mac2c.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Blazor_mac2c.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Blazor_mac2c.dll"]

#FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#COPY . .
#RUN dotnet restore
#RUN dotnet publish -c Release -o /app/published-app
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
#WORKDIR /app
#COPY --from=build /app/published-app /app
#ENTRYPOINT [ "dotnet", "/app/Blazor_mac2c.dll" ]


FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY . .
RUN dotnet restore && dotnet publish -c Release -o /app/published-app
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=build /app/published-app /app
ENTRYPOINT [ "dotnet", "/app/Blazor_mac2c.dll" ]