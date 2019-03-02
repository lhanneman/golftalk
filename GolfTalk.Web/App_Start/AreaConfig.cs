using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace GolfTalk.Web
{
    public sealed class AreaConfig
    {
        public static void RegisterAreas()
        {
        }

        private static void RegisterArea<T>()
            where T : AreaRegistration, new()
        {
            var registration = Activator.CreateInstance<T>();
            var context = new AreaRegistrationContext(registration.AreaName, RouteTable.Routes);
            var ns = registration.GetType().Namespace;

            if (ns != null)
            {
                context.Namespaces.Add(string.Format("{0}.*", ns));
            }

            registration.RegisterArea(context);
        }
    }
}