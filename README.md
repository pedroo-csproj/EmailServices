# EmailServices

[![MIT License](https://img.shields.io/github/license/dotnet/aspnetcore?color=%230b0&style=flat-square)](https://github.com/pedro-octavio/EmailServices/blob/main/LICENSE)

**EmailServices** is a library to facility the email sending in **.Net** projects.

## Tech

**EmailServices** uses a number of open source projects to work properly:

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [.Net](https://docs.microsoft.com/en-us/dotnet/)
- [Git](https://git-scm.com/)

## Installation

**EmailServices** requires [.Net Framework](https://docs.microsoft.com/en-us/dotnet/framework/install/guide-for-developers#:~:text=1%20Open%20the%20download%20page%20for%20the%20.NET,architecture%2C%20and%20then%20choose%20Next.%20More%20items...%20) 6+ to run.

### Nuget Package manager
```sh
Install-Package Octasharp.EmailServices
```

### .Net CLI
```sh
dotnet add package Octasharp.EmailServices
```

You can see more ways to install **EmailServices** in your project [here](https://www.nuget.org/packages/Octasharp.EmailServices/).

## Implementing

### Add DI Namespace

```sh
using EmailServices.DI;
```

### Add Project Dependency Injection

```sh
builder.Services.AddEmailServices(builder.Configuration);
```

### Add Interfaces and Models Namespace

```sh
using EmailServices.Interfaces;
using EmailServices.Models;
```

### Inject IMailServices

```sh
public ClassName(IMailServices mailServices) =>
    _mailServices = mailServices;

private readonly IMailServices _mailServices;
```

### Instance a new MailRequestModel

```sh
var mailRequest = new MailRequestModel("receiver@email.com", "subject", "email <strong>body</strong>.");
```

### It's all done! Just send your email

```sh
await _mailServices.SendAsync(mailRequest, cancellationToken);
```

```sh
_mailServices.Send(mailRequest);
```