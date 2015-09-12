
# Demos

## Install ASP.NET 5

Using Homebrew...

```
brew tap aspnet/dnx
brew update
brew install dnvm
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

TODO - Determine what is necessary for a min project.json file

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
		"source"
	],
	"sdk": {
		"version": "1.0.0-beta7"
	}
}
```

Since we setup automated deployments from GitHub to Azure, all we need to do is to push our changes.

# Extra Stuff

## Using MVC

Add the following dependency:

Snippet mvcdepend

```
"Microsoft.AspNet.Mvc": "6.0.0-beta7"
```

Then update the `Startup` class as follows:

1. Add `using Microsoft.AspNet.Mvc;` statement - Snippet mvcusing
1. Add `services.AddMvc();` to the `ConfigureServices` method - Snippet mvcservice
1. Add `app.UseMvcWithDefaultRoute();` to the `Configure` method - Snippet mvcdefaultroute

You can also explicitly provide your routes:

Snippet mvcroute

```
// Add MVC to the request pipeline.
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");

    // Uncomment the following line to add a route for porting Web API 2 controllers.
    // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
});
```

Then add a POCO controller to the project.

You can also use Yeoman to generate your controller.

```
yo aspnet:MvcController HomeController
```

## Fixing Live Reload

* Visual Studio proper provides this experience out of the box
* On OS X, you have to do a little extra work to get it to work
* John Papa provided a bash script for this purpose
    https://github.com/johnpapa/aspnet5-starter-demo#dnxmon
* Needed to update to support recent changes to dnx
* kmon was also an attempt to fix this
    https://github.com/henriksen/kmon

## Reverse Package Search

https://packagesearch.azurewebsites.net/

## Diagnostics

To view the runtime information...

Add the following dependency to the project:

Snippet d1

```
"Microsoft.AspNet.Diagnostics": "1.0.0-beta7"
```

Snippet d2

`app.UseRuntimeInfoPage();`

http://localhost:5000/runtimeinfo

Runtimes and packages are located at `{user directory}/.dnx`.

## Serving Static/Default Files

Add the following dependency:

Snippet staticfiles1

```
"Microsoft.AspNet.StaticFiles": "1.0.0-beta7"
```

Then add the following to `Startup.Configure` method:

Snippet staticfiles2

```
app.UseStaticFiles();
app.UseDefaultFiles();
```

You can also use the following method which combines the other two:

```
app.UseFileServer();
```

## Error Handling

To see detailed error information...

Snippet error1

```
app.UseErrorPage();
```

A more sophisticated approach...

Snippet error2

```
// Add the following to the request pipeline only in development environment.
if (env.IsDevelopment())
{
    app.UseErrorPage();
}
else
{
    // Add Error handling middleware which catches all application specific errors and
    // send the request to the following path or controller action.
    app.UseErrorHandler("/Home/Error");
}
```

## Data Access with Entity Framework 7

Designed as a set of smaller, composable APIs that can be mixed and matched based on the feature set you need

SQLite is available on OS X (part of the default installation)

PostgreSQL provider is under development
    http://www.npgsql.org/doc/ef7.html
    http://www.postgresql.org/download/macosx/

Steps to setup using SQLite

1) Add dependencies - Snippet efdepend
    "EntityFramework.SQLite": "7.0.0-beta7",
    "EntityFramework.Commands": "7.0.0-beta7",
    "Microsoft.Framework.Configuration.Json": "1.0.0-beta7"
2) Add command - Snippet efcommand
    "ef": "EntityFramework.Commands"
3) Add model, context, and repository - Snippets efmodel, efcontext, efirepository, efrepository
4) Add config.json file - Snippet efconfig
5) Update the Startup.cs file
    a) Add using statements - Snippet efstartupusing
    a) Add configuration - Snippet efstartupconstructor
    b) Configure context - Snippet efstartupservices
6) Update a controller and view - Snippet efcontroller, efview

Tools to browse your database

* DB Browser for SQLite - http://sqlitebrowser.org
* Firefox Add-On SQLite Manager - https://addons.mozilla.org/en-US/firefox/addon/sqlite-manager/

TODO Test using data migrations
TODO Config data access differently for production environment

## Tag Helpers

Enabling tag helpers

```
@addTagHelper "*, Microsoft.AspNet.Mvc.TagHelpers"
```

Form Tag Helpers
    http://www.davepaquette.com/archive/2015/05/11/cleaner-forms-using-tag-helpers-in-mvc6.aspx
    Input
        http://www.davepaquette.com/archive/2015/05/13/mvc6-input-tag-helper-deep-dive.aspx
    Text Area
        http://www.davepaquette.com/archive/2015/05/18/mvc-6-textarea-tag-helper.aspx
    Validation
        http://www.davepaquette.com/archive/2015/05/14/mvc6-validation-tag-helpers-deep-dive.aspx
    Label
        http://www.davepaquette.com/archive/2015/05/18/mvc-6-label-tag-helper.aspx
    Select
        http://www.davepaquette.com/archive/2015/05/18/mvc6-select-tag-helper.aspx
    Form
        http://www.davepaquette.com/archive/2015/05/18/mvc-6-form-tag-helper.aspx

Anchor
    http://www.davepaquette.com/archive/2015/06/01/mvc-6-anchor-tag-helper.aspx

Link and Script Tag Helpers
    Globbing
    Cache Busting
    http://www.davepaquette.com/archive/2015/05/06/link-and-script-tag-helpers-in-mvc6.aspx

Image Tag Helper
    Cache Busting
    http://www.davepaquette.com/archive/2015/07/01/mvc-6-image-tag-helper.aspx

Cache
    http://www.davepaquette.com/archive/2015/06/03/mvc-6-cache-tag-helper.aspx

Environment
    http://www.davepaquette.com/archive/2015/05/05/web-optimization-development-and-production-in-asp-net-mvc6.aspx

Setting up custom Tag Helpers
    http://www.davepaquette.com/archive/2015/06/22/creating-custom-mvc-6-tag-helpers.aspx

## \_ViewImports vs \_ViewStart

* \_ViewStart.cshtml contains all of your global imperative code
* \_ViewImports.cshtml contains all of your declarative statements

## Configuration

```
Configuration = new Configuration()
  .AddJsonFile("config.json")
  .AddEnvironmentVariables();

public IConfiguration Configuration { get; set; }
```

TODO Show options pattern???

## Web API

MVC and Web API have been unified into a single API.

TODO

What exactly does calling AddWebApiConventions() do???
    Also see the Microsoft.AspNet.Mvc.WebApiCompatShim package for clues

## Logging

TODO

Explore how the logger works
    ILoggerFactory loggerFactory
    loggerFactory.MinimumLevel = LogLevel.Information;
    loggerFactory.AddConsole();
    loggerFactory.AddDebug();
