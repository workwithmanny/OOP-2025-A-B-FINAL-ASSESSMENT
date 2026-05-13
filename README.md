# RazorPagesMovie - OOP Final Assessment

Student Name: Adeniyi Emmanuel  
Student ID: 71739

## Overview

RazorPagesMovie is an ASP.NET Core Razor Pages application for managing a movie catalog. The project demonstrates object-oriented modelling, Entity Framework Core persistence, Razor Pages CRUD workflows, many-to-many relationships, filtering, database migrations, seed data, and a simple JSON API.

The application stores movies, actors, and the relationships between them. Users can manage movie and actor records through Razor Pages, search the movie catalog, and retrieve movie data through an API endpoint.

## Features

- Movie model with title, release date, genre, price, director, cast, IMDb rating, box office revenue, and release country.
- Actor model with name and date of birth.
- Many-to-many relationship between movies and actors through `MovieActor`.
- CRUD pages for movies.
- CRUD pages for actors.
- Search/filtering on the movie list by title, genre, director, or release country.
- EF Core migrations for database schema updates.
- SQLite database configuration.
- Automatic database migration and seed data on application startup.
- API endpoint for retrieving movies with their actors.
- Bootstrap-based Razor Pages UI with custom styling.

## Technologies Used

- ASP.NET Core Razor Pages
- .NET 8
- Entity Framework Core
- SQLite
- Bootstrap
- C#

## Project Structure

```text
Controllers/
  MoviesApiController.cs      API endpoint for movie data

Data/
  RazorPagesMovieContext.cs   EF Core database context
  DbInitializer.cs            Seed data setup

Models/
  Movie.cs                    Movie entity
  Actor.cs                    Actor entity
  MovieActor.cs               Join entity for movie/actor relationships

Pages/
  Movies/                     Movie CRUD Razor Pages
  Actors/                     Actor CRUD Razor Pages
  Shared/                     Shared layout and validation partials

Migrations/                   EF Core migration history
wwwroot/                      Static CSS, JavaScript, and library assets
```

## Requirements

Install the following before running the project:

- .NET 8 SDK
- SQLite-compatible local environment

## How to Run

From the project root, restore packages and run the application:

```bash
dotnet restore
dotnet run
```

The app will apply pending migrations and seed sample movie data automatically during startup.

After the app starts, open the local URL shown in the terminal, usually:

```text
https://localhost:5001
```

or

```text
http://localhost:5000
```

## Database

The project uses SQLite. The connection string is defined in `appsettings.json`:

```json
"RazorPagesMovieContext": "Data Source=oop-3-b-71739.db"
```

The database is created and updated using Entity Framework Core migrations when the application starts.

## API

The project includes one movie API endpoint:

```http
GET /api/movies
```

This returns the list of movies with their related actors.

Example local URL:

```text
https://localhost:5001/api/movies
```

## Assessment Branches

The assignment required each update to be committed and pushed on its own branch before the final branch. The project includes the following branches:

- `MovieModel`
- `Database-Update`
- `CRUD`
- `AdvancedFiltering`
- `ManyToMany`
- `API`
- `master` - final project branch

## Notes

On startup, the app calls `Database.Migrate()` and then runs `DbInitializer.Seed(context)`. This keeps the local database schema current and adds sample movies if they are not already present.
