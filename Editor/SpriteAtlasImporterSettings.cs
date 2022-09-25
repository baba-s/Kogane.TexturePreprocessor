using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

namespace Kogane.Internal
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

            if ( m_enableRotation.IsOverride )
            {
                packingSettings.enableRotation = m_enableRotation;
            }

            if ( m_enableTightPacking.IsOverride )
            {
                packingSettings.enableTightPacking = m_enableTightPacking;
            }

            if ( m_padding.IsOverride )
            {
                packingSettings.padding = m_padding;
            }

            spriteAtlas.SetPackingSettings( packingSettings );

            var textureSettings = spriteAtlas.GetTextureSettings();

            if ( m_readable.IsOverride )
            {
                textureSettings.readable = m_readable;
            }

            if ( m_generateMipMaps.IsOverride )
            {
                textureSettings.generateMipMaps = m_generateMipMaps;
            }

            if ( m_sRGB.IsOverride )
            {
                textureSettings.sRGB = m_sRGB;
            }

            if ( m_filterMode.IsOverride )
            {
                textureSettings.filterMode = m_filterMode;
            }

            if ( m_anisoLevel.IsOverride )
            {
                textureSettings.anisoLevel = m_anisoLevel;
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