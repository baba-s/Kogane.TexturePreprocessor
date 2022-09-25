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
        [SerializeField] private OverrideBoolValue m_preloadAudioData = new( "Preload Audio Data", true );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private AudioImporterPlatformSettings m_defaultSettings;

        [SerializeField] private AudioImporterPlatformSettings m_standaloneSettings;
        [SerializeField] private AudioImporterPlatformSettings m_iOSSettings;
        [SerializeField] private AudioImporterPlatformSettings m_androidSettings;
        [SerializeField] private AudioImporterPlatformSettings m_webGLSettings;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// 指定された Importer に設定を適用します
        /// </summary>
        public void Apply( AudioImporter importer )
        {
            m_forceToMono.Override( x => importer.forceToMono           = x );
            m_loadInBackground.Override( x => importer.loadInBackground = x );
            m_ambisonic.Override( x => importer.ambisonic               = x );
            m_preloadAudioData.Override( x => importer.preloadAudioData = x );

            if ( m_defaultSettings != null )
            {
                importer.defaultSampleSettings = m_defaultSettings.Apply( importer.defaultSampleSettings );
            }

            Apply( importer, BuildTargetGroup.Standalone, m_standaloneSettings );
            Apply( importer, BuildTargetGroup.iOS, m_iOSSettings );
            Apply( importer, BuildTargetGroup.Android, m_androidSettings );
            Apply( importer, BuildTargetGroup.WebGL, m_webGLSettings );
        }

        private static void Apply
        (
            AudioImporter                 importer,
            BuildTargetGroup              buildTargetGroup,
            AudioImporterPlatformSettings settings
        )
        {
            if ( settings == null ) return;

            var platform = buildTargetGroup.ToString();

            if ( settings.Overridden )
            {
                importer.SetOverrideSampleSettings
                (
                    platform,
                    settings.Apply( importer.GetOverrideSampleSettings( platform ) )
                );
            }
            else
            {
                importer.ClearSampleSettingOverride( platform );
            }
        }
    }
}