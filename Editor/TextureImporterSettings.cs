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
        [SerializeField] private OverrideTextureImporterType  m_textureType  = new OverrideTextureImporterType( "Texture Type", TextureImporterType.Default );
        [SerializeField] private OverrideTextureImporterShape m_textureShape = new OverrideTextureImporterShape( "Texture Shape", TextureImporterShape.Texture2D );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideSpriteImportMode m_spriteImportMode = new OverrideSpriteImportMode( "Sprite Mode", SpriteImportMode.Single );

        [SerializeField] private OverrideIntValue        m_spritePixelsPerUnit                = new OverrideIntValue( "Pixels Per Unit", 100 );
        [SerializeField] private OverrideSpriteMeshType  m_spriteMeshType                     = new OverrideSpriteMeshType( "Mesh Type", SpriteMeshType.Tight );
        [SerializeField] private OverrideUintValue       m_spriteExtrude                      = new OverrideUintValue( "Extrude Edges", 1 );
        [SerializeField] private OverrideSpriteAlignment m_spriteAlignment                    = new OverrideSpriteAlignment( "Pivot", SpriteAlignment.Center );
        [SerializeField] private OverrideVector2         m_spritePivot                        = new OverrideVector2( "Pivot Custom", new Vector2( 0.5f, 0.5f ) );
        [SerializeField] private OverrideBoolValue       m_spriteGenerateFallbackPhysicsShape = new OverrideBoolValue( "Generate Physics Shape", true );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideBoolValue m_sRGBTexture = new OverrideBoolValue( "sRGB (Color Texture)", true );

        [SerializeField] private OverrideTextureImporterAlphaSource m_alphaSource         = new OverrideTextureImporterAlphaSource( "Alpha Source", TextureImporterAlphaSource.FromInput );
        [SerializeField] private OverrideBoolValue                  m_alphaIsTransparency = new OverrideBoolValue( "Alpha Is Transparency", false );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideTextureImporterNPOTScale m_npotScale = new OverrideTextureImporterNPOTScale( "Non-Power of 2", TextureImporterNPOTScale.None );

        [SerializeField] private OverrideBoolValue m_readable                 = new OverrideBoolValue( "Read/Write Enabled", false );
        [SerializeField] private OverrideBoolValue m_streamingMipmaps         = new OverrideBoolValue( "Streaming Mipmaps", false );
        [SerializeField] private OverrideIntValue  m_streamingMipmapsPriority = new OverrideIntValue( "Mip Map Priority", 0 );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideBoolValue m_mipmapEnabled = new OverrideBoolValue( "Generate Mip Maps", true );

        [SerializeField] private OverrideBoolValue                m_borderMipmap            = new OverrideBoolValue( "Border Mip Maps", false );
        [SerializeField] private OverrideTextureImporterMipFilter m_mipmapFilter            = new OverrideTextureImporterMipFilter( "Mip Map Filtering", TextureImporterMipFilter.BoxFilter );
        [SerializeField] private OverrideBoolValue                m_mipMapsPreserveCoverage = new OverrideBoolValue( "Mip Maps Preserve Coverage", false );
        [SerializeField] private OverrideFloatValue               m_alphaTestReferenceValue = new OverrideFloatValue( "Alpha Cutoff Value", 0.5f );
        [SerializeField] private OverrideBoolValue                m_fadeOut                 = new OverrideBoolValue( "Fadeout Mip Maps", false );
        [SerializeField] private OverrideIntValue                 m_mipmapFadeDistanceStart = new OverrideIntValue( "Fade Range Start", 1 );
        [SerializeField] private OverrideIntValue                 m_mipmapFadeDistanceEnd   = new OverrideIntValue( "Fade Range End", 3 );

        [Space( SPACE_HEIGHT )]
        [SerializeField] private OverrideTextureWrapMode m_wrapMode = new OverrideTextureWrapMode( "Wrap Mode", TextureWrapMode.Clamp );

        [SerializeField] private OverrideFilterMode m_filterMode = new OverrideFilterMode( "Filter Mode", FilterMode.Bilinear );
        [SerializeField] private OverrideIntValue   m_aniso      = new OverrideIntValue( "Aniso Level", 1 );

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
        public void Apply( TextureImporter importer )
        {
            var settings = new UnityEditor.TextureImporterSettings();
            importer.ReadTextureSettings( settings );

            if ( m_textureType.IsOverride )
            {
                settings.textureType = m_textureType.Value;
            }

            if ( m_textureShape.IsOverride )
            {
                settings.textureShape = m_textureShape.Value;
            }

            if ( m_spritePixelsPerUnit.IsOverride )
            {
                settings.spritePixelsPerUnit = m_spritePixelsPerUnit.Value;
            }

            if ( m_spriteMeshType.IsOverride )
            {
                settings.spriteMeshType = m_spriteMeshType.Value;
            }

            if ( m_spriteExtrude.IsOverride )
            {
                settings.spriteExtrude = m_spriteExtrude.Value;
            }

            if ( m_spriteAlignment.IsOverride )
            {
                settings.spriteAlignment = ( int )m_spriteAlignment.Value;
            }

            if ( m_spritePivot.IsOverride )
            {
                settings.spritePivot = m_spritePivot.Value;
            }

            if ( m_spriteGenerateFallbackPhysicsShape.IsOverride )
            {
                settings.spriteGenerateFallbackPhysicsShape = m_spriteGenerateFallbackPhysicsShape.Value;
            }

            if ( m_sRGBTexture.IsOverride )
            {
                settings.sRGBTexture = m_sRGBTexture.Value;
            }

            if ( m_alphaSource.IsOverride )
            {
                settings.alphaSource = m_alphaSource.Value;
            }

            if ( m_alphaIsTransparency.IsOverride )
            {
                settings.alphaIsTransparency = m_alphaIsTransparency.Value;
            }

            if ( m_npotScale.IsOverride )
            {
                settings.npotScale = m_npotScale.Value;
            }

            if ( m_readable.IsOverride )
            {
                settings.readable = m_readable.Value;
            }

            if ( m_streamingMipmaps.IsOverride )
            {
                settings.streamingMipmaps = m_streamingMipmaps.Value;
            }

            if ( m_streamingMipmapsPriority.IsOverride )
            {
                settings.streamingMipmapsPriority = m_streamingMipmapsPriority.Value;
            }

            if ( m_mipmapEnabled.IsOverride )
            {
                settings.mipmapEnabled = m_mipmapEnabled.Value;
            }

            if ( m_borderMipmap.IsOverride )
            {
                settings.borderMipmap = m_borderMipmap.Value;
            }

            if ( m_mipmapFilter.IsOverride )
            {
                settings.mipmapFilter = m_mipmapFilter.Value;
            }

            if ( m_mipMapsPreserveCoverage.IsOverride )
            {
                settings.mipMapsPreserveCoverage = m_mipMapsPreserveCoverage.Value;
            }

            if ( m_alphaTestReferenceValue.IsOverride )
            {
                settings.alphaTestReferenceValue = m_alphaTestReferenceValue.Value;
            }

            if ( m_fadeOut.IsOverride )
            {
                settings.fadeOut = m_fadeOut.Value;
            }

            if ( m_mipmapFadeDistanceStart.IsOverride )
            {
                settings.mipmapFadeDistanceStart = m_mipmapFadeDistanceStart.Value;
            }

            if ( m_mipmapFadeDistanceEnd.IsOverride )
            {
                settings.mipmapFadeDistanceEnd = m_mipmapFadeDistanceEnd.Value;
            }

            if ( m_wrapMode.IsOverride )
            {
                settings.wrapMode = m_wrapMode.Value;
            }

            if ( m_filterMode.IsOverride )
            {
                settings.filterMode = m_filterMode.Value;
            }

            if ( m_aniso.IsOverride )
            {
                settings.aniso = m_aniso.Value;
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
                platformSettings.overridden = true;
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
                importer.spriteImportMode = m_spriteImportMode.Value;
            }
        }
    }
}