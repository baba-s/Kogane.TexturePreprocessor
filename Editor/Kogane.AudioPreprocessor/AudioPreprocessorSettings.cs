using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "ProjectSettings/Kogane/AudioPreprocessorSettings.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class AudioPreprocessorSettings :
        ScriptableSingleton<AudioPreprocessorSettings>,
        IEnumerable<AudioPreprocessorSetting>
    {
        [SerializeField] private AudioPreprocessorSetting[] m_array = Array.Empty<AudioPreprocessorSetting>();

        public void Save()
        {
            Save( true );
        }

        public IEnumerator<AudioPreprocessorSetting> GetEnumerator()
        {
            return ( ( IEnumerable<AudioPreprocessorSetting> )m_array ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}