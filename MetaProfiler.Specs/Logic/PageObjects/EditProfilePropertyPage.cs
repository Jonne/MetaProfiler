using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;
using WatiN.Core.Constraints;

namespace MetaProfiler.Specs.Logic.PageObjects
{
    public class EditProfilePropertyPage
    {
        private Browser browser;

        public EditProfilePropertyPage(Browser browser)
        {
            this.browser = browser;
        }

        public string Name
        {
            get
            {
                return browser.TextField("Name").Text;
            }
            set
            {
                browser.TextField("Name").TypeText(value);
            }
        }

        public string Type 
        {
            get
            {
                return browser.TextField("Type").Text;
            }
            set
            {
                browser.TextField("Type").TypeText(value);
            }
        }

        public void Save()
        {
            Button button = browser.Button("Save");
            button.Click();
        }

        public void Visit()
        {
            browser.GoTo("http://localhost:5756/Manage/ProfileProperty/Add");
        }
    }
}
