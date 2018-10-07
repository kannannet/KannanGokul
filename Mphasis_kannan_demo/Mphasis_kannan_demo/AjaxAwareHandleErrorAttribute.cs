using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mphasis_kannan_demo
{
    public class AjaxAwareHandleErrorAttribute : HandleErrorAttribute
    {
        public string PartialViewName { get; set; }

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            // Verify if AJAX request
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var result = new HttpStatusCodeResult(410, "exception occured");
                filterContext.Result = result;
            }
        }
    }
}