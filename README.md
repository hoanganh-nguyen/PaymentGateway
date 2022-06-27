# Payment Gateway
A payment gateway is **the mechanism that reads and transfers payment information from a customer to a merchant's bank account**. Its job is to capture the data, ensure funds are available and get a merchant paid.
This is a API-based application simulating the payment gateway in the processing online payments.

![](https://miro.medium.com/max/1400/1*TAE0v4BfisrT-2l067kPGA.png)


# Technical stack

## Development
 - Visual Studio 2022
 - [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
 - Docker
## Testing & Documentation
- [Specflow](https://specflow.org/benefits/net-6/)
- [FluentValidation](https://fluentvalidation.net/)
- [xUnit](https://xunit.net/)
- [NSubstitute](https://nsubstitute.github.io/)
## CICD
- GitHub Actions
## Infrastructure
This sample will be shortly deploy into AWS with the infrastructure-as-code written in Terraform.


# Run it locally
To run it locally, you may need Visual Studio 2022 or simply [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) 

## Command Line

 Check-out or download it locally
- Go to the **/src** folder
- Restore nuget dependecies
 `dotnet restore PaymentGateway.sln`
 - Build it
 `dotnet build PaymentGateway.sln`
 - Run it
 `cd src\PaymentGateway.Api
 dotnet run`

## Using Docker
If you want to use docker (without install .NET 6 SDK), you need to have Docker installed locally. The dockerfile are available in the /src folder. Here are the basic command to build & run it in docker

- Go to /src folder
- Build
- `docker build -t paymentgateway .`
- Run it
- `docker run paymentgateway`
You could find the additional option to run a docker here: https://docs.docker.com/engine/reference/commandline/cli/

   


