# bunq C# SDK

## Introduction
Hi developers!

Welcome to the bunq C# SDK integration tests. Currently we are not
targeting the 100% test coverage, but rather want to be certain that the most
common scenarios can run without any errors.

## Scenarios 
These are the scenarios that are currently being tested:
* Create installation, session-server and device server
* Create a new MonetaryAccount
* Create a tab
* Update the tab
* Create attachment and avatar
* Request money from first MA to second MA
* Accept the request
* Make a transaction from first MA to second MA
* Create connect gr code
* Make a payment to another sandbox user
* Send a chat message in a recent payment
* Delete the current session
* Order a card with a second line

Besides these scenarios, some code of ApiContext, ApiClient and the JSON module 
are also tested.

## Installation
To run the tests, you must first generate a `key.pem` and a `credentials.pfx`. 
Navigate to the `/Resources` directory and execute the following the commands:

```
 openssl req -x509 -newkey rsa:4096 -keyout key.pem -out chain.cert -days 365 -nodes -subj '/CN=My Test App PISP AISP/C=NL
 openssl pkcs12 -inkey key.pem -in chain.cert -export -out credentials.pfx 
```

You will be requested to enter a passphrase. 
Use the passphrase `secret` (as is defined in [`Psd2ApiContextTest.cs`](./BunqSdkCsharpTest/Context/Psd2ApiContextTest.cs)).

## Configuration
To run the tests you must first setup the test configuration JSON. The example
of a configuration file is located at [`Tests/BunqSdkCsharpTest/Resources/config.example.json`](./BunqSdkCsharpTest/Resources/config.example.json).
In order to make use of the configuration file, please copy the example to the
same directory, fill in your sandbox user data and rename the copy to `config.json`.

## Execution
To run tests via Rider, you can right click on the `BunqSdk.Tests` solution and should be able to run
the tests cases form the IDE.
