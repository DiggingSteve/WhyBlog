FROM microsoft/aspnetcore:2.0 
WORKDIR /app
EXPOSE 8083
COPY ./PublishOutput .
ENTRYPOINT ["dotnet", "WhyBlog.dll"]