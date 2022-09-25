using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kogane.Internal
{
    internal sealed class SpriteAtlasPreprocessorSettingsProvider : SettingsProvider
    {
        private const string PATH = "Kogane/Preprocessor/Sprite Atlas";

        private Editor m_editor;

        private SpriteAtlasPreprocessorSettingsProvider
        (
            string              path,
            SettingsScope       scopes,
            IEnumerable<string> keywords = null
        ) : base( path, scopes, keywords )
        {
        }

        public override void OnActivate( string searchContext, VisualElement rootElement )
        {
            var instance = SpriteAtlasPreprocessorSettings.instance;

            instance.hideFlags = HideFlags.HideAndDontSave & ~HideFlags.NotEditable;

            Editor.CreateCachedEditor( instance, null, ref m_editor );
        }

        public override void OnGUI( string searchContext )
        {
            using var changeCheckScope = new EditorGUI.ChangeCheckScope();

            using ( new EditorGUILayout.HorizontalScope() )
            {
                if ( GUILayout.Button( "Create Importer Settings" ) )
                {
                    CreateScriptableObject<SpriteAtlasImporterSettings>();
                }

                if ( GUILayout.Button( "Create Platform Settings" ) )
                {
                    CreateScriptableObject<TextureImporterPlatformSettings>();
                }
            }

            m_editor.OnInspectorGUI();

            if ( !changeCheckScope.changed ) return;

            SpriteAtlasPreprocessorSettings.instance.Save();
        }

        private static void CreateScriptableObject<T>() where T : ScriptableObject
        {
            var fullPath = EditorUtility.SaveFilePanel
            (
                title: "",
                directory: "Assets",
                defaultName: typeof( T ).Name,
                extension: "asset"
            );

            if ( string.IsNullOrWhiteSpace( fullPath ) ) return;

            var relativePath = FileUtil.GetProjectRelativePath( fullPath );
            var instance     = ScriptableObject.CreateInstance<T>();

            AssetDatabase.CreateAsset( instance, relativePath );
            AssetDatabase.Refresh();
        }

        [SettingsProvider]
        private static SettingsProvider CreateSettingProvider()
        {
            return new SpriteAtlasPreprocessorSettingsProvider
            (
                path: PATH,
                scopes: SettingsScope.Project
            );
        }
    }
}