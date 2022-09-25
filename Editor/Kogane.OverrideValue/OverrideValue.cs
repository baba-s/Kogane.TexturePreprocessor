using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Kogane
{
    [Serializable]
    public sealed class OverrideValue<T> : OverrideValueBase
    {
        [SerializeField][UsedImplicitly] private string m_label;
        [SerializeField]                 private bool   m_isOverride;
        [SerializeField]                 private T      m_value;

        public bool IsOverride => m_isOverride;
        public T    Value      => m_value;

        public OverrideValue( string label, T defaultValue )
        {
            m_label = label;
            m_value = defaultValue;
        }

        public void Override( Action<T> setter )
        {
            if ( m_isOverride )
            {
                setter( m_value );
            }
        }

        public static implicit operator T( OverrideValue<T> value ) => value.Value;
    }
}