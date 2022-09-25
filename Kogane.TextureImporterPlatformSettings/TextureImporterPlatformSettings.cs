using UnityEditor;
using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// テクスチャのプラットフォームごとの Import Settings を管理するクラス
    /// </summary>
    public sealed class TextureImporterPlatformSettings : ScriptableObject
    {
        //================================================================================
        // 変数(SerializeField)
        //================================================================================
        [SerializeField] private OverrideValue<bool>                        m_overridden                  = new( "Override", false );
        [SerializeField] private OverrideValue<int>                         m_maxTextureSize              = new( "Max Size", 2048 );
        [SerializeField] private OverrideValue<TextureResizeAlgorithm>      m_resizeAlgorithm             = new( "Resize Algorithm", TextureResizeAlgorithm.Mitchell );
        [SerializeField] private OverrideValue<TextureImporterFormat>       m_format                      = new( "Format", TextureImporterFormat.Automatic );
        [SerializeField] private OverrideValue<TextureImporterCompression>  m_textureCompression          = new( "Compression", TextureImporterCompression.Compressed );
        [SerializeField] private OverrideValue<bool>                        m_crunchedCompression         = new( "Use Crunch Compression", false );
        [SerializeField] private OverrideValue<int>                         m_compressionQuality          = new( "Compressor Quality", 50 );
        [SerializeField] private OverrideValue<bool>                        m_allowsAlphaSplitting        = new( "Split Alpha Channel", false );
        [SerializeField] private OverrideValue<AndroidETC2FallbackOverride> m_androidEtc2FallbackOverride = new( "Override ETC2 fallback", AndroidETC2FallbackOverride.UseBuildSettings );

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// 指定された TextureImporterPlatformSettings に設定を適用します
        /// </summary>
        public void Apply( UnityEditor.TextureImporterPlatformSettings settings )
        {
            m_overridden.Override( x => settings.overridden                                   = x );
            m_maxTextureSize.Override( x => settings.maxTextureSize                           = x );
            m_resizeAlgorithm.Override( x => settings.resizeAlgorithm                         = x );
            m_format.Override( x => settings.format                                           = x );
            m_textureCompression.Override( x => settings.textureCompression                   = x );
            m_compressionQuality.Override( x => settings.compressionQuality                   = x );
            m_crunchedCompression.Override( x => settings.crunchedCompression                 = x );
            m_allowsAlphaSplitting.Override( x => settings.allowsAlphaSplitting               = x );
            m_androidEtc2FallbackOverride.Override( x => settings.androidETC2FallbackOverride = x );
        }
    }
}