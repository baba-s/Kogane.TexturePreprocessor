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

            m_textureType.Override( x => settings.textureType                                               = x );
            m_textureShape.Override( x => settings.textureShape                                             = x );
            m_spritePixelsPerUnit.Override( x => settings.spritePixelsPerUnit                               = x );
            m_spriteMeshType.Override( x => settings.spriteMeshType                                         = x );
            m_spriteExtrude.Override( x => settings.spriteExtrude                                           = x );
            m_spriteAlignment.Override( x => settings.spriteAlignment                                       = ( int )x );
            m_spritePivot.Override( x => settings.spritePivot                                               = x );
            m_spriteGenerateFallbackPhysicsShape.Override( x => settings.spriteGenerateFallbackPhysicsShape = x );
            m_sRGBTexture.Override( x => settings.sRGBTexture                                               = x );
            m_alphaSource.Override( x => settings.alphaSource                                               = x );
            m_alphaIsTransparency.Override( x => settings.alphaIsTransparency                               = x );
            m_npotScale.Override( x => settings.npotScale                                                   = x );
            m_readable.Override( x => settings.readable                                                     = x );
            m_streamingMipmaps.Override( x => settings.streamingMipmaps                                     = x );
            m_streamingMipmapsPriority.Override( x => settings.streamingMipmapsPriority                     = x );
            m_mipmapEnabled.Override( x => settings.mipmapEnabled                                           = x );
            m_borderMipmap.Override( x => settings.borderMipmap                                             = x );
            m_mipmapFilter.Override( x => settings.mipmapFilter                                             = x );
            m_mipMapsPreserveCoverage.Override( x => settings.mipMapsPreserveCoverage                       = x );
            m_alphaTestReferenceValue.Override( x => settings.alphaTestReferenceValue                       = x );
            m_fadeOut.Override( x => settings.fadeOut                                                       = x );
            m_mipmapFadeDistanceStart.Override( x => settings.mipmapFadeDistanceStart                       = x );
            m_mipmapFadeDistanceEnd.Override( x => settings.mipmapFadeDistanceEnd                           = x );
            m_wrapMode.Override( x => settings.wrapMode                                                     = x );
            m_filterMode.Override( x => settings.filterMode                                                 = x );
            m_aniso.Override( x => settings.aniso                                                           = x );

            ApplyPlatform( importer, "DefaultTexturePlatform", m_defaultSettings );
            ApplyPlatform( importer, "Standalone", m_standaloneSettings );
            ApplyPlatform( importer, "iPhone", m_iPhoneSettings );
            ApplyPlatform( importer, "Android", m_androidSettings );
            ApplyPlatform( importer, "WebGL", m_webGLSettings );

            importer.SetTextureSettings( settings );

            // TextureImporterSettings は Sprite Mode のパラメータを持っていないため
            // TextureImporter で設定する必要がある
            // また、Sprite Mode は SetTextureSettings の後に設定しないと反映されないので
            // SetTextureSettings の後に設定するようにしています
            m_spriteImportMode.Override( x => importer.spriteImportMode = x );
        }

        /// <summary>
        /// プラットフォームごとの設定を適用します
        /// </summary>
        private static void ApplyPlatform
        (
            TextureImporter                 importer,
            string                          buildTarget,
            TextureImporterPlatformSettings settings
        )
        {
            if ( settings == null ) return;

            var platformSettings = importer.GetPlatformTextureSettings( buildTarget );
            settings.Apply( platformSettings );
            importer.SetPlatformTextureSettings( platformSettings );
        }
    }
}