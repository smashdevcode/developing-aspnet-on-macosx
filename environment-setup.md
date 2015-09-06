
# Environment Setup

## Opening Acts

### 1) Install Homebrew

See [Homebrew](http://brew.sh)

* Run command `brew help` to check if Homebrew is already installed
* Install Homebrew by running the command `ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"`
* Run commands `brew update` and `brew doctor` immediately after installation completes

### 2) Install Git

`brew install git`

### 3) Install Node.js

`brew install node`

Verify install with `node -v` and `npm -v`

### 4) Install Mono

`brew install mono`

### 5) Install Yeoman

Yeoman is used to scaffold ASP.NET projects.

To confirm if you have Yeoman installed, run the command `yo --version`.

To install Yeoman, run the command `npm install -g yo`.

### 6) Install Yeoman ASP.NET templates

`npm install -g generator-aspnet`

## The Headliners

### 7) Install ASP.NET 5

```
curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh
dnvm upgrade
dnvm list
```
### 8) Install VS Code

See https://code.visualstudio.com/
