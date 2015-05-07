using System;
using System.Collections.Generic; 
using System.Reflection;
using System.Text; 

namespace Generic.Util
{
    /// <summary>
    /// Singleton utility class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : Singleton<T>, new()
    {
        /// <summary>
        /// Static instance that holds the singleton instance.
        /// </summary>
        private static T _instance;

        protected Singleton()
        {
        }

        protected virtual void Destroy()
        { }

        public static void InitSingleton()
        {
            try
            {

                _instance = new T();

            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

        }

        public static void DestroySingleton()
        {
            if (_instance != null)
            {
                _instance.Destroy();
                _instance = null;
            }

        }

        /// <summary>
        /// Returns the instance of singleton.
        /// </summary>
        public static T I
        {
            get { return _instance; }
        }
    }
}
