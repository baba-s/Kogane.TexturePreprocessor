using System;
using UnityEngine;

namespace Kogane
{
    [Serializable]
    public sealed class OverrideVector2 : OverrideValue<Vector2>
    {
        public OverrideVector2( string label, Vector2 defaultValue ) : base( label, defaultValue )
        {
        }
    }
}