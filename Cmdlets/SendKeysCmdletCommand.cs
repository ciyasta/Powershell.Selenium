using System;
using System.Management.Automation;
using OpenQA.Selenium;

namespace PowerShell.Selenium
{
    [Cmdlet(VerbsCommunications.Send, "Keys")]
    public class SendKeysCmdletCommand : PSCmdlet
    {
        [Parameter(Position=0, Mandatory = true)]
        public WebElement WebElement { get; set; }

        [Parameter(Position=1, Mandatory= true)]
        public string Keys { get; set; }

        protected override void ProcessRecord()
        {
            WebElement?.SendKeys(Keys);
        }
    }
}
