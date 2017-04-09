﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using WHA.CustomActionR;

namespace WHA.App_Start
{
    public class JsonpFilterAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuted(
                ActionExecutedContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");

            //
            // see if this request included a "callback" querystring
            // parameter
            //
            string callback = filterContext.HttpContext.
                      Request.QueryString["callback"];
            if (callback != null && callback.Length > 0)
            {
                //
                // ensure that the result is a "JsonResult"
                //
                JsonResult result = filterContext.Result as JsonResult;
                if (result == null)
                {
                    throw new InvalidOperationException(
                        "JsonpFilterAttribute must be applied only " +
                        "on controllers and actions that return a " +
                        "JsonResult object.");
                }

                filterContext.Result = new JsonpResult
                {
                    ContentEncoding = result.ContentEncoding,
                    ContentType = result.ContentType,
                    Data = result.Data,
                    Callback = callback
                };
            }
        }
    }
}