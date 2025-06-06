#dotnet restore
#dotnet build -c Release
#dotnet test FileTests.Test/bin/Release/net8.0/FileTests.Test.dll --logger "trx;LogFileName=filetests.trx"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app

ARG PROJECT_NAME=""
ARG BUILDCONFIG=Release
ARG VERSION=1.0.0

# publish enviroment configs
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false


# copy csproj and restore as distinct layers
COPY ./Copies/ ./Copies/
COPY ./Dclgens/ ./Dclgens/
COPY ./IA_ConverterCommons/ ./IA_ConverterCommons/
COPY ./${PROJECT_NAME}/ ./${PROJECT_NAME}/

RUN dotnet restore ${PROJECT_NAME}/${PROJECT_NAME}.csproj

# publish building

# Ubuntu
RUN dotnet publish ${PROJECT_NAME}/${PROJECT_NAME}.csproj --self-contained --runtime linux-x64 -c $BUILDCONFIG -o out /p:Version=$VERSION




# Runtime Image
# Ubuntu
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy files from publish to runtime
COPY --from=base /app/out .
COPY ./SharedLibs ./SharedLibs

# Define env locale variables to pt_BR
RUN apt update && \
    apt install -y locales && \
    apt install -y libxml2 && \ 
    rm -rf /var/lib/apt/lists/*

#Copy DB2 License
COPY ./IA_ConverterCommons/License /app/clidriver/license/

RUN sed -i '/pt_BR.UTF-8/s/^# //g' /etc/locale.gen && \
    locale-gen pt_BR.UTF-8

ENTRYPOINT ["dotnet", "${PROJECT_NAME}.dll"]