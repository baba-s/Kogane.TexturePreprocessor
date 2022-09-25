using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// オーディオの Import Settings を管理するクラス
    /// </summary>
    [CreateAssetMenu( fileName = "AudioImporterSettings", menuName = "UniTexturePreprocessor/AudioImporterSettings", order = 10050 )]
    internal sealed class AudioImporterSettings : ScriptableObject
    {
        //================================================================================
        // 定数
        //================================================================================
        private const float SPACE_HEIGHT = 16;

        //================================================================================
        // 変数(SerializeField)
        //================================================================================
        [SerializeField] private OverrideBoolValue m_forceToMono      = new( "Force To Mono", false );
        [SerializeField] private OverrideBoolValue m_loadInBackground = new( "Load In Background", false );
        [SerializeField] private OverrideBoolValue m_ambisonic        = new( "Ambisonic", false );

        // [Space( SPACE_HEIGHT )]
        // [SerializeField] private TextureImporterPlatformSettings m_defaultSettings;
        //
        // [SerializeField] private TextureImporterPlatformSettings m_standaloneSettings;
        // [SerializeField] private TextureImporterPlatformSettings m_iPhoneSettings;
        // [SerializeField] private TextureImporterPlatformSettings m_androidSettings;
        // [SerializeField] private TextureImporterPlatformSettings m_webGLSettings;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// 指定された Importer に設定を適用します
        /// </summary>
        public void Apply( AudioImporter importer )
        {
            if ( m_forceToMono.IsOverride )
            {
                importer.forceToMono = m_forceToMono.Value;
            }

            if ( m_loadInBackground.IsOverride )
            {
                importer.loadInBackground = m_loadInBackground.Value;
            }

            if ( m_ambisonic.IsOverride )
            {
                importer.ambisonic = m_ambisonic.Value;
            }
            //
            // if ( m_defaultSettings != null )
            // {
            //     var platformSettings = importer.GetPlatformTextureSettings( "DefaultTexturePlatform" );
            //     m_defaultSettings.Apply( platformSettings );
            //     importer.SetPlatformTextureSettings( platformSettings );
            // }
            //
            // if ( m_standaloneSettings != null )
            // {
            //     var platformSettings = importer.GetPlatformTextureSettings( "Standalone" );
            //     m_standaloneSettings.Apply( platformSettings );
            //     importer.SetPlatformTextureSettings( platformSettings );
            // }
            //
            // if ( m_iPhoneSettings != null )
            // {
            //     var platformSettings = importer.GetPlatformTextureSettings( "iPhone" );
            //     platformSettings.overridden = true;
            //     m_iPhoneSettings.Apply( platformSettings );
            //     importer.SetPlatformTextureSettings( platformSettings );
            // }
            //
            // if ( m_androidSettings != null )
            // {
            //     var platformSettings = importer.GetPlatformTextureSettings( "Android" );
            //     m_androidSettings.Apply( platformSettings );
            //     importer.SetPlatformTextureSettings( platformSettings );
            // }
            //
            // if ( m_webGLSettings != null )
            // {
            //     var platformSettings = importer.GetPlatformTextureSettings( "WebGL" );
            //     m_webGLSettings.Apply( platformSettings );
            //     importer.SetPlatformTextureSettings( platformSettings );
            // }
            //
            // importer.SetTextureSettings( settings );
        }
    }
}