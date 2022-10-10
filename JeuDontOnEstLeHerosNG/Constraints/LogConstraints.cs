namespace JeuDontOnEstLeHerosNG.Web.Constraints
{
    public class LogConstraints : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return values["id"]?.ToString() == "1";
        }
    }
}
