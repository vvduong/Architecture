using Common.AppSetting;
using System.Web;
using System.Web.Mvc;

namespace Architecture.Application.Extensions
{

    public static class UrlHelperExtensions
    {
        public static string ContentTheme(this UrlHelper url, string path)
        {
            var virtualPathTheme = AppSettings.ThemeDefault;
            if (path.StartsWith("~/"))
                path = path.Remove(0, 2);

            if (path.StartsWith("/"))
                path = path.Remove(0, 1);
            path = path.Replace("../", string.Empty);
            var pathResult = VirtualPathUtility.ToAbsolute("~/" + virtualPathTheme + "/" + path);
            if (System.Web.Hosting.HostingEnvironment.VirtualPathProvider.FileExists(pathResult))
            {
                return pathResult;
            }
            return VirtualPathUtility.ToAbsolute("~/" + path); ;
        }
        public static string ContentAreaTheme(this UrlHelper url, string path)
        {
            var area = url.RequestContext.RouteData.DataTokens["area"];
            var virtualPathTheme = AppSettings.ThemeDefault;
            if (area != null)
            {
                if (!string.IsNullOrEmpty(area.ToString()))
                    area = "Areas/" + area;

                // Simple checks for '~/' and '/' at the
                // beginning of the path.
                if (path.StartsWith("~/"))
                    path = path.Remove(0, 2);

                if (path.StartsWith("/"))
                    path = path.Remove(0, 1);

                path = path.Replace("../", string.Empty);
                var pathResult = VirtualPathUtility.ToAbsolute("~/" + area + "/" + path);
                var pathResult2 = VirtualPathUtility.ToAbsolute("~/" + path);
                var pathResultTheme = VirtualPathUtility.ToAbsolute("~/" + area + "/" + virtualPathTheme + "/" + path);
                if (System.Web.Hosting.HostingEnvironment.VirtualPathProvider.FileExists(pathResultTheme))
                {
                    return pathResultTheme;
                }
                if (System.Web.Hosting.HostingEnvironment.VirtualPathProvider.FileExists(pathResult))
                {
                    return pathResult;
                }
                if (System.Web.Hosting.HostingEnvironment.VirtualPathProvider.FileExists(pathResult2))
                {
                    return pathResult2;
                }

                return VirtualPathUtility.ToAbsolute("~/" + area + "/" + path);
            }

            return string.Empty;
        }
    }
}
