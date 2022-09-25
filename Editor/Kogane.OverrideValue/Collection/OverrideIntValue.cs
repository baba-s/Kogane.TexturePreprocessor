using System;

namespace Kogane
{
    [Serializable]
    public sealed class OverrideIntValue : OverrideValue<int>
    {
        public OverrideIntValue( string label, int defaultValue ) : base( label, defaultValue )
        {
        }
    }
}