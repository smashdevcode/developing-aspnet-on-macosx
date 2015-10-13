
# Demos

## Install ASP.NET 5

Using Homebrew...

```
brew tap aspnet/dnx
brew update
brew install dnvm
source dnvm.sh
dnvm
dnvm help
dnvm list
```

To install the latest version, run the command `dnvm upgrade`.

## .NET Version Manager (DNVM)

To install a different version

```
dnvm install 1.0.0-beta7
```

Switch to a different version:

```
dnvm use 1.0.0-beta7
dnvm use 1.0.0-beta7 -r coreclr
```

To change your default version:

```
dnvm use 1.0.0-beta7 -p
```

To delete a runtime, just delete it off of the file system

Note: When using coreclr (at least on OS X) you cannot build using the .NET 4.5.1 target.

```
"frameworks": {
  "dnx451": {},
  "dnxcore50": {}
},
```

## Create New Empty Application

```
yo aspnet
```

## .NET Development Utility (DNU)

* Build, package and publish DNX projects
* Building a project produces the binary outputs for the project
* Packaging produces a NuGet package that can be uploaded to a package feed
* Publishing collects all required runtime artifacts (the required DNX and packages)
    into a single folder so that it can be deployed as an application

## Restore

After creating a new application or updating your project's dependencies call DNU
to restore your packages.

```
dnu restore
```

* This also updates the `project.lock.json` file
* The `project.lock.json` file contains all of the dependency graph information for your project

While the packages are loading...

## Visual Studio Code

* Officially Microsoft supported editor
* Built on top of GitHub's Electron shell

## Atom

* Add OmniSharp and you've got another great editor

## DNX Projects

* A DNX project is a folder with a project.json file
* The name of the project is the folder name

## New Project System

Just add/remove files and folders using the file system (no more project file).

## Application Anatomy

* Applications are defined using a public Startup class

```
// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
public void ConfigureServices(IServiceCollection services)
{
}

public void Configure(IApplicationBuilder app)
{
    app.UseStaticFiles();

    //  app.Run(async (context) =>
    //  {
    //      await context.Response.WriteAsync("Hello World Updated Again!");
    //  });
}
```

## Services

You "add" services to your application.

* Services are components intended for common consumption in your application
* Services are made available through dependency injection
* Three varieties of services
 * Singleton (one instance)
 * Scoped (per HTTP request)
 * Transient (per container request)

## Built-In Dependency Injection

DI is built into not just MVC, but into the entire ASP.NET framework and runtime.

## Middleware

Your application will "use" middleware.

* Compose your request pipeline using middleware
* Middleware perform asynchronous logic on an HttpContext
* Optionally invoke the next middleware in the sequence or terminate the request directly
* Use extension methods on IApplicationBuilder to configure middleware

## Web Root

* Root location in your project from which HTTP requests are handled
* "wwwroot" by default (but can be configured)

## Build

```
dnu build
```

Note: This step is not absolutely necessary as calling DNX to run your application
will also kick off a build.

## Broken Builds

* Make sure that your versions line up
* There is a lot of change right now... so mixing and matching versions will often break your apps

## .NET Execution Environment (DNX)

* Software development kit (SDK) and runtime environment
* Provides a host process, CLR hosting logic and managed entry point discovery
* Takes care of hosting the CLR, handling dependencies and bootstrapping your application

## Running the App

```
dnx kestrel
```

## Kestrel

* Server based on libuv
* Nginx can be used as a reserve proxy to forward requests to Kestrel
* See http://druss.co/2015/06/asp-net-5-kestrel-nginx-web-server-on-linux/

## Deploying to Azure

Easy to use the GitHub integration to deploy your application.

Beta6 is the current default version of ASP.NET 5. To ensure that Azure will use Beta7,
we need to add a global.json file in the root of our solution.

Tip: Don't put the global.json file in the root of your project!

Snippet globaljson

```
{
	"projects": [
		"src"
	],
	"sdk": {
		"version": "1.0.0-beta7"
	}
}
```

Since we setup automated deployments from GitHub to Azure, all we need to do is to push our changes.
