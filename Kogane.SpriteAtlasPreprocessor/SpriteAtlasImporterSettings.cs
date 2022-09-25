using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

namespace Kogane.Internal
{
    /// <summary>
    /// SpriteAtlas の Import Settings を管理するクラス
    /// </summary>
    internal sealed class SpriteAtlasImporterSettings : ScriptableObject
    {
        //================================================================================
        // 定数
        //================================================================================
        private const float SPACE_HEIGHT = 16;

        //================================================================================
        // 変数(SerializeField)
        //================================================================================
        [SerializeField] private OverrideValue<bool> m_enableRotation     = new( "Allow Rotation", true );
        [SerializeField] private OverrideValue<bool> m_enableTightPacking = new( "Tight Packing", true );
        [SerializeField] private OverrideValue<int>  m_padding            = new( "Padding", 4 );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideValue<bool> m_readable = new( "Read/Write Enabled", false );

        [SerializeField] private OverrideValue<bool>       m_generateMipMaps = new( "Generate Mip Maps", false );
        [SerializeField] private OverrideValue<bool>       m_sRGB            = new( "sRGB", true );
        [SerializeField] private OverrideValue<FilterMode> m_filterMode      = new( "Filter Mode", FilterMode.Bilinear );
        [SerializeField] private OverrideValue<int>        m_anisoLevel      = new( "Aniso Level", 1 );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private TextureImporterPlatformSettings m_defaultSettings;

        [SerializeField] private TextureImporterPlatformSettings m_standaloneSettings;
        [SerializeField] private TextureImporterPlatformSettings m_iPhoneSettings;
        [SerializeField] private TextureImporterPlatformSettings m_androidSettings;
        [SerializeField] private TextureImporterPlatformSettings m_webGLSettings;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// 指定された TextureImporter に設定を適用します
        /// </summary>
        public void Apply( SpriteAtlas spriteAtlas )
        {
            var packingSettings = spriteAtlas.GetPackingSettings();

            m_enableRotation.Override( x => packingSettings.enableRotation         = x );
            m_enableTightPacking.Override( x => packingSettings.enableTightPacking = x );
            m_padding.Override( x => packingSettings.padding                       = x );

            spriteAtlas.SetPackingSettings( packingSettings );

            var textureSettings = spriteAtlas.GetTextureSettings();

            m_readable.Override( x => textureSettings.readable               = x );
            m_generateMipMaps.Override( x => textureSettings.generateMipMaps = x );
            m_sRGB.Override( x => textureSettings.sRGB                       = x );
            m_filterMode.Override( x => textureSettings.filterMode           = x );
            m_anisoLevel.Override( x => textureSettings.anisoLevel           = x );

            spriteAtlas.SetTextureSettings( textureSettings );

            ApplyPlatform( spriteAtlas, "DefaultTexturePlatform", m_defaultSettings );
            ApplyPlatform( spriteAtlas, "Standalone", m_standaloneSettings );
            ApplyPlatform( spriteAtlas, "iPhone", m_iPhoneSettings );
            ApplyPlatform( spriteAtlas, "Android", m_androidSettings );
            ApplyPlatform( spriteAtlas, "WebGL", m_webGLSettings );
        }

        /// <summary>
        /// プラットフォームごとの設定を適用します
        /// </summary>
        private static void ApplyPlatform
        (
            SpriteAtlas                     spriteAtlas,
            string                          buildTarget,
            TextureImporterPlatformSettings settings
        )
        {
            if ( settings == null ) return;

            var platformSettings = spriteAtlas.GetPlatformSettings( buildTarget );
            settings.Apply( spriteAtlas.GetPlatformSettings( buildTarget ) );
            spriteAtlas.SetPlatformSettings( platformSettings );
        }
    }
}