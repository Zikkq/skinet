# skinet
There's warning(Unable to verify first certificate) occurs in Postman after hit no matter what endpoint (GET, POST, PUT, etc.). Even if they don't need an authorization, even if SSL verfication has turned off, even if valid development https cerificate has presented in Trusted Root Certificaton Authorities and even even after add this certificate to CA Certificates in Postman. But anyway each endpoint works great and return consistent response as would expected.

Environment:
.NET 6.0.3, 
Angular 13.2.5, 
Node: 16.14.0, 
npm: 8.5.3

To start backend-part run ```dotnet run``` command from API folder.
To start front-end run ```ng serve``` from client folder.
Then site would appear on localhost:4200
