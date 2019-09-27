# Technical tests for Houston project
> To send us your code, please fork this project and email us with his link. We look your code soon.

> This exercice take up to 45 minutes to complete.

> If needed, complete `.gitignore` file.

# Instructions

Use EF Migration feature to ensure that database is created and has the lastest version.

You need to develop a web application to manage room reservations'. It's necessary to publish in an Azure Web App via a DevOps pipeline.

## Database

1. Hide the connection string! Nobody should be able to see it!
1. Complete `Cegid.Technical.ConsoleApp` to insert 100 persons with different random name (you can use a third-party library).
1. Each person have at least one reservation.
1. Run `Cegid.TechnicalTests.ConsoleApp`.

## Web Application / Micro-service

Create an ASP.NET Core application to see a list of registered persons and their reservations.
A global admin can see everything.
Each user can view their reservations.

You must to transform the ConsoleApp to a repository library or various micro-services/apis.
You can use a server-side and client-side apps with Angular, ReactJs, VueJs or Blazor or a classic architecture (JavaScript, jQuery, Ajax, ...) or a micro-services architecture.

> Be simple.

Example of libraries/packages that you can use:
- Bootstrap
- Modernizr
- Material UI
- `Faker.Data` (or a similar package)
- `Microsoft.EntityFrameworkCore`
- `Microsoft.Extensions.Identity`
- `Microsoft.AspNetCore.Identity.UI`

## CLI
Write the commands you used and describe them in one word. Please use `markdown` syntax.
