using System;

namespace Kogane
{
    [Serializable]
    public sealed class OverrideBoolValue : OverrideValue<bool>
    {
        public OverrideBoolValue( string label, bool defaultValue ) : base( label, defaultValue )
        {
        }
    }
}