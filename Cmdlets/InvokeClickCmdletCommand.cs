using System;
using System.Management.Automation;
using OpenQA.Selenium;

namespace PowerShell.Selenium
{
    [Cmdlet(VerbsLifecycle.Invoke, "Click")]
    [OutputType(typeof(void))]
    public class InvokeClickCmdletCommand : PSCmdlet
    {
        [Parameter(Position=0, Mandatory=true)]
        public WebElement WebElement { get; set; }

        protected override void ProcessRecord()
        {
            WebElement?.Click();
        }
    }
}
