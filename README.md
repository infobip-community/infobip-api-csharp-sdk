# Infobip API C# SDK

This is a C# SDK for Infobip API and you can use it as a dependency to add [Infobip APIs][apidocs] features to your application. To use this, you'll need an Infobip account. If you do not own one, you can create a [free account here][signup].

#### Table of contents:

- [General Info](#general-info)
- [License](#license)
- [Installation](#installation)
- [Usage Example](#usage-example)
- [Documentation](#documentation)
- [Development](#development)

## General Info

For _Infobip API C# SDK_ versioning we use [Semantic Versioning][semver] scheme.

This library is targeting **.NET Standard 2.0**. When a library is built against a certain version of .NET Standard, it can run on any .NET implementation that implements that version of .NET Standard (or higher)

## License

Published under [MIT License](license).

## Installation

To start using the _Infobip API C# SDK_ library add it as dependency to your project.
You should install [Infobip API C# SDK](https://www.nuget.org/packages/Infobip.Api.SDK):

    Install-Package Infobip.Api.SDK

Or via the .NET Core command line interface:

    dotnet add package Infobip.Api.SDK

Either commands, from Package Manager Console or .NET Core CLI, will download and install Infobip API C# SDK and all required dependencies.

## Usage Example

If you are using ASP.NET Core, .NET Core (or .NET in general) _Infobip API C# SDK_ provides extension method `IServiceCollection.AddInfobipClient(Configuration)` which is used to register all needed services needed for a client to work

```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddInfobipClient(Configuration);
}
```

After this, you just simply _inject_ `IInfobipApiClient` into your _service_ class and use it to invoke API endpoints.

```csharp
public class MyWhatsAppService
{
    private readonly IInfobipApiClient _infobipApiClient;

    public MyWhatsAppService(IInfobipApiClient infobipApiClient)
    {
        _infobipApiClient = infobipApiClient;
    }

    public async Task<WhatsAppSingleMessageInfoResponse> SendTextMessage(string from,
        string to,
        string message,
        CancellationToken cancellationToken)
    {
        var request = new WhatsAppTextMessageRequest(from, to,
            Guid.NewGuid().ToString(),
            new WhatsAppTextContent(message));

        return await _infobipApiClient.WhatsApp.SendWhatsAppTextMessage(request,
            cancellationToken);
    }
}
```

## Documentation

Infobip API Documentation can be found [here][apidocs].

## Development

Feel free to participate in this open source project by following the standard _fork -> clone -> edit -> pull request_ workflow!

[apidocs]: https://www.infobip.com/docs/api
[signup]: https://www.infobip.com/signup
[semver]: https://semver.org
[license]: LICENSE
