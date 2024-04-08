using System;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace PowerShell.Selenium.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "WebDriver")]
    [OutputType(typeof(WebDriver))]
    public class NewWebDriverCmdletCommand : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0
        )]
        [ValidateSet("Chrome", "Edge", "Firefox", "Safari")]
        public string Browser { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1
        )]
        public Uri Uri { get; set; }
        protected override void BeginProcessing()
        {
            var seleniumManagerPath = GetSeleniumManagerPath();
            WriteVerbose($"Selenium Manager path: {seleniumManagerPath}");
            Environment.SetEnvironmentVariable("SE_MANAGER_PATH", seleniumManagerPath);
        }
        protected override void ProcessRecord()
        {
            WebDriver WebDriver = null;
            switch (Browser)
            {
                case "Chrome":
                    WebDriver = new ChromeDriver();
                    break;
                case "Edge":
                    WebDriver = new EdgeDriver();
                    break;
                case "Firefox":
                    WebDriver = new FirefoxDriver();
                    break;
                case "Safari":
                    WebDriver = new SafariDriver();
                    break;
            }
            WebDriver?.Navigate().GoToUrl(Uri);
            WriteObject(WebDriver);
        }
        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        private string GetSeleniumManagerPath()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Path.Combine(currentDirectory, "selenium-manager", "windows", "selenium-manager.exe");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Path.Combine(currentDirectory, "selenium-manager", "linux", "selenium-manager");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return Path.Combine(currentDirectory, "selenium-manager", "macos", "selenium-manager");
            }
            else
            {
                throw new PlatformNotSupportedException(
                    $"Selenium Manager doesn't support your runtime platform: {RuntimeInformation.OSDescription}");
            }
        }
    }
}
