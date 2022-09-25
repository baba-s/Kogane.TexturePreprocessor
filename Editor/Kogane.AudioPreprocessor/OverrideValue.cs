using System;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [Serializable]
    internal sealed class OverrideAudioClipLoadType : OverrideValue<AudioClipLoadType>
    {
        public OverrideAudioClipLoadType( string label, AudioClipLoadType defaultValue ) : base( label, defaultValue )
        {
        }
    }

    [Serializable]
    internal sealed class OverrideAudioSampleRateSetting : OverrideValue<AudioSampleRateSetting>
    {
        public OverrideAudioSampleRateSetting( string label, AudioSampleRateSetting defaultValue ) : base( label, defaultValue )
        {
        }
    }

    [Serializable]
    internal sealed class OverrideAudioCompressionFormat : OverrideValue<AudioCompressionFormat>
    {
        public OverrideAudioCompressionFormat( string label, AudioCompressionFormat defaultValue ) : base( label, defaultValue )
        {
        }
    }
}