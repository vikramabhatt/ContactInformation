# ContactInformation
DotNet Core 2.2 Web API Contact Information

1. This is .Net Core 2.2 Web API.
2. It has 5 actions, Get Contact by Id, Get Contact List, Add Contact, Edit Contact and Delete Contact.
3. Right now no database is used, it is inmemory collection.
4. Swagger is integrated to test this api ... http://localhost:41589/swagger/index.html
5. Dependency injection is done.
6. Serilog logging is implemented with rolling file.
7. AUTs are not written for now... it can be done for unit testing.
8. Authentication is not done for now... it can be done with OAuth bearer token.
9. Owin can be used for self hosting.

To run this application,
1. Open it in .Net IDE 2017 with .Net Core 2.2 framework.
2. ContactInforamtion.Api should be start-up project.
3. Run it in browser and put URL http://localhost:41589/swagger/index.html in address bar.
4. Swagger UI should be available and APIs can be executed.
