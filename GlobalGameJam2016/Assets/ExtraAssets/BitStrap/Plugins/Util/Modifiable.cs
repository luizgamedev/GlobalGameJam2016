using System.Collections.Generic;
using UnityEngine;

namespace BitStrap
{
    /// <summary>
    /// Wraps a type that can be modified given an aggregate function.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public class Modifiable<T>
    {
        [SerializeField]
        private T originalValue;

        private Dictionary<object, T> modifiers = new Dictionary<object, T>();
        private System.Func<T, T, T> aggregateFunction;
        private T modifiedValue;

        /// <summary>
        /// Original value.
        /// Use this to write new values to be modified.
        /// </summary>
        public T OriginalValue
        { get { return originalValue; } set { originalValue = value; ApplyModifiers(); } }

        /// <summary>
        /// The cached modified value. Calculated by passing the original value
        /// through all the aggregate functions.
        /// </summary>
        public T ModifiedValue
        { get { return modifiedValue; } }

        public Modifiable( T value, System.Func<T, T, T> aggregateFunction )
        {
            this.originalValue = value;
            this.aggregateFunction = aggregateFunction;
            this.modifiedValue = value;
        }

        public static implicit operator T( Modifiable<T> modifiable )
        {
            return modifiable.modifiedValue;
        }

        /// <summary>
        /// Adds a new modifier within a context key.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="modifier"></param>
        public void AddModifier( object context, T modifier )
        {
            modifiers.Add( context, modifier );
            ApplyModifiers();
        }

        /// <summary>
        /// Removes a modifier given its context key.
        /// </summary>
        /// <param name="context"></param>
        public void RemoveModifier( object context )
        {
            modifiers.Remove( context );
            ApplyModifiers();
        }

        /// <summary>
        /// Remove all modifiers.
        /// </summary>
        public void ClearModifiers()
        {
            modifiers.Clear();
            modifiedValue = originalValue;
        }

        public override string ToString()
        {
            return modifiedValue.ToString();
        }

        private void ApplyModifiers()
        {
            modifiedValue = originalValue;
            T lastValue = originalValue;
            foreach( var pair in modifiers.Each() )
            {
                T value = pair.Value;
                modifiedValue = aggregateFunction( lastValue, value );
                lastValue = value;
            }
        }
    }
}
