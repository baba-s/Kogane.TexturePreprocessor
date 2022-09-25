using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// テクスチャの Import Settings を管理するクラス
    /// </summary>
    [CreateAssetMenu( fileName = "TextureImporterSettings", menuName = "UniTexturePreprocessor/TextureImporterSettings", order = 10050 )]
    internal sealed class TextureImporterSettings : ScriptableObject
    {
        //================================================================================
        // 定数
        //================================================================================
        private const float SPACE_HEIGHT = 16;

        //================================================================================
        // 変数(SerializeField)
        //================================================================================
        [SerializeField] private OverrideValue<TextureImporterType>  m_textureType  = new( "Texture Type", TextureImporterType.Default );
        [SerializeField] private OverrideValue<TextureImporterShape> m_textureShape = new( "Texture Shape", TextureImporterShape.Texture2D );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideValue<SpriteImportMode> m_spriteImportMode = new( "Sprite Mode", SpriteImportMode.Single );

        [SerializeField] private OverrideValue<int>             m_spritePixelsPerUnit                = new( "Pixels Per Unit", 100 );
        [SerializeField] private OverrideValue<SpriteMeshType>  m_spriteMeshType                     = new( "Mesh Type", SpriteMeshType.Tight );
        [SerializeField] private OverrideValue<uint>            m_spriteExtrude                      = new( "Extrude Edges", 1 );
        [SerializeField] private OverrideValue<SpriteAlignment> m_spriteAlignment                    = new( "Pivot", SpriteAlignment.Center );
        [SerializeField] private OverrideValue<Vector2>         m_spritePivot                        = new( "Pivot Custom", new Vector2( 0.5f, 0.5f ) );
        [SerializeField] private OverrideValue<bool>            m_spriteGenerateFallbackPhysicsShape = new( "Generate Physics Shape", true );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideValue<bool> m_sRGBTexture = new( "sRGB (Color Texture)", true );

        [SerializeField] private OverrideValue<TextureImporterAlphaSource> m_alphaSource         = new( "Alpha Source", TextureImporterAlphaSource.FromInput );
        [SerializeField] private OverrideValue<bool>                       m_alphaIsTransparency = new( "Alpha Is Transparency", false );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideValue<TextureImporterNPOTScale> m_npotScale = new( "Non-Power of 2", TextureImporterNPOTScale.None );

        [SerializeField] private OverrideValue<bool> m_readable                 = new( "Read/Write Enabled", false );
        [SerializeField] private OverrideValue<bool> m_streamingMipmaps         = new( "Streaming Mipmaps", false );
        [SerializeField] private OverrideValue<int>  m_streamingMipmapsPriority = new( "Mip Map Priority", 0 );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideValue<bool> m_mipmapEnabled = new( "Generate Mip Maps", true );

        [SerializeField] private OverrideValue<bool>                     m_borderMipmap            = new( "Border Mip Maps", false );
        [SerializeField] private OverrideValue<TextureImporterMipFilter> m_mipmapFilter            = new( "Mip Map Filtering", TextureImporterMipFilter.BoxFilter );
        [SerializeField] private OverrideValue<bool>                     m_mipMapsPreserveCoverage = new( "Mip Maps Preserve Coverage", false );
        [SerializeField] private OverrideValue<float>                    m_alphaTestReferenceValue = new( "Alpha Cutoff Value", 0.5f );
        [SerializeField] private OverrideValue<bool>                     m_fadeOut                 = new( "Fadeout Mip Maps", false );
        [SerializeField] private OverrideValue<int>                      m_mipmapFadeDistanceStart = new( "Fade Range Start", 1 );
        [SerializeField] private OverrideValue<int>                      m_mipmapFadeDistanceEnd   = new( "Fade Range End", 3 );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideValue<TextureWrapMode> m_wrapMode = new( "Wrap Mode", TextureWrapMode.Clamp );

        [SerializeField] private OverrideValue<FilterMode> m_filterMode = new( "Filter Mode", FilterMode.Bilinear );
        [SerializeField] private OverrideValue<int>        m_aniso      = new( "Aniso Level", 1 );

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
        /// 指定された Importer に設定を適用します
        /// </summary>
        public void Apply( TextureImporter importer )
        {
            var settings = new UnityEditor.TextureImporterSettings();
            importer.ReadTextureSettings( settings );

            if ( m_textureType.IsOverride )
            {
                settings.textureType = m_textureType;
            }

            if ( m_textureShape.IsOverride )
            {
                settings.textureShape = m_textureShape;
            }

            if ( m_spritePixelsPerUnit.IsOverride )
            {
                settings.spritePixelsPerUnit = m_spritePixelsPerUnit;
            }

            if ( m_spriteMeshType.IsOverride )
            {
                settings.spriteMeshType = m_spriteMeshType;
            }

            if ( m_spriteExtrude.IsOverride )
            {
                settings.spriteExtrude = m_spriteExtrude;
            }

            if ( m_spriteAlignment.IsOverride )
            {
                settings.spriteAlignment = ( int )m_spriteAlignment.Value;
            }

            if ( m_spritePivot.IsOverride )
            {
                settings.spritePivot = m_spritePivot;
            }

            if ( m_spriteGenerateFallbackPhysicsShape.IsOverride )
            {
                settings.spriteGenerateFallbackPhysicsShape = m_spriteGenerateFallbackPhysicsShape;
            }

            if ( m_sRGBTexture.IsOverride )
            {
                settings.sRGBTexture = m_sRGBTexture;
            }

            if ( m_alphaSource.IsOverride )
            {
                settings.alphaSource = m_alphaSource;
            }

            if ( m_alphaIsTransparency.IsOverride )
            {
                settings.alphaIsTransparency = m_alphaIsTransparency;
            }

            if ( m_npotScale.IsOverride )
            {
                settings.npotScale = m_npotScale;
            }

            if ( m_readable.IsOverride )
            {
                settings.readable = m_readable;
            }

            if ( m_streamingMipmaps.IsOverride )
            {
                settings.streamingMipmaps = m_streamingMipmaps;
            }

            if ( m_streamingMipmapsPriority.IsOverride )
            {
                settings.streamingMipmapsPriority = m_streamingMipmapsPriority;
            }

            if ( m_mipmapEnabled.IsOverride )
            {
                settings.mipmapEnabled = m_mipmapEnabled;
            }

            if ( m_borderMipmap.IsOverride )
            {
                settings.borderMipmap = m_borderMipmap;
            }

            if ( m_mipmapFilter.IsOverride )
            {
                settings.mipmapFilter = m_mipmapFilter;
            }

            if ( m_mipMapsPreserveCoverage.IsOverride )
            {
                settings.mipMapsPreserveCoverage = m_mipMapsPreserveCoverage;
            }

            if ( m_alphaTestReferenceValue.IsOverride )
            {
                settings.alphaTestReferenceValue = m_alphaTestReferenceValue;
            }

            if ( m_fadeOut.IsOverride )
            {
                settings.fadeOut = m_fadeOut;
            }

            if ( m_mipmapFadeDistanceStart.IsOverride )
            {
                settings.mipmapFadeDistanceStart = m_mipmapFadeDistanceStart;
            }

            if ( m_mipmapFadeDistanceEnd.IsOverride )
            {
                settings.mipmapFadeDistanceEnd = m_mipmapFadeDistanceEnd;
            }

            if ( m_wrapMode.IsOverride )
            {
                settings.wrapMode = m_wrapMode;
            }

            if ( m_filterMode.IsOverride )
            {
                settings.filterMode = m_filterMode;
            }

            if ( m_aniso.IsOverride )
            {
                settings.aniso = m_aniso;
            }

            if ( m_defaultSettings != null )
            {
                var platformSettings = importer.GetPlatformTextureSettings( "DefaultTexturePlatform" );
                m_defaultSettings.Apply( platformSettings );
                importer.SetPlatformTextureSettings( platformSettings );
            }

            if ( m_standaloneSettings != null )
            {
                var platformSettings = importer.GetPlatformTextureSettings( "Standalone" );
                m_standaloneSettings.Apply( platformSettings );
                importer.SetPlatformTextureSettings( platformSettings );
            }

            if ( m_iPhoneSettings != null )
            {
                var platformSettings = importer.GetPlatformTextureSettings( "iPhone" );
                m_iPhoneSettings.Apply( platformSettings );
                importer.SetPlatformTextureSettings( platformSettings );
            }

            if ( m_androidSettings != null )
            {
                var platformSettings = importer.GetPlatformTextureSettings( "Android" );
                m_androidSettings.Apply( platformSettings );
                importer.SetPlatformTextureSettings( platformSettings );
            }

            if ( m_webGLSettings != null )
            {
                var platformSettings = importer.GetPlatformTextureSettings( "WebGL" );
                m_webGLSettings.Apply( platformSettings );
                importer.SetPlatformTextureSettings( platformSettings );
            }

            importer.SetTextureSettings( settings );

            // TextureImporterSettings は Sprite Mode のパラメータを持っていないため
            // TextureImporter で設定する必要がある
            // また、Sprite Mode は SetTextureSettings の後に設定しないと反映されないので
            // SetTextureSettings の後に設定するようにしています
            if ( m_spriteImportMode.IsOverride )
            {
                importer.spriteImportMode = m_spriteImportMode;
            }
        }
    }
}