using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;

namespace MetaProfiler.Specs.Logic.PageObjects
{
    public class ProfilePropertiesPage
    {
        private Browser browser;
        private const int NameColumn = 0;
        private const int TypeColumn = 1;

        public ProfilePropertiesPage(Browser browser)
        {
            this.browser = browser;
        }

        public bool IsCurrent
        {
            get
            {
                return string.Compare(browser.Url, "http://localhost:5756/Manage/ProfileProperty", true) == 0;
            }
        }

        public int NumberOfProperties
        {
            get { return 1; }
        }

        public string NameFor(int rowsIndex)
        {
            var table = browser.Table("Properties");
            return table.TableRows[rowsIndex--].TableCells[NameColumn].Text;
        }

        public string TypeFor(int rowsIndex)
        {
            var table = browser.Table("Properties");
            return table.TableRows[rowsIndex--].TableCells[TypeColumn].Text;
        }
    }
}
