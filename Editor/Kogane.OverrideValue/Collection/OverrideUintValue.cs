using System;

namespace Kogane
{
    [Serializable]
    public sealed class OverrideUintValue : OverrideValue<uint>
    {
        public OverrideUintValue( string label, uint defaultValue ) : base( label, defaultValue )
        {
        }
    }
}