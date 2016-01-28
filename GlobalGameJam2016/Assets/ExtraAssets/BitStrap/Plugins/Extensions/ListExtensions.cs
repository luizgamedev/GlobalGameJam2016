using System.Collections.Generic;

namespace BitStrap
{
    /// <summary>
    /// Bunch of utility extension methods to the generic List class.
    /// These methods are intended to be System.Ling substitues as they do not generate garbage.
    /// </summary>
    public static class ListExtensions
    {
        public struct GCFreeEnumerator<T>
        {
            private List<T>.Enumerator enumerator;

            public T Current
            {
                get { return enumerator.Current; }
            }

            public GCFreeEnumerator( List<T> collection )
            {
                enumerator = collection.GetEnumerator();
            }

            public GCFreeEnumerator<T> GetEnumerator()
            {
                return this;
            }

            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }
        }

        /// <summary>
        /// Use this method to iterate a List in a foreach loop but with no garbage
        /// </summary>
        /// <example>
        /// foreach( var element in myList.Each() )
        /// {
        ///     // code goes here...
        /// }
        /// </example>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static GCFreeEnumerator<T> Each<T>( this List<T> collection )
        {
            return new GCFreeEnumerator<T>( collection );
        }

        /// <summary>
        /// Behaves like System.Linq.FirstOrDefault however it does not generate garbage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static T FirstOrDefault<T>( this List<T> collection )
        {
            if( collection.Count > 0 )
            {
                return collection[0];
            }

            return default( T );
        }

        /// <summary>
        /// Behaves like System.Linq.FirstOrDefault however it does not generate garbage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T FirstOrDefault<T>( this List<T> collection, System.Predicate<T> predicate )
        {
            for( var enumerator = collection.GetEnumerator(); enumerator.MoveNext(); )
            {
                if( predicate( enumerator.Current ) )
                {
                    return enumerator.Current;
                }
            }

            return default( T );
        }
    }
}
