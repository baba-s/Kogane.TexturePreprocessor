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
        [SerializeField] private OverrideBoolValue m_enableRotation     = new( "Allow Rotation", true );
        [SerializeField] private OverrideBoolValue m_enableTightPacking = new( "Tight Packing", true );
        [SerializeField] private OverrideIntValue  m_padding            = new( "Padding", 4 );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideBoolValue m_readable = new( "Read/Write Enabled", false );

        [SerializeField] private OverrideBoolValue  m_generateMipMaps = new( "Generate Mip Maps", false );
        [SerializeField] private OverrideBoolValue  m_sRGB            = new( "sRGB", true );
        [SerializeField] private OverrideFilterMode m_filterMode      = new( "Filter Mode", FilterMode.Bilinear );
        [SerializeField] private OverrideIntValue   m_anisoLevel      = new( "Aniso Level", 1 );

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