using System;
using System.IO;
using System.Management.Automation;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Edge;

namespace PowerShell.Selenium.Cmdlets
{
    [Cmdlet(VerbsCommon.New,"WebDriver")]
    [OutputType(typeof(IWebDriver))]
    public class NewWebDriverCmdletCommand : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0)]
        [ValidateSet("Chrome", "Edge")]
        public string Browser { get; set; }
        protected override void BeginProcessing()
        {
            Environment.SetEnvironmentVariable("SE_MANAGER_PATH", GetSeleniumManagerPath());
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
