using System.Management.Automation;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PowerShell.Selenium
{
    [Cmdlet(VerbsCommon.New, "ChromeDriver")]
    [OutputType(typeof(ChromeDriver))]
    class NewChromeDriver : PSCmdlet
    {
        private IWebDriver WebDriver { get; set; }

        protected override void BeginProcessing()
        {
            WriteVerbose("Starting Chrome!!!");
        }

        protected override void ProcessRecord()
        {
            WebDriver = new ChromeDriver();
            WriteObject(WebDriver);
        }

        protected override void EndProcessing()
        {
            WriteVerbose($"Chrome started titled: {WebDriver.Title}  !!");
        }
    }
}