
# Developing with ASP.NET on Mac OS X

TODO

1. Print out demo outline and code snippet prompts
1. Update old README file
1. Keep external partition that has all of the NuGet packages cached
1. Check in code snippets into the presentation repo

Questions

1. Setting up the git SSH keys was really painful...
 1. How can I avoid that??? Install the GitHub client??? Other???
1. Getting my .bash_profile setup was also a miss
 1. Put that onto the VM ahead of time
1. Put my presentation notes on my Surface so that I can reference that during my presentation???
    Is there a way to disable power save so that the tablet will stay on???

Preparation

1. DONE Install Mac OS X on external drive
1. DONE Install Yosemite update
1. Install Xcode, TextExpander, sqlitebrowser, Chrome
1. Setup SSH keys
1. Setup .bash_profile
1. Download presentation slides and PDF
1. Make copy of the partition
1. Setup GitHub repo
1. Setup Azure Web App

# Slides

## Developing with ASP.NET on Mac OS X

## ASP.NET 5

The only thing that's changed is everything.

## ASP.NET 5

* ASP.NET 5 is a significant redesign of ASP.NET
* Fully open source on GitHub (github.com/aspnet/home)
* No longer based on System.Web.dll
* Instead based on a set of granular and well factored NuGet packages
* Pay-for-what-you-use model

## Beta... or Alpha?

It's beta software... well, maybe actually alpha.

* Confusion with the potential misuse of the word "beta"
* Maybe these releases should have been called "alpha"

TODO (show image(s) of frustrated developers... heads in hands, etc.)

## Cross Platform

* Linux, Mac OS X, and Windows
* Everything that we do today will be from Mac OS X
* First time that this is possible using Microsoft supported runtimes and frameworks
* Using Visual Studio proper on Windows is a different experience (though not as
    different as you might expect)

## Demos

## Setup OS X Environment

* Walkthrough the steps

## Visual Studio Code

* Officially Microsoft supported editor
* Built on top of GitHub's Electron shell
* Sublime Text and Atom also work great (thanks to OmniSharp)

## Clone GitHub Repo

This is where we'll put our project.

## DNVM, DNU, and DNX

* DNVM (.NET Version Manager) - Set of command line instructions which allow you to configure your .NET Runtime (i.e. which version of the .NET Execution Framework to use)
* DNX (.NET Execution Framework) - Runtime environment for creating .NET applications
* DNU (.NET Development Utility) - Set of command line tools that allow us to build, package and publish projects created with DNX

## .NET Version Manager (DNVM)

Used to manage versions and flavors of DNX

List of dnx versions: https://github.com/aspnet/dnx/releases

To install a different version

`dnvm install 1.0.0-beta7`

Switch to a different version

```
dnvm use 1.0.0-beta7
dnvm use 1.0.0-beta7 -r coreclr
```

To change your default version

```
dnvm use 1.0.0-beta7 -p
```

Note: When using coreclr you cannot build using the .NET 4.5.1 target

"frameworks": {
  "dnx451": {},
  "dnxcore50": {}
},

## Create New Empty Application

Use Yeoman to scaffold your application

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

## DNX Projects

* A DNX project is a folder with a project.json file
* The name of the project is the folder name

## New Project System

Just add/remove files and folders using the file system (no more project file).

## Application Anatomy

* Applications are defined using a public Startup class

## Services

You "add" services to your application.

* Services are components intended for common consumption in your application
* Services are made available through dependency injection
* Three varieties of services
 * Singleton (one instance)
 * Scoped (per HTTP request)
 * Transient (per container request)

## Middleware

Your application will "use" middleware.

* Compose your request pipeline using middleware
* Middleware perform asynchronous logic on an HttpContext
* Optionally invoke the next middleware in the sequence or terminate the request directly
* Use extension methods on IApplicationBuilder to configure middleware

## Build

Then build your project.

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

Call DNX to run your app

```
dnx kestrel
```

## Kestrel

* Server based on libuv
* Nginx can be used as a reserve proxy to forward requests to Kestrel
* See http://druss.co/2015/06/asp-net-5-kestrel-nginx-web-server-on-linux/

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

`app.UseRuntimeInfoPage();`

http://localhost:5000/runtimeinfo

Runtimes and packages are located at `{user directory}/.dnx`.

## Error Handling

To see detailed error information...

```
app.UseErrorPage();
```

A more sophisticated approach...

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

## Web Root

* Root location in your project from which HTTP requests are handled
* "wwwroot" by default (but can be configured)

## Serving Static/Default Files

Add the following dependency:

```
"Microsoft.AspNet.StaticFiles": "1.0.0-beta7"
```

Then add the following to `Startup.Configure` method:

```
app.UseStaticFiles();
app.UseDefaultFiles();
```

You can also use the following method which combines the other two:

```
app.UseFileServer();
```

## Using MVC

Add the following dependency:

```
"Microsoft.AspNet.Mvc": "6.0.0-beta7"
```

Then update the `Startup` class as follows:

1. Add `using Microsoft.AspNet.Mvc` statement
1. Add `services.AddMvc();` to the `ConfigureServices` method
1. Add `app.UseMvcWithDefaultRoute();` to the `Configure` method

Then add a POCO controller to the project.

You can also use Yeoman to generate your controller.

```
yo aspnet:MvcController HomeController
```

## Built-In Dependency Injection

DI is built into not just MVC, but into the entire ASP.NET framework and runtime.

## Data Access with Entity Framework 7

Designed as a set of smaller, composable APIs that can be mixed and matched based on the feature set you need

SQLite is available on OS X (part of the default installation)

PostgreSQL provider is under development
    http://www.npgsql.org/doc/ef7.html
    http://www.postgresql.org/download/macosx/

Steps to setup using SQLite

1) Add dependencies
    "EntityFramework.SQLite": "7.0.0-beta7",
    "EntityFramework.Commands": "7.0.0-beta7",
    "Microsoft.Framework.Configuration.Json": "1.0.0-beta7"
2) Add command
    "ef": "EntityFramework.Commands"
3) Add model, context, and repository
4) Update the Startup.cs file
    a) Add configuration
    b) Configure context
5) Update a controller and view

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

## Deploying to Azure

Easy to use the GitHub integration to deploy your application.

Beta6 is the current default version of ASP.NET 5. To ensure that Azure will use Beta7,
we need to add a global.json file in the root of our solution.

Tip: Don't put the global.json file in the root of your project!

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

## Roadmap

* Beta8 is the last beta
* RC will follow that
* Currently planning for a November release candidate

## Resources

* ASP.NET Community Standups on YouTube.com

## Thanks

James Churchill
Twitter: @SmashDev
GitHub: smashdevcode








Things to cover...

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

## Improvements

* MVC and Web API have been unified into a single API
* Environment-based configuration
* Built-in dependency injection support
* New file-based project system
* Side-by-side app versioning

## Side-by-Side App Versioning

## Hosts and Servers

* Just announced this week: DNX and Kestrel will be the only released host and server
* IIS (on Windows) or Nginx (on Linux) can be used as reverse proxies to forward requests to Kestrel

## What is .NET Core?

* Modular runtime and library implementation that includes a subset of the .NET Framework
* Consists of a set of libraries, called “CoreFX”, and a small, optimized runtime, called “CoreCLR”
* .NET Core Libraries (CoreFX)
* .NET Core Common Language Runtime (CoreCLR)
* Distributed via NuGet
* CoreFX libraries are factored as individual NuGet packages according to functionality, named “System.[module]”
* CoreFX includes collections, console access, diagnostics, IO, LINQ, JSON, XML, and regular expression support, and more
* .NET Core will not replace Mono

## Why .NET Core?

* Pressure from the server side to reduce the overall footprint, and more importantly, surface area, of the .NET Framework
* You can package and deploy the CoreCLR with your application
* You can host multiple applications side-by-side using different versions of the CoreCLR

## Commands

* A command is a named execution of a .NET entry point with specific arguments

## Application Host

* Typically the first managed entry point invoked by DNX
* Responsible for handling dependency resolution, parsing project.json, providing additional services and invoking the application entry point
* Provides a set of services to applications through dependency injection (for example, IServiceProvider, IApplicationEnvironment and ILoggerFactory)

## Intellisense in Visual Studio Code

* Uses OmniSharp for statement completion
* Current public version 0.7.0 doesn't work with Beta7
* Insiders preview version 0.8.0 fixes the problem
* OmniSharp is bundled with the editor (at least for now)
* Updating the editor is necessary to update OmniSharp

See https://code.visualstudio.com/Home/Connect

Configuring Mac OS X for the Visual Studio Code Insiders Auto-Update

1. Close Code if it is still running.
1. Start the Terminal app.
1. Type cd `~/Library/"Application Support"/Code`
1. Type `nano storage.json`
1. Replace `"updateChannel": "stable"` with `"updateChannel": "insiders"`
1. Save the file and exit via Ctrl-X.

# Logging

TODO

Explore how the logger works
    ILoggerFactory loggerFactory
    loggerFactory.MinimumLevel = LogLevel.Information;
    loggerFactory.AddConsole();
    loggerFactory.AddDebug();
