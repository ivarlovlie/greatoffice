# Greatoffice

> This codebase and all of its source code is licensed under the GNU General Public License v3.0,
> see [COPYING](COPYING).

This repository contains all the code for greatoffice, a business management system.

The platform aims to equip it's users with tools to do

* project management
* time tracking
* invoicing
* documenting
* ticketing
* task management

Everything is WIP, but the platform is regularly updated
at [https://stage.greatoffice.app](https://stage.greatoffice.app)

## code/api

Contains an ASP.NET Core Web API, each route is specified in the Endpoints directory with a single file per route.

It handles all data operations (except administrative operations) for the platform.

To run it you need .NET 7 and a PostgreSQL instance.

### Database schemas

The application schema is managed and described using entity framework core, to apply the latest migration
use `dotnet ef database update`

> This operation requires that you have the dotnet-ef tools installed, use `dotnet tool install -g dotnet-ef` to do so.
>
> In addition to that it requires you to have populated the required environment variables or enabled flight mode.

Besides the application schema the api also needs a quartz database, sql scripts to create these in postgres is provided
at `code/api/sql/quartz-*.sql`.

I recommend using a seperate database for the quartz schema and app schema, since the app schema is managed by ef core
and the quartz schema is not.

### Environment/Configuration

The api uses Hashicorp's vault to manage it's configuration, environment variables is used to point the api in the
direction of the vault json object that contains the configuration.

The configuration is described
by [`code/api/src/Models/Misc/AppConfiguration.cs`](./code/api/src/Models/Misc/AppConfiguration.cs).

I recommend using [user-secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets) to set environment
variables when developing.

All environment variables the api needs to function properly is specified
in [`code/api/src/Models/Static/AppEnvironmentVariables.cs`](./code/api/src/Models/Static/AppEnvironmentVariables.cs).

#### Minimum required configuration

The following configuration keys need valid values in order to start the api (regardless of environment):

* Starting with DB_
* Starting with EMAIL_FROM_
* Starting with QUARTZ_DB_
* Equal to APP_CERT

> See [`code/api/src/Models/Misc/AppConfiguration.cs`](./code/api/src/Models/Misc/AppConfiguration.cs) for expected
> values.

#### Flight mode

When debugging the application you sometimes don't want to, or are not able to reach the vault for configuration values.
In this case you can set the environment variable `FLIGHT_MODE` to a boolean value of `true`. 

This will configure the api to read configuration from a json file specified at `FLIGHT_MODE_JSON`, defaults
to `flightmode.json`.

### Building and Developing

To run the server in development mode use `dotnet run` (`dotnet watch` for hot-reloading).

To build the server locally use `dotnet build` or `dotnet build -c Release` for production builds.

A helper script is available at [`code/api/build_and_push.sh`](code/api/build_and_push.sh) that handles,

* Optionally commiting, tagging and pushing latest changes to remote git source
* Building a docker image
* Pushing the docker image to the default registry at dr.ivar.systems
* Bumping version number

## code/app

Contains a SvelteKit application that acts as the frontend for greatoffice.

Noteworthy information:

* The ui consists largely of components from or inspired by tailwind ui.
* When you run the frontend in dev mode, most of the available components is showcased standalone at `/book`.
* The app uses [temporal-polyfill](https://github.com/fullcalendar/temporal) to do date and time operations, docs
  is [here](https://tc39.es/proposal-temporal/docs/#api-documentation) (excited to see this api implemented natively
  soon).
* Svelte headless ui is used for some of the components, while the library is great it unfortunately seems to be
  unmaintained and therefore i forked it into `@developermuch/dev-svelte-headlessui` where i publish additions from
  upstream. This package can hopefully be deprecated in the future.

### Environment

The app reads environment variables from [`code/app/.env`](code/app/.env-example), keys need to start with `VITE_`.
> The `.env` file is ignore by default, so you should copy `.env-example` into your own `.env`.

### Building and Developing

To run the app in development mode use `pnpm run dev`.

To build a production build use `pnpm run build`, the production build is placed in the `build` folder.

> Use `node build/index.js` to run the app.
> Node version should be current LTS
