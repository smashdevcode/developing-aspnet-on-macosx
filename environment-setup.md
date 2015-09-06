
# Environment Setup

## Opening Acts

### 1) Install Xcode

Installing Xcode is necessary as Homebrew requires some of the Xcode command line tools.

### 2) Install Homebrew

See [Homebrew](http://brew.sh)

* Run command `brew help` to check if Homebrew is already installed
* Install Homebrew by running the command `ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"`
* Run commands `brew update` and `brew doctor` immediately after installation completes

### 3) Install Git

`brew install git`

### 4) Install Node.js

`brew install node`

Verify install with `node -v` and `npm -v`

### 5) Install Mono

`brew install mono`

### 6) Install Yeoman

Yeoman is used to scaffold ASP.NET projects.

To confirm if you have Yeoman installed, run the command `yo --version`.

To install Yeoman, run the command `npm install -g yo`.

### 7) Install Yeoman ASP.NET templates

`npm install -g generator-aspnet`

## The Headliners

### 8) Install ASP.NET 5

Before installing ASP.NET 5, make sure that you've got a profile setup (i.e. ~/.bash_profile ~/.zshrc or ~/.profile).

```
curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh
```

To install the latest version, run the command `dnvm upgrade`.

To list the installed versions, run the command `dnvm list`.

### 9) Install VS Code

See https://code.visualstudio.com/
