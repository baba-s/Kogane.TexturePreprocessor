using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
	/// <summary>
	/// テクスチャのプラットフォームごとの Import Settings を管理するクラス
	/// </summary>
	[CreateAssetMenu( fileName = "TextureImporterPlatformSettings", menuName = "UniTexturePreprocessor/TextureImporterPlatformSettings", order = 10051 )]
	internal sealed class TextureImporterPlatformSettings : ScriptableObject
	{
		//================================================================================
		// 変数(SerializeField)
		//================================================================================
		[SerializeField] private OverrideBoolValue                   m_overridden                  = new OverrideBoolValue( "Override", false );
		[SerializeField] private OverrideIntValue                    m_maxTextureSize              = new OverrideIntValue( "Max Size", 2048 );
		[SerializeField] private OverrideTextureResizeAlgorithm      m_resizeAlgorithm             = new OverrideTextureResizeAlgorithm( "Resize Algorithm", TextureResizeAlgorithm.Mitchell );
		[SerializeField] private OverrideTextureImporterFormat       m_format                      = new OverrideTextureImporterFormat( "Format", TextureImporterFormat.Automatic );
		[SerializeField] private OverrideTextureImporterCompression  m_textureCompression          = new OverrideTextureImporterCompression( "Compression", TextureImporterCompression.Compressed );
		[SerializeField] private OverrideBoolValue                   m_crunchedCompression         = new OverrideBoolValue( "Use Crunch Compression", false );
		[SerializeField] private OverrideIntValue                    m_compressionQuality          = new OverrideIntValue( "Compressor Quality", 50 );
		[SerializeField] private OverrideBoolValue                   m_allowsAlphaSplitting        = new OverrideBoolValue( "Split Alpha Channel", false );
		[SerializeField] private OverrideAndroidETC2FallbackOverride m_androidEtc2FallbackOverride = new OverrideAndroidETC2FallbackOverride( "Override ETC2 fallback", AndroidETC2FallbackOverride.UseBuildSettings );

		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// 指定された TextureImporterPlatformSettings に設定を適用します
		/// </summary>
		public void Apply( UnityEditor.TextureImporterPlatformSettings settings )
		{
			if ( m_overridden.IsOverride )
			{
				settings.overridden = m_overridden.Value;
			}

			if ( m_maxTextureSize.IsOverride )
			{
				settings.maxTextureSize = m_maxTextureSize.Value;
			}

			if ( m_resizeAlgorithm.IsOverride )
			{
				settings.resizeAlgorithm = m_resizeAlgorithm.Value;
			}

			if ( m_format.IsOverride )
			{
				settings.format = m_format.Value;
			}

			if ( m_textureCompression.IsOverride )
			{
				settings.textureCompression = m_textureCompression.Value;
			}

			if ( m_compressionQuality.IsOverride )
			{
				settings.compressionQuality = m_compressionQuality.Value;
			}

			if ( m_crunchedCompression.IsOverride )
			{
				settings.crunchedCompression = m_crunchedCompression.Value;
			}

			if ( m_allowsAlphaSplitting.IsOverride )
			{
				settings.allowsAlphaSplitting = m_allowsAlphaSplitting.Value;
			}

			if ( m_androidEtc2FallbackOverride.IsOverride )
			{
				settings.androidETC2FallbackOverride = m_androidEtc2FallbackOverride.Value;
			}
		}
	}
}