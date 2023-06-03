# FYS SDK for FYS API

The FYS SDK is a .NET library that provides an easy-to-use interface for interacting with the FYS API. It simplifies the process of integrating your applications with the FYS platform and accessing its features.

## Features

- **Simplified API Calls**: The SDK encapsulates the complexity of API requests and responses, allowing you to make API calls using simple methods.
- **Authentication Handling**: The SDK provides built-in authentication mechanisms and helps you manage authentication tokens or credentials required for accessing the FYS API securely.
- **Error Handling**: Easily handle and manage errors returned by the API, including custom exception types specific to the SDK.
- **High-Level Abstractions**: The SDK provides high-level abstractions and data models that align with the concepts and entities of the FYS API, making it easier to work with the API data.

## Installation

You can install the FYS SDK via [NuGet](https://www.nuget.org/packages/FYS.SDK). Simply run the following command in the Package Manager Console:


## Usage

To get started with the FYS SDK, follow these steps:

1. **Initialize the SDK**: Create an instance of the `SdkClient` class by passing the appropriate configuration options.

   ```csharp
   var configuration = new SdkConfiguration(apiKey, baseUrl);
   var client = new SdkClient(configuration);

2. **Make API Requests:** Use the methods provided by the SdkClient class to interact with the FYS API.
   ```csharp
   var endpoint = "/api/resource";
   var response = await client.GetApiResponseAsync(endpoint);

3. **Handle Responses:** Process the API responses according to your application's requirements.
   ```csharp
	if (!string.IsNullOrEmpty(response))
    {
        // Handle the successful API response
    }
    else
    {
        // Handle the empty or error response
    }

## Testing

The FYS SDK includes a set of unit tests to ensure the correctness and reliability of the library. These tests are written using MSTest, a popular testing framework in the .NET ecosystem.

To run the tests:

1. Open the solution in Visual Studio.
2. Build the solution to restore dependencies and compile the project.
3. Open the Test Explorer window (`Test > Windows > Test Explorer`) in Visual Studio.
4. Click on the "Run All" button in the Test Explorer window to execute all the tests.

You can also run the tests from the command line using the `dotnet test` command:

    
    dotnet test


## Contributing
Contributions to the FYS SDK are welcome! If you find any issues, have feature requests, or want to contribute improvements, please submit them via GitHub issues or create a pull request.

## License
This SDK is released under the MIT License.