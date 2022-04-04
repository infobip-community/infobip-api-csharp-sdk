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

Call example used to send WhatsApp text message

```csharp
public async Task<WhatsAppSingleMessageInfoResponse> SendWhatsAppTextMessage()
{
    var configuration = new ApiClientConfiguration(
        "https://XYZ.api.infobip.com",
        "YOUR_API_KEY_FROM_PORTAL");

    var client = new InfobipApiClient(configuration);

    var request = new WhatsAppTextMessageRequest
    {
        From = "FROM_NUMBER",
        To = "TO_NUMBER",
        MessageId = "MESSAGE_ID",
        Content = new WhatsAppTextContent("Message Text!")
    };
    return await client.WhatsApp.SendWhatsAppTextMessage(request);
}
```

## Exceptions

There are several exceptions defined and they can be thrown by _InfobipApiClient_ class, if some error occurs when calling an API endpoint:

- _InfobipException_ - Occurs during api endpoint call execution in case of general error.
- _InfobipRequestNotValidException_ - Occurs during api endpoint call execution when request model is not valid.
- _InfobipBadRequestException_ - Occurs during api endpoint call execution when http response status code is _BadRequest_ (400).
- _InfobipUnauthorizedException_ - Occurs during api endpoint call execution when http response status code is _Unauthorized_ (401).
- _InfobipForbiddenException_ - Represents errors that occurs during api endpoint call execution in case when http response status code is _Forbidden_ (403).
- _InfobipNotFoundException_ - Represents errors that occurs during api endpoint call execution in case when http response status code is _NotFound_ (404).
- _InfobipTooManyRequestsException_ - Represents errors that occurs during api endpoint call execution in case when http response status code is _TooManyRequests_ (429).

## Documentation

Infobip API Documentation can be found [here][apidocs].

## Development

Feel free to participate in this open source project by following the standard _fork -> clone -> edit -> pull request_ workflow!

For running _Tests_ you can use **Visual Studio** or your favorite **console**.

To run them from **console**, just change working directory to **src** directory, and run following command.

```shell
 dotnet test
```

[apidocs]: https://www.infobip.com/docs/api
[signup]: https://www.infobip.com/signup
[semver]: https://semver.org
[license]: LICENSE
