# Ramp Api

### Build and Run  
The application is developed in dotnet core 6 and it can be execuited using 
* VS Code 
* VS Studio IDE 
* Rider IDE

To run the solution in local environment [Download latest .NET Here](https://dotnet.microsoft.com/en-us/download|)

Following is the steps to run the solution in VS Code.
* Open the solution in VS code.
* In terminal, navigate to Ramp folder path 
* Run the following commands in order 
  * dotnet restore
  * dotnet build
  * dotnet run --project API\API.csproj

By default the api is configured to use randome port if you would like to specify one then run following command

* dotnet run --project API\API.csproj --urls=http://localhost:[port number]/

### Docker environment 

In terminal, navigate to /Ramp/API folder path

Run following command `docker compose up` to spin up the api in  docker container. \
Docker container is configured to use port number 8081
Run  `docker compose up` to tear down the environment.

* #### Find the [POSTMAN Collection HERE](https://www.postman.com/collections/53191069f1cfb67e81fc)

### NOTE
On application run the Ramp database is seeded with data. This would help is seeing teh result in `Analytics` endpoint.
Seeded data can be checked using the endpoint `/api/Order/GetOrder`. 