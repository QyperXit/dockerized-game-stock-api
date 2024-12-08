# the base image for the app, which is aspnetcore
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# set the user to the one that the container will run as
USER $APP_UID
# set the working directory in the container to /app
WORKDIR /app
# expose port 8080 and 8081 for the app to listen on
EXPOSE 8080
EXPOSE 8081

# the build image, which is the dotnet sdk
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# set the configuration to build in (e.g. Release, Debug)
ARG BUILD_CONFIGURATION=Release
# set the working directory in the container to /src
WORKDIR /src
# copy the .csproj file into the container
COPY *.csproj ./
# restore the nuget packages
RUN dotnet restore
# copy the source code into the container
COPY . .
# build the app
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# create a new image from the build image
FROM build AS publish
# set the configuration to build in (e.g. Release, Debug)
ARG BUILD_CONFIGURATION=Release
# publish the app
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# create a new image from the base image
FROM base AS final
# set the working directory in the container to /app
WORKDIR /app
# copy the published app from the publish image into this container
COPY --from=publish /app/publish .
# set the entrypoint for the container to start the app
ENTRYPOINT ["dotnet", "GameStore.API.dll"]