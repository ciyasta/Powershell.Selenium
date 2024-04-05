# PowerShell.Selenium

Get started with web automation with minimal setup on any operating system. No need to install web drivers, as it automatically taken care by [Selenium Manager](https://www.selenium.dev/documentation/selenium_manager/) now. If you are familiar with PowerShell, you are already halfway there. 

## Prerequisite
You can run PowerShell.Selenium only on PowerShell, duh! PowerShell come out of the box with Microsoft Windows. To learn more about installing PowerShell on different Operating Systems, you can follow [here](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell).

## Installation
Install the module from PowerShell Gallery.
```powershell
Install-Module PowerShell.Selenium
```

## Usage
Once you've installed the module, just run some cmdlets of PowerShell and start seeing the magic.

### New Web Driver
Create web driver using `New-WebDriver` and where you can set which browser you want to create driver for.

```powershell
$Driver = New-WebDriver -Browser Edge
```
### Remove Web Driver
Remove the web driver once automation is complete using `Remove-WebDriver`.

```powershell
Remove-WebDriver -Driver $Driver
```

## Shout-out
This project is inspired by [selenium-powershell](https://github.com/adamdriscoll/selenium-powershell) by [Adam Driscoll](https://github.com/adamdriscoll).