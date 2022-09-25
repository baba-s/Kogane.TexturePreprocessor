using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "ProjectSettings/Kogane/SpriteAtlasPreprocessorSettings.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class SpriteAtlasPreprocessorSettings :
        ScriptableSingleton<SpriteAtlasPreprocessorSettings>,
        IEnumerable<SpriteAtlasPreprocessorSetting>
    {
        [SerializeField] private SpriteAtlasPreprocessorSetting[] m_array = Array.Empty<SpriteAtlasPreprocessorSetting>();

        public void Save()
        {
            Save( true );
        }

        public IEnumerator<SpriteAtlasPreprocessorSetting> GetEnumerator()
        {
            return ( ( IEnumerable<SpriteAtlasPreprocessorSetting> )m_array ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}