namespace OU.EV.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public static class SelectListItemExtensions
    {
        public static IEnumerable<SelectListItem> InsertPleaseSelectItem(this IEnumerable<SelectListItem> items)
        {
            var list = items.ToList();

            list.Insert(0, new SelectListItem { Text = "---Please Select---", Value = "" });

            return list;
        }
    }
}