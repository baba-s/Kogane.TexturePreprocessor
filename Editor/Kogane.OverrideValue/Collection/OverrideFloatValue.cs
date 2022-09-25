using System;

namespace Kogane
{
    [Serializable]
    public sealed class OverrideFloatValue : OverrideValue<float>
    {
        public OverrideFloatValue( string label, float defaultValue ) : base( label, defaultValue )
        {
        }
    }
}