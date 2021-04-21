# simple-akka-cs
Simple example that uses Akka .Net

### Running the App
```
Press F5 to run the app from Visual Studio Code

or running in docker
> make _build
> make _run


Then go to: http://localhost:5000/weatherforecast
```


### Useful commands

#### New service creation
```
> dotnet new sln --name Akka
> dotnet new webapi --name Akka.HostApp --output src/Akka.HostApp
> dotnet new nunit --name Akka.HostApp.Tests --output test/Akka.HostApp.Tests
> dotnet sln add src/Akka.HostApp
> dotnet sln add test/Akka.HostApp.Tests
```

#### Setup GitHub workflow
```
> mkdir .github/
> mkdir .github/workflows/
> touch .github/workflows/workflow.yml
```

#### localhost running as https
```
> dotnet dev-certs https --trust
```

#### 
```
> dotnet clean
> dotnet test -c Release
> dotnet publish -c Release
```