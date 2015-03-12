
# Developing ASP.NET on Mac OS X

* Quick ASP.NET 5 Overview
* Installing ASP.NET
* Using OmniSharp for Development
* Using Yeoman to generate an ASP.NET project

## TODO

1. Review the installation instructions and make sure that they still work for the latest version of ASP.NET
1. Show some of the KVM commands and why you would use them
1. Show how to run the ASP.NET samples
1. Show where packages are kept
1. Try the various ASP.NET Yeoman templates (i.e. controllers, views, etc.)

## Random Notes

1. Had to install Grunt in order for the `kpm restore` to work on the ASP.NET Yeoman project
1. Had to increase the max open file limits [http://docs.basho.com/riak/latest/ops/tuning/open-files-limit/](http://docs.basho.com/riak/latest/ops/tuning/open-files-limit/)
 1. After creating those configuration files, I had to then restart
 1. Then the user file limits were change (confirmed by running command `ulimit -a`)

## Quick ASP.NET 5 Overview

See [http://gunnarpeipman.com/2014/10/asp-net-5-what-are-kre-kvm-kpm/](http://gunnarpeipman.com/2014/10/asp-net-5-what-are-kre-kvm-kpm/)

ASP.NET 5 comes with new runtime environment called KRE. There are also tools for managing KRE versions and NuGet packages that your application uses.

K has three components:

* KRE – K Runtime Environment is the code required to bootstrap and run an ASP.NET 5 application. This includes things like the compilation system, SDK tools, and the native CLR hosts.
* KVM – K Version Manager is for updating and installing different versions of KRE. KVM is also used to set the default KRE version.
* KPM – K Package Manager manages packages needed by applications to run. Packages in this context are NuGet packages.

## Installing ASP.NET

Get ASP.NET for your platform [https://github.com/aspnet/Home](https://github.com/aspnet/Home)

### Mac OS X Requirements

* Mono 3.4.1 or later
* bash or zsh and curl

### Install Node.js

TODO

### Install Grunt

TODO

### Install Yeoman

TODO

### Install Homebrew

See [Homebrew](http://brew.sh)

* Run command `brew help` to check if Homebrew is already installed
* Install Homebrew
* Run command `brew doctor` immediately after installation completes

### Install the K Version Manager (KVM)

To install KVM and the correct version of Mono using [Homebrew](http://brew.sh) use the following steps:

 * Run command `brew tap aspnet/k` to tap the ASP.NET 5 related git repositories. If you had already tapped the repo for previous releases, run `brew untap aspnet/k` to delete the old commands and tap again to get the updated brew scripts.
 * Run command `brew install kvm` to install KVM. This also automatically install the latest KRE package from https://www.nuget.org/api/v2 feed.
 * Run command `source kvm.sh` on your terminal if your terminal cannot understand kvm.

### Install the K Runtime Environment (KRE)

Now that you have KVM setup you can install the latest version of the runtime by running the following command: ```kvm upgrade```

This command will download the specified version of the K Runtime Environment (KRE), and put it on your user profile ready to use. You are now ready to start using ASP.NET 5!

### Running the samples

TODO Need to edit/rewrite

1. Clone the Home repository
2. Change directory to the folder of the sample you want to run
3. Run ```kpm restore``` to restore the packages required by that sample.
4. You should see a bunch of output as all the dependencies of the app are downloaded from MyGet.
5. Run the sample using the appropriate K command:
    - For the console app run  ```k run```.
    - For the web apps run ```k web``` on Windows or ```k kestrel``` on Mono.
6. You should see the output of the console app or a message that says the site is now started.
7. You can navigate to the web apps in a browser by going to "http://localhost:5001" or "http://localhost:5004" if running on Mono.

## Using OmniSharp for Development

Steps to install Kulture for Sublime Text 3 [https://github.com/OmniSharp/Kulture](https://github.com/OmniSharp/Kulture)

_Note: OmniSharp for Atom doesn't support ASP.NET 5 projects yet_

Using OmniSharp for cross platform development [http://www.omnisharp.net/](http://www.omnisharp.net/)

Installing OmniSharp in Atom [https://github.com/OmniSharp/omnisharp-atom](https://github.com/OmniSharp/omnisharp-atom)

```
apm install language-csharp
apm install autocomplete-plus
apm install omnisharp-atom
```

_Note: The first two packages were already installed in my Atom installation._

In order for mono to be correctly included in your path, open Atom from the command line.

## Using Yeoman to generate an ASP.NET project

See [https://www.npmjs.com/package/generator-aspnet](https://www.npmjs.com/package/generator-aspnet)

* Install: `npm install -g generator-aspnet`
* Run: `yo aspnet`

Available generators:

* aspnet:MvcController
* aspnet:MvcView
* aspnet:WebApiContoller
* aspnet:Class
* aspnet:StartupClass
* aspnet:BowerJson
* aspnet:CoffeeScript
* aspnet:Config
* aspnet:Gulpfile
* aspnet:HTMLPage
* aspnet:JavaScript
* aspnet:JScript
* aspnet:JSON
* aspnet:PackageJson
* aspnet:TextFile
* aspnet:TypeScript
