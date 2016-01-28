using System.Collections.Generic;

namespace BitStrap
{
    /// <summary>
    /// Bunch of utility extension methods to the generic Dictionary class.
    /// These methods are intended to be System.Ling substitues as they do not generate garbage.
    /// </summary>
    public static class DictionaryExtensions
    {
        public struct GCFreeEnumerator<K, V>
        {
            private Dictionary<K, V>.Enumerator enumerator;

            public KeyValuePair<K, V> Current
            {
                get { return enumerator.Current; }
            }

            public GCFreeEnumerator( Dictionary<K, V> collection )
            {
                enumerator = collection.GetEnumerator();
            }

            public GCFreeEnumerator<K, V> GetEnumerator()
            {
                return this;
            }

            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }
        }

        /// <summary>
        /// Use this method to iterate a Dictionary in a foreach loop but with no garbage
        /// </summary>
        /// <example>
        /// foreach( var pair in myDictionary.Each() )
        /// {
        ///     // code goes here...
        /// }
        /// </example>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static GCFreeEnumerator<K, V> Each<K, V>( this Dictionary<K, V> collection )
        {
            return new GCFreeEnumerator<K, V>( collection );
        }

        /// <summary>
        /// Behaves like System.Linq.FirstOrDefault however it does not generate garbage.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static KeyValuePair<K, V> FirstOrDefault<K, V>( this Dictionary<K, V> collection )
        {
            var enumerator = collection.GetEnumerator();
            if( enumerator.MoveNext() )
            {
                return enumerator.Current;
            }

            return default( KeyValuePair<K, V> );
        }

        /// <summary>
        /// Behaves like System.Linq.FirstOrDefault however it does not generate garbage.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static KeyValuePair<K, V> FirstOrDefault<K, V>( this Dictionary<K, V> collection, System.Predicate<KeyValuePair<K, V>> predicate )
        {
            for( var enumerator = collection.GetEnumerator(); enumerator.MoveNext(); )
            {
                if( predicate( enumerator.Current ) )
                {
                    return enumerator.Current;
                }
            }

            return default( KeyValuePair<K, V> );
        }
    }
}
