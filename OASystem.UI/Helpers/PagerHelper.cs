using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OASystem.UI.Helpers
{
    public static class PagerHelper
    {
        public static int CountToPage(int Count, int PageSize)
        {
            if (Count % PageSize == 0)
            {
                return Count / PageSize;
            }
            else
            {
                return Count / PageSize + 1;
            }
        }
    }
}