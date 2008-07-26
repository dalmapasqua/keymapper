﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using System.Security.Principal;

namespace KMBlog
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie cookie = Context.Request.Cookies[cookieName];

            if (cookie == null)
                return;

            FormsAuthenticationTicket ticket = null;
            try
            {
                ticket = FormsAuthentication.Decrypt(cookie.Value);
            }
            catch (Exception ex)
            {
                return;
            }


            if (ticket == null)
                return;

            string role = ticket.UserData;

            FormsIdentity id = new FormsIdentity(ticket);

            GenericPrincipal principal = new GenericPrincipal(id, new string[] { role });
            Context.User = principal;


        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}