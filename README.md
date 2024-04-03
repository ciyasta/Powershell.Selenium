# PowerShell.Selenium

PowerShell module for running automating web using Selenium.

## Usage
Import the module from PowerShell Gallery.
```powershell
Import-Module PowerShell.Selenium
```
### Create
Create web driver using `New-WebDriver` and you can set which browser you want to create driver for.
```powershell
$Driver = New-WebDriver -Browser Edge
````
### Remove
Remove the web driver once automation is complete using `Remove-WebDriver`.
```powershell
Remove-WebDriver -Driver $Driver
```
