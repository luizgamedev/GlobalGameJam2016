using System.Collections;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace BitStrap
{
	/// <summary>
	/// Simple singleton class that implements the singleton code design pattern.
	/// Use it by inheriting from this class, using T as the class itself.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance = null;

        /// <summary>
        /// The class's single instance.
        /// </summary>
        public static T Instance
        {
            get { return GetInstance( true ); }
        }

        /// <summary>
        /// Executes the callback passing the instance if there is one.
        /// </summary>
        /// <param name="callback"></param>
        public static void RequireInstance( System.Action<T> callback )
        {
            T inst = GetInstance( false );
            if( inst != null && callback != null )
            {
                callback( inst );
            }
        }

        /// <summary>
        /// Returns the class's single instance.
        /// </summary>
        /// <param name="warnIfNotFound"></param>
        /// <returns></returns>
        public static T GetInstance( bool warnIfNotFound )
        {
            if( _instance == null )
            {
                _instance = Object.FindObjectOfType<T>();

                if( _instance == null && warnIfNotFound )
                {
                    OnInstanceNotFound();
                }
            }

            return _instance;
        }

        protected void ForceSingletonInstance()
        {
            _instance = this as T;
        }

        protected virtual void OnDestroy()
        {
			_instance = null;
        }

        private static void OnInstanceNotFound()
        {
            Debug.LogWarningFormat( "Didn't find a object of type {0}!", typeof( T ).Name );
        }
    }
}
