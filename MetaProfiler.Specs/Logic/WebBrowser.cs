using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WatiN.Core;

namespace MetaProfiler.Specs.Logic
{
    public class WebBrowser
    {
        public static IE Current
        {
            get;
            private set;
        }

        public static void Open()
        {
            Current = new IE();
            Current.AutoClose = true;
        }

        public static void Close()
        {
            Current.Close();
            Current.Dispose();
        }
    }
}
