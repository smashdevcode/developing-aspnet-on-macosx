
# Developing with ASP.NET on Mac OS X

Here are the steps to setup your environment...

## Opening Acts

### 1) Install Xcode

Installing Xcode is necessary as Homebrew requires some of the Xcode command line tools.

Alternatively, you can just install the command line tools:

```
xcode-select –install
```

### 2) Install Homebrew

See [Homebrew](http://brew.sh)

* Run command `brew help` to check if Homebrew is already installed
* Install Homebrew by running the command `ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"`
* Run commands `brew update` and `brew doctor` immediately after installation completes

### 3) Install Git

```
brew install git
```

Then configure git (see https://help.github.com/articles/set-up-git/)

Optionally install Bash git completion:

```
brew install git bash-completion
```

### 4) Install Node.js

```
brew install node
```

Verify install with `node -v` and `npm -v`

### 5) Install Mono

```
brew install mono
```

### 6) Install Yeoman

Yeoman is used to scaffold ASP.NET projects.

To confirm if you have Yeoman installed, run the command `yo --version`.

To install Yeoman, run the command `npm install -g yo`.

### 7) Install Yeoman ASP.NET templates

```
npm install -g generator-aspnet
```

See https://www.npmjs.com/package/generator-aspnet for documentation

## The Headliners

### 8) Install ASP.NET 5

Before installing ASP.NET 5, make sure that you've got a profile setup (i.e. ~/.bash_profile ~/.zshrc or ~/.profile).

```
curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh
```

Or using Homebrew...

```
brew tap aspnet/dnx
brew update
brew install dnvm
```

To install the latest version, run the command `dnvm upgrade`.

To list the installed versions, run the command `dnvm list`.

To install the Core CLR version of the runtime, run the command `dnvm install 1.0.0-beta7 -r coreclr`.

To switch to the Core CLR version of the runtime, run the command `dnvm use 1.0.0-beta7 -r coreclr`.

To change your default version of the runtime, run the command `dnvm use 1.0.0-beta7 -r coreclr -p`.

## Optional Items

### 1) Install VS Code

See https://code.visualstudio.com/

### 2) Atom

See http://atom.io/

### 3) SQLite Database Browser

See http://sqlitebrowser.org/
