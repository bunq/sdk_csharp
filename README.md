# bunq C# SDK
Version 1.13.0

## Introduction
Hi developers!

Welcome to the bunq C# SDK! 👨‍💻

We're very happy to introduce yet another unique product: complete banking SDKs!
Now you can build even bigger and better apps and integrate them with your bank of the free! 🌈

Before you dive into this brand new SDK, please consider:
- Checking out our new developer’s page [https://bunq.com/en/developer](https://bunq.com/en/developer) 🙌  
- Grabbing your production API key from the bunq app or generate a Sandbox API key using [Tinker](https://www.bunq.com/developer) 🗝
- Visiting [together.bunq.com](https://together.bunq.com) where you can share your creations,
questions and experience 🎤

Give us your feedback, create pull requests, build your very own bunq apps and most importantly:
have fun! 💪

This SDK is in **beta**. We cannot guarantee constant availability or stability.
Thanks to your feedback we will make improvements on it.

## Installation
 The `sdk_csharp` is hosted on [nuget](https://www.nuget.org/packages/Bunq.Sdk).
 
```Install-Package Bunq.Sdk```

```dotnet add package Bunq.Sdk```

## Usage

### Creating an API context
In order to start making calls with the bunq API, you must first register your API key and device,
and create a session. In the SDKs, we group these actions and call it "creating an API context". The
context can be created by using the following code snippet:

```
var apiContext = ApiContext.Create(ApiEnvironmentType.SANDBOX, API_KEY, DEVICE_DESCRIPTION);
apiContext.Save();
BunqContext.LoadApiContext(apiContext);
```

**Please note:** initializing your application is a heavy task, therefore, all calls in the example above except for
`LoadApiContext` should be executed once.   

After saving the context, you can restore it at any time:

```
var apiContext = ApiContext.Restore(API_CONTEXT_FILE_PATH);
BunqContext.LoadApiContext(apiContext);
```

**Tip:** both saving and restoring the context can be done without any arguments. In this case the context will be saved
to/restored from the `bunq.conf` file in the same folder with your executable.

#### Example
For an example, see this [tinker snippet](https://github.com/bunq/tinker_csharp/blob/4f57a3c598480788f01c955ae46311283409d130/TinkerSrc/Lib/BunqLib.cs#L59-L82)


##### PSD2
It is possible to create an ApiContext as PSD2 Service Provider. Although this might seem a complex task, we wrote some helper implementations to get you started.
You need to create a certificate and private key to get you started. Our sandbox environment currently accepts all certificates, if these criteria are met:
- Up to 64 characters
- PISP and/or AISP used in the end.
 
Make sure you have your unique eIDAS certificate number and certificates ready when you want to perform these tasks on our production environment. 
Due to the implementation used in this SDK, you should create a .pfx credentials file containing your certificate and private key.
Creating a pfx file can be done with the following command: `openssl pkcs12 -inkey private.pem -in cert.cert -export -out credentials.pfx
`

Creating a PSD2 context is very easy:
```c#
ApiContext apiContext = ApiContext.CreateForPsd2(
    ApiEnvironmentType.SANDBOX, // Could be ApiEnvironmentType.PRODUCTION as well
    SecurityUtils.GetCertificateFromFile(FILE_TEST_CREDENTIALS, TEST_PASSPHRASE_CREDENTIALS),
    SecurityUtils.GetCertificateCollectionFromAllPath(
        new[] { FILE_TEST_CERTIFICATE_CHAIN }
    ),
    TEST_DEVICE_DESCRIPTION,
    new List<string>()
)
```

This context can be saved the same way as a normal ApiContext. After creating this context, create an OAuth client to get your users to grant you access.
For a more detailed example, check the [tinker_csharp](https://github.com/bunq/tinker_csharp/) repository.

#### Safety considerations
The file storing the context details (i.e. `bunq.conf`) is a key to your account. Anyone having
access to it is able to perform any Public API actions with your account. Therefore, we recommend
choosing a truly safe place to store it.

### Making API calls
There is a class for each endpoint. Each class has functions for each supported action. These
actions can be `Create`, `Get`, `Update`, `Delete` and `List`.

Sometimes API calls have dependencies, for instance `MonetaryAccount`. Making changes to a monetary
account always also needs a reference to a `User`. These dependencies are required as arguments when
performing API calls. Take a look at [doc.bunq.com](https://doc.bunq.com) for the full
documentation.

The user dependency will always be determined for you by the SDK. For the monetary account,
the SDK will use your primary account (the one used for billing) if no monetary account id is provided.

#### Creating objects
When creating an object, the default response will be the id of the newly created object.

##### Example
For an example, see this [tinker snippet](https://github.com/bunq/tinker_csharp/blob/4f57a3c598480788f01c955ae46311283409d130/TinkerSrc/MakePayment.cs#L31)

See [`PaymentSample.cs`](https://github.com/bunq/tinker_csharp/blob/4f57a3c598480788f01c955ae46311283409d130/TinkerSrc/MakePayment.cs)

##### NotificationFilters / Callbacks
**Note!** Due to an in internal change in the way we handle `NotificationFilters` (Callbacks), you should not use the default classes included in this SDK. 
Please make sure you make use of the associated `Internal`-classes. For example when you need `NotificationFilterUrlUser`, make use of `NotificationFilterUrlUserInternal`.
You can use every method of these classes, except for the `create()` method. **Always use `createWithListResponse()` instead.**

##### Example
```java
NotificationFilterPushUserInternal.CreateWithListResponse(...)
NotificationFilterUrlUserInternal.CreateWithListResponse(...)
NotificationFilterUrlMonetaryAccountInternal.CreateWithListResponse(...)
```

#### Reading objects
Reading objects can be done via get and list methods. For get a specific object id is needed while for list will return a list of objects.

##### Example
For an example, see this [tinker snippet](https://github.com/bunq/tinker_csharp/blob/4f57a3c598480788f01c955ae46311283409d130/TinkerSrc/Lib/BunqLib.cs#L172-L177)

#### Updating objects
Updating objects through the API goes the same way as creating objects, except that also the object to update identifier
(ID or UUID) is needed.

##### Example
For an example, see this [tinker snippet](https://github.com/bunq/tinker_csharp/blob/4f57a3c598480788f01c955ae46311283409d130/TinkerSrc/UpdateAccount.cs#L28)

#### Deleting objects
When an object has been deleted, the common respinse is an empty response.

#### Example
```
CustomerStatementExport.Delete(customerStatementId);
```

## Running Samples
If you want to play around with the SDK before you actually start implementing something awesome you can use the tinker
project and adjust the code in the scripts as you please.

## Running tests
Information regarding the test cases can be found in the [README.md](./BunqSdk.Tests/README.md)
located in [test](./BunqSdk.Tests).

## Exceptions
The SDK can throw multiple exceptions. For an overview of these exceptions please
take a look at [EXCEPTIONS.md](./BunqSdk/Exception/EXCEPTIONS.md)
 
