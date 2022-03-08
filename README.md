# skinet
There's warning(Unable to verify first certificate) occurs after hit no matter what endpoint (GET, POST, PUT, etc.). Even if they don't need an authorization, even if SSL verfication has turned off, even valid development https cerificate has presented in Trusted Root Certificaton Authorities and even even after add this certificate to CA Certificates in Postman. But anyway each endpoint works great and return consistent response as would expected.

Environment:
Windows 11, 
.NET 6.0.2, 
Angular 13.2.3, 
Node: 16.14.0, 
npm: 8.5.0,
