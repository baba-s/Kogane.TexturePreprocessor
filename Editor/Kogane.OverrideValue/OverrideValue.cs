using System;
using UnityEngine;

namespace Kogane
{
    public abstract class OverrideValueBase
    {
    }

    [Serializable]
    public abstract class OverrideValue<T> : OverrideValueBase
    {
        [SerializeField] private string m_label;
        [SerializeField] private bool   m_isOverride;
        [SerializeField] private T      m_value;

        public string Label      => m_label;
        public bool   IsOverride => m_isOverride;
        public T      Value      => m_value;

        protected OverrideValue( string label, T defaultValue )
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

    [Serializable]
    public sealed class OverrideIntValue : OverrideValue<int>
    {
        public OverrideIntValue( string label, int defaultValue ) : base( label, defaultValue )
        {
        }
    }


    [Serializable]
    public sealed class OverrideBoolValue : OverrideValue<bool>
    {
        public OverrideBoolValue( string label, bool defaultValue ) : base( label, defaultValue )
        {
        }
    }

    [Serializable]
    public sealed class OverrideUintValue : OverrideValue<uint>
    {
        public OverrideUintValue( string label, uint defaultValue ) : base( label, defaultValue )
        {
        }
    }

    [Serializable]
    public sealed class OverrideFloatValue : OverrideValue<float>
    {
        public OverrideFloatValue( string label, float defaultValue ) : base( label, defaultValue )
        {
        }
    }

    [Serializable]
    public sealed class OverrideVector2 : OverrideValue<Vector2>
    {
        public OverrideVector2( string label, Vector2 defaultValue ) : base( label, defaultValue )
        {
        }
    }
}