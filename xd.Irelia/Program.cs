using System;
using System.Reflection;
using System.Security.Permissions;
using EnsoulSharp.SDK;
using xd.Irelia.Properties;

namespace xd.Irelia
{
    class Irelia
    {
        static void Main(string[] args)
        {
            GameEvent.OnGameLoad += OnGameLoad;
        }
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        private static void OnGameLoad()
        {
            try
            {
                var a = Assembly.Load(Resources.Irelia);
                var myType = a.GetType("xd.Irelia");
                var methon = myType.GetMethod("Main", BindingFlags.Public | BindingFlags.Static);

                if (methon != null)
                {
                    methon.Invoke(null, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
