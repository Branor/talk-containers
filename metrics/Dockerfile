FROM microsoft/dotnet:2.1-sdk AS build
COPY ./webapi ./webapi
WORKDIR /webapi/
RUN dotnet publish -c Release -o output

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
COPY --from=build /webapi/output .
ENTRYPOINT ["dotnet", "webapi.dll"]
