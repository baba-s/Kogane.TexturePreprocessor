using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;

namespace Kogane.Internal
{
    /// <summary>
    /// SpriteAtlas をインポートする時に設定を適用するエディタ拡張
    /// </summary>
    internal sealed class SpriteAtlasPreprocessor : AssetPostprocessor
    {
        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// SpriteAtlas をインポートする時に呼び出されます
        /// </summary>
        private static void OnPostprocessAllAssets
        (
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths
        )
        {
            // バッチモードの場合は何もしません
            if ( Application.isBatchMode ) return;

            var preprocessorSettings = SpriteAtlasPreprocessorSettings.instance;

            // 設定ファイルが存在しない場合は何もしません
            if ( preprocessorSettings == null ) return;

            var list = importedAssets
                    .Where( x => x.EndsWith( ".spriteatlas" ) )
                    .Select( x => ( assetPath: x, spriteAtlas: AssetDatabase.LoadAssetAtPath<SpriteAtlas>( x ) ) )
                    .Where( x => x.spriteAtlas != null )
                    .ToArray()
                ;

            if ( list.Length <= 0 ) return;

            foreach ( var (assetPath, spriteAtlas) in list )
            {
                // 設定ファイルから該当する Import Setting の情報を取得します
                var settings = preprocessorSettings.FirstOrDefault( x => assetPath.StartsWith( x.Path ) );

                if ( settings == null ) return;

                // Import Settings を自動で設定します
                settings.Settings.Apply( spriteAtlas );
            }
        }
    }
}