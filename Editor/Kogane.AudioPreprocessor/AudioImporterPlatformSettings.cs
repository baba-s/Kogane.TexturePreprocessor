using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// オーディオのプラットフォームごとの Import Settings を管理するクラス
    /// </summary>
    [CreateAssetMenu( fileName = "AudioImporterPlatformSettings", menuName = "UniAudioPreprocessor/AudioImporterPlatformSettings", order = 10051 )]
    internal sealed class AudioImporterPlatformSettings : ScriptableObject
    {
        //================================================================================
        // 変数(SerializeField)
        //================================================================================
        [SerializeField] private OverrideBoolValue              m_overridden         = new( "Override", false );
        [SerializeField] private OverrideAudioClipLoadType      m_loadType           = new( "Load Type", AudioClipLoadType.DecompressOnLoad );
        [SerializeField] private OverrideAudioSampleRateSetting m_sampleRateSetting  = new( "Sample Rate Setting", AudioSampleRateSetting.PreserveSampleRate );
        [SerializeField] private OverrideUintValue              m_sampleRateOverride = new( "Sample Rate", 0 );
        [SerializeField] private OverrideAudioCompressionFormat m_compressionFormat  = new( "Compression Format", AudioCompressionFormat.Vorbis );
        [SerializeField] private OverrideFloatValue             m_quality            = new( "Quality", 1 );

        public bool Overridden => m_overridden;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// 指定された AudioImporterPlatformSettings に設定を適用します
        /// </summary>
        public AudioImporterSampleSettings Apply( AudioImporterSampleSettings settings )
        {
            // if ( m_overridden.IsOverride )
            // {
            //     settings.overridden = m_overridden.Value;
            // }

            if ( m_loadType.IsOverride )
            {
                settings.loadType = m_loadType;
            }

            if ( m_sampleRateSetting.IsOverride )
            {
                settings.sampleRateSetting = m_sampleRateSetting;
            }

            if ( m_sampleRateOverride.IsOverride )
            {
                settings.sampleRateOverride = m_sampleRateOverride;
            }

            if ( m_compressionFormat.IsOverride )
            {
                settings.compressionFormat = m_compressionFormat;
            }

            if ( m_quality.IsOverride )
            {
                settings.quality = m_quality;
            }

            return settings;
        }
    }
}