using UniTexturePreprocessor.Internal;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

namespace UniTexturePreprocessor
{
	/// <summary>
	/// SpriteAtlas の Import Settings を管理するクラス
	/// </summary>
	[CreateAssetMenu( fileName = "SpriteAtlasImporterSettings", menuName = "UniTexturePreprocessor/SpriteAtlasImporterSettings", order = 10070 )]
	internal sealed class SpriteAtlasImporterSettings : ScriptableObject
	{
		//================================================================================
		// 定数
		//================================================================================
		private const float SPACE_HEIGHT = 16;

		//================================================================================
		// 変数(SerializeField)
		//================================================================================
		[SerializeField] private OverrideBoolValue m_enableRotation     = new OverrideBoolValue( "Allow Rotation", true );
		[SerializeField] private OverrideBoolValue m_enableTightPacking = new OverrideBoolValue( "Tight Packing", true );
		[SerializeField] private OverrideIntValue  m_padding            = new OverrideIntValue( "Padding", 4 );

		[Space( SPACE_HEIGHT )]

		[SerializeField] private OverrideBoolValue  m_readable        = new OverrideBoolValue( "Read/Write Enabled", false );
		[SerializeField] private OverrideBoolValue  m_generateMipMaps = new OverrideBoolValue( "Generate Mip Maps", false );
		[SerializeField] private OverrideBoolValue  m_sRGB            = new OverrideBoolValue( "sRGB", true );
		[SerializeField] private OverrideFilterMode m_filterMode      = new OverrideFilterMode( "Filter Mode", FilterMode.Bilinear );
		[SerializeField] private OverrideIntValue   m_anisoLevel      = new OverrideIntValue( "Aniso Level", 1 );

		[Space( SPACE_HEIGHT )]

		[SerializeField] private TextureImporterPlatformSettings m_defaultSettings    = default;
		[SerializeField] private TextureImporterPlatformSettings m_standaloneSettings = default;
		[SerializeField] private TextureImporterPlatformSettings m_iPhoneSettings     = default;
		[SerializeField] private TextureImporterPlatformSettings m_androidSettings    = default;
		[SerializeField] private TextureImporterPlatformSettings m_webGLSettings      = default;

		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// 指定された TextureImporter に設定を適用します
		/// </summary>
		public void Apply( SpriteAtlas spriteAtlas )
		{
			var packingSettings = spriteAtlas.GetPackingSettings();

			if ( m_enableRotation.IsOverride )
			{
				packingSettings.enableRotation = m_enableRotation.Value;
			}

			if ( m_enableTightPacking.IsOverride )
			{
				packingSettings.enableTightPacking = m_enableTightPacking.Value;
			}

			if ( m_padding.IsOverride )
			{
				packingSettings.padding = m_padding.Value;
			}

			spriteAtlas.SetPackingSettings( packingSettings );

			var textureSettings = spriteAtlas.GetTextureSettings();

			if ( m_readable.IsOverride )
			{
				textureSettings.readable = m_readable.Value;
			}

			if ( m_generateMipMaps.IsOverride )
			{
				textureSettings.generateMipMaps = m_generateMipMaps.Value;
			}

			if ( m_sRGB.IsOverride )
			{
				textureSettings.sRGB = m_sRGB.Value;
			}

			if ( m_filterMode.IsOverride )
			{
				textureSettings.filterMode = m_filterMode.Value;
			}

			if ( m_anisoLevel.IsOverride )
			{
				textureSettings.anisoLevel = m_anisoLevel.Value;
			}

			spriteAtlas.SetTextureSettings( textureSettings );

			if ( m_defaultSettings != null )
			{
				var platformSettings = spriteAtlas.GetPlatformSettings( "DefaultTexturePlatform" );
				m_defaultSettings.Apply( platformSettings );
				spriteAtlas.SetPlatformSettings( platformSettings );
			}

			if ( m_standaloneSettings != null )
			{
				var platformSettings = spriteAtlas.GetPlatformSettings( "Standalone" );
				m_standaloneSettings.Apply( platformSettings );
				spriteAtlas.SetPlatformSettings( platformSettings );
			}

			if ( m_iPhoneSettings != null )
			{
				var platformSettings = spriteAtlas.GetPlatformSettings( "iPhone" );
				platformSettings.overridden = true;
				m_iPhoneSettings.Apply( platformSettings );
				spriteAtlas.SetPlatformSettings( platformSettings );
			}

			if ( m_androidSettings != null )
			{
				var platformSettings = spriteAtlas.GetPlatformSettings( "Android" );
				m_androidSettings.Apply( platformSettings );
				spriteAtlas.SetPlatformSettings( platformSettings );
			}

			if ( m_webGLSettings != null )
			{
				var platformSettings = spriteAtlas.GetPlatformSettings( "WebGL" );
				m_webGLSettings.Apply( platformSettings );
				spriteAtlas.SetPlatformSettings( platformSettings );
			}
		}
	}
}