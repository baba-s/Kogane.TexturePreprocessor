using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "ProjectSettings/Kogane/TexturePreprocessorSettings.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class TexturePreprocessorSettings :
        ScriptableSingleton<TexturePreprocessorSettings>,
        IEnumerable<TexturePreprocessorSetting>
    {
        [SerializeField] private TexturePreprocessorSetting[] m_array = Array.Empty<TexturePreprocessorSetting>();

        public void Save()
        {
            Save( true );
        }

        public IEnumerator<TexturePreprocessorSetting> GetEnumerator()
        {
            return ( ( IEnumerable<TexturePreprocessorSetting> )m_array ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}