# Phone number validator

## Requirements

-   [NodeJS v16+ (v18 recommended)](https://nodejs.org/)
-   [.NET 6](https://dotnet.microsoft.com/en-us/download)
-   [Visual Studio 2022](https://visualstudio.microsoft.com/) (Optional)

## Build

#### Using Visual Studio 2022

-   Build or Publish project as normal

#### Using dotnet CLI

-   Build: `dotnet build --configuration Release`
    -   Output: `/bin/Release/net6.0/`
-   Publish: `dotnet publish -p:PublishSingleFile=true --configuration Release --output publish`
    -   Output: `/publish/`

## Running

1. Run the `Cornucopia Phone Validation.exe` located in one of the output directories above.
2. Navigate to the URL shown in the output. Usually: [http://localhost:5000](http://localhost:5000)
