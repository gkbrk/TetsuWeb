using Tetsu.Web.Http;

namespace Tetsu.Web.Router
{
    public interface IRouteMatcher
    {
        /// <summary>
        /// Returns if a request matches the route
        /// </summary>
        bool IsMatch(Request request);
    }
}
