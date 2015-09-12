
# Developing ASP.NET on Mac OS X

* Quick ASP.NET 5 Overview
* Installing ASP.NET
* Using OmniSharp for Development
* Using Yeoman to generate an ASP.NET project

## Quick ASP.NET 5 Overview

See [http://gunnarpeipman.com/2014/10/asp-net-5-what-are-kre-kvm-kpm/](http://gunnarpeipman.com/2014/10/asp-net-5-what-are-kre-kvm-kpm/)

ASP.NET 5 comes with new runtime environment called KRE. There are also tools for managing KRE versions and NuGet packages that your application uses.

K has three components:

* KRE – K Runtime Environment is the code required to bootstrap and run an ASP.NET 5 application. This includes things like the compilation system, SDK tools, and the native CLR hosts.
* KVM – K Version Manager is for updating and installing different versions of KRE. KVM is also used to set the default KRE version.
* KPM – K Package Manager manages packages needed by applications to run. Packages in this context are NuGet packages.

## Installing ASP.NET

Information about ASP.NET 5 can be found at  [https://github.com/aspnet/Home](https://github.com/aspnet/Home)

### Install GitHub for Mac

See [GitHub](https://github.com)

### Install Homebrew

See [Homebrew](http://brew.sh)

* Run command `brew help` to check if Homebrew is already installed
* Install Homebrew by running the command `ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"`
* Run commands `brew update` and `brew doctor` immediately after installation completes

### Install Node.js

Confirm if you have Node.js installed by running the command `node -v`.

If you don't have Node.js installed, see [Node.js](https://nodejs.org) to download the installer.

### Install Grunt

Grunt is used when building the sample ASP.NET projects, so let's go ahead and get that now.

To confirm if you have Grunt installed, run the command `grunt -h`.

If you don't have Grunt installed, do the following:

1. Make sure that your npm is up-to-date by running `sudo npm install npm -g`
1. Then install the Grunt CLI by running the command `sudo npm install -g grunt-cli`

### Install Yeoman

Yeoman is used to scaffold ASP.NET projects.

To confirm if you have Yeoman installed, run the command `yo --version`.

To install Yeoman, run the command `sudo npm install -g yo`.

### Install the K Version Manager (KVM)

To install KVM and the correct version of Mono using [Homebrew](http://brew.sh) use the following steps:

 * Run command `brew tap aspnet/k` to tap the ASP.NET 5 related git repositories. If you had already tapped the repo for previous releases, run `brew untap aspnet/k` to delete the old commands and tap again to get the updated brew scripts.
 * Run command `brew install kvm` to install KVM. This also automatically install the latest KRE package from https://www.nuget.org/api/v2 feed.
 * Run command `source kvm.sh` on your terminal if your terminal cannot understand kvm.

### Install the K Runtime Environment (KRE)

Now that you have KVM setup you can install the latest version of the runtime by running the following command: ```kvm upgrade```

This command will download the specified version of the K Runtime Environment (KRE), and put it on your user profile ready to use. You are now ready to start using ASP.NET 5!

### Running the samples

1. Clone the Home repository at [https://github.com/aspnet/Home](https://github.com/aspnet/Home)
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

## Increasing the Maximum Open Files Limit

1. See [http://docs.basho.com/riak/latest/ops/tuning/open-files-limit/](http://docs.basho.com/riak/latest/ops/tuning/open-files-limit/)
1. Check permissions on the files
 1. To change ownership to root run the command `sudo chown root <filename>`
 1. To change permissions run the command `sudo chmod 644 <filename>`
1. Restart
1. To confirm the user file limits were changed by running command `ulimit -a`

## TODO

1. Show some of the KVM commands and why you would use them
1. Show how to run the ASP.NET samples
1. Show where packages are kept
1. Try the various ASP.NET Yeoman templates (i.e. controllers, views, etc.)
