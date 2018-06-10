FROM microsoft/dotnet:2.1-sdk
COPY ./app ./app 
WORKDIR ./app
RUN dotnet build -c Release
ENTRYPOINT ["dotnet", "run", "-c", "Release", "--no-build"]
