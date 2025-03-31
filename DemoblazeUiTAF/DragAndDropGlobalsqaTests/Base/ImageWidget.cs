using OpenQA.Selenium;

namespace DemoblazeUiTAF.DragAndDropGlobalsqaTests.Base
{
    internal class ImageWidget
    {
       private IWebElement imageWidget;
       
        public IWebElement Title => imageWidget.FindElement(By.XPath(".//h5[@class ='ui-widget-header']"));
        public IWebElement Image => imageWidget.FindElement(By.TagName("img"));
        public IWebElement TrashIcon => imageWidget.FindElement(By.LinkText("Delete image"));
        public IWebElement ZoomIcon => imageWidget.FindElement(By.LinkText("View larger"));

        public ImageWidget(IWebElement imageWidget)
        {
            this.imageWidget = imageWidget;
        }
    }
}
