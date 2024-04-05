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
    [Cmdlet(VerbsCommon.New,"WebDriver")]
    [OutputType(typeof(IWebDriver))]
    public class NewWebDriverCmdletCommand : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0)]
        [ValidateSet("Chrome", "Edge", "Firefox", "Safari")]
        public string Browser { get; set; }
        protected override void BeginProcessing()
        {
            var seleniumManagerPath = GetSeleniumManagerPath();
            WriteVerbose($"Selenium Manager path: {seleniumManagerPath}");
            Environment.SetEnvironmentVariable("SE_MANAGER_PATH", seleniumManagerPath);
        }
        protected override void ProcessRecord()
        {
            switch(Browser)
            {
                case "Chrome": 
                    WriteObject(new ChromeDriver());
                    break;
                case "Edge":
                    WriteObject(new EdgeDriver());
                    break;
                case "Firefox":
                    WriteObject(new FirefoxDriver());
                    break;
                case "Safari":
                    WriteObject(new SafariDriver());
                    break;
            }
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
                    WriteVerbose("OS Platform: Windows");
                    return Path.Combine(currentDirectory, "selenium-manager", "windows", "selenium-manager.exe");
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    WriteVerbose("OS Platform: Linux");
                    return Path.Combine(currentDirectory, "selenium-manager", "linux", "selenium-manager");
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    WriteVerbose("OS Platform: OSX");
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
