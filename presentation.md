
# Developing with ASP.NET on Mac OS X

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

# Other things to cover...

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
