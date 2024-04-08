using System.Management.Automation;
using OpenQA.Selenium;

namespace PowerShell.Selenium.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "WebElement")]
    [OutputType(typeof(IWebElement))]
    public class GetWebElementCmdletCommand : PSCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0
        )]
        public WebDriver WebDriver { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1
        )]
        [Alias("By")]
        [ValidateSet("Id", "LinkText", "Name", "XPath", "ClassName", "PartialLinkText", "TagName", "CssSelector")]
        public string Mechanism { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1
        )]
        public string Query { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            By by = null;
            switch(Mechanism)
            {
                case "Id":
                    by = By.Id(Query);
                    break;
                case "LinkText":
                    by = By.LinkText(Query);
                    break;
                case "Name":
                    by = By.Name(Query);
                    break;
                case "XPath":
                    by = By.XPath(Query);
                    break;
                case "ClassName":
                    by = By.ClassName(Query);
                    break;
                case "PartialLinkText":
                    by = By.PartialLinkText(Query);
                    break;
                case "TagName":
                    by = By.TagName(Query);
                    break;
                case "CssSelector":
                    by = By.CssSelector(Query);
                    break;
            }
            
            WriteObject(WebDriver.FindElement(by));
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}