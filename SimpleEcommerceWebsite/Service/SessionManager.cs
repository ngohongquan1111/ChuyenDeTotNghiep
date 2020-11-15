using System.Web;
using static SimpleEcommerceWebsite.Service.Resource.Enum.SessionObjectEnum;

namespace SimpleEcommerceWebsite.Service
{
    public static class SessionManager
    {
        public static void Dispose()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }

        public static void SetSessionObject(SessionEnum key, object value)
        {
            if (HttpContext.Current.Session[key.ToString()] != null)
            {
                Remove(key);
            }

            HttpContext.Current.Session.Add(key.ToString(), value);
        }

        public static object GetSessionObject(SessionEnum key)
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null || HttpContext.Current.Session[key.ToString()] == null)
            {
                return null;
            }
            return HttpContext.Current.Session[key.ToString()];
        }

        public static void Remove(SessionEnum key)
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session[key.ToString()] == null)
            {
                return;
            }

            HttpContext.Current.Session.Remove(key.ToString());
        }
    }
}