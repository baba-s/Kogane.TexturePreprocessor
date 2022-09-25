using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// オーディオのプラットフォームごとの Import Settings を管理するクラス
    /// </summary>
    internal sealed class AudioImporterPlatformSettings : ScriptableObject
    {
        //================================================================================
        // 変数(SerializeField)
        //================================================================================
        [SerializeField] private OverrideValue<bool>                   m_overridden         = new( "Override", false );
        [SerializeField] private OverrideValue<AudioClipLoadType>      m_loadType           = new( "Load Type", AudioClipLoadType.DecompressOnLoad );
        [SerializeField] private OverrideValue<AudioSampleRateSetting> m_sampleRateSetting  = new( "Sample Rate Setting", AudioSampleRateSetting.PreserveSampleRate );
        [SerializeField] private OverrideValue<uint>                   m_sampleRateOverride = new( "Sample Rate", 44100 );
        [SerializeField] private OverrideValue<AudioCompressionFormat> m_compressionFormat  = new( "Compression Format", AudioCompressionFormat.Vorbis );
        [SerializeField] private OverrideValue<float>                  m_quality            = new( "Quality", 1 );

        //================================================================================
        // プロパティ
        //================================================================================
        public bool Overridden => m_overridden;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// 指定された AudioImporterSampleSettings に設定を適用します
        /// </summary>
        public AudioImporterSampleSettings Apply( AudioImporterSampleSettings settings )
        {
            m_loadType.Override( x => settings.loadType                     = x );
            m_sampleRateSetting.Override( x => settings.sampleRateSetting   = x );
            m_sampleRateOverride.Override( x => settings.sampleRateOverride = x );
            m_compressionFormat.Override( x => settings.compressionFormat   = x );
            m_quality.Override( x => settings.quality                       = x );

            return settings;
        }
    }
}