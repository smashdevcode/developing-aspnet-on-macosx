
# Extra Stuff

## Diagnostics

To view the runtime information...

Add the following dependency to the project:

Snippet d1

```
"Microsoft.AspNet.Diagnostics": "1.0.0-beta7"
```

Snippet d2

```
app.UseRuntimeInfoPage();
```

http://localhost:5000/runtimeinfo

Runtimes and packages are located at `{user directory}/.dnx`.

You can also easily add a welcome page to your app...

```
app.UseWelcomePage();
```

## Serving Static/Default Files

Add the following dependency:

Snippet staticfiles1

```
"Microsoft.AspNet.StaticFiles": "1.0.0-beta7"
```

Then add the following to `Startup.Configure` method:

Snippet staticfiles2

```
app.UseDefaultFiles();
app.UseStaticFiles();
```

_Note: Make sure that the `UseDefaultFiles()` extension method is called first,
otherwise the static file middleware will look for the file and return a 404
if the file is not found._

You can also use the following method which combines the other two:

```
app.UseFileServer();
```

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

And to generate a view...

```
yo aspnet:MvcView Index
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

## Fixing Live Reload

* Visual Studio proper provides this experience out of the box
* On OS X, you have to do a little extra work to get it to work
* John Papa provided a bash script for this purpose
    https://github.com/johnpapa/aspnet5-starter-demo#dnxmon
* Needed to update to support recent changes to dnx
* kmon was also an attempt to fix this
    https://github.com/henriksen/kmon

```
dnxmon
```

## Reverse Package Search

If you are having trouble determining which dependency you need to add to your
project, you can use the following site to do a package search.

https://packagesearch.azurewebsites.net/

## Data Access with Entity Framework 7

Designed as a set of smaller, composable APIs that can be mixed and matched based on the feature set you need

_SQLite is available on OS X (part of the default installation)._

PostgreSQL provider is under development

* http://www.npgsql.org/doc/ef7.html
* http://www.postgresql.org/download/macosx/

Steps to setup using SQLite

1) Add dependencies - Snippet efdepend

```
"EntityFramework.SQLite": "7.0.0-beta7",
"EntityFramework.Commands": "7.0.0-beta7",
"Microsoft.Framework.Configuration.Json": "1.0.0-beta7"
```

2) Add command - Snippet efcommand

```
"ef": "EntityFramework.Commands"
```

3) Add model, context, and repository - Snippets efmodel, efcontext, efirepository, efrepository

4) Add config.json file - Snippet efconfig

5) Update the Startup.cs file

* Add using statements - Snippet efstartupusing
* Add configuration - Snippet efstartupconstructor
* Configure context - Snippet efstartupservices

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

* Form Tag Helpers - http://www.davepaquette.com/archive/2015/05/11/cleaner-forms-using-tag-helpers-in-mvc6.aspx
* Input - http://www.davepaquette.com/archive/2015/05/13/mvc6-input-tag-helper-deep-dive.aspx
* Text Area - http://www.davepaquette.com/archive/2015/05/18/mvc-6-textarea-tag-helper.aspx
* Validation - http://www.davepaquette.com/archive/2015/05/14/mvc6-validation-tag-helpers-deep-dive.aspx
* Label - http://www.davepaquette.com/archive/2015/05/18/mvc-6-label-tag-helper.aspx
* Select - http://www.davepaquette.com/archive/2015/05/18/mvc6-select-tag-helper.aspx
* Form - http://www.davepaquette.com/archive/2015/05/18/mvc-6-form-tag-helper.aspx
* Anchor - http://www.davepaquette.com/archive/2015/06/01/mvc-6-anchor-tag-helper.aspx

Link and Script Tag Helpers

* Globbing
* Cache Busting
* http://www.davepaquette.com/archive/2015/05/06/link-and-script-tag-helpers-in-mvc6.aspx

Image Tag Helper

* Cache Busting
* http://www.davepaquette.com/archive/2015/07/01/mvc-6-image-tag-helper.aspx

Cache

* http://www.davepaquette.com/archive/2015/06/03/mvc-6-cache-tag-helper.aspx

Environment

* http://www.davepaquette.com/archive/2015/05/05/web-optimization-development-and-production-in-asp-net-mvc6.aspx

Setting up custom Tag Helpers

* http://www.davepaquette.com/archive/2015/06/22/creating-custom-mvc-6-tag-helpers.aspx

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

```
ILoggerFactory loggerFactory
loggerFactory.MinimumLevel = LogLevel.Information;
loggerFactory.AddConsole();
loggerFactory.AddDebug();
```
