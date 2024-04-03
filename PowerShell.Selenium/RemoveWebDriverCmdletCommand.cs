using System.Management.Automation;
using OpenQA.Selenium;

namespace PowerShell.Selenium
{
    [Cmdlet(VerbsCommon.Remove, "WebDriver")]
    [OutputType(typeof(void))]
    public class RemoveWebDriverCmdletCommand : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0)]
        public IWebDriver Driver { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            Driver?.Quit();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}