using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "ProjectSettings/Kogane/AudioPreprocessorSettings.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class AudioPreprocessorSettings : ScriptableSingleton<AudioPreprocessorSettings>
    {
        [SerializeField] private AudioPreprocessorSetting[] m_array = Array.Empty<AudioPreprocessorSetting>();

        public IReadOnlyList<AudioPreprocessorSetting> List => m_array;

        public void Save()
        {
            Save( true );
        }
    }
}