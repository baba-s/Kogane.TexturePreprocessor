using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// テクスチャをインポートする時に設定を適用するエディタ拡張
    /// </summary>
    internal sealed class TexturePreprocessor : AssetPostprocessor
    {
        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// テクスチャをインポートする時に呼び出されます
        /// </summary>
        private void OnPreprocessTexture()
        {
            // バッチモードの場合は何もしません
            if ( Application.isBatchMode ) return;

            var preprocessorSettings = TexturePreprocessorSettings.instance;

            // 設定ファイルが存在しない場合は何もしません
            if ( preprocessorSettings == null ) return;

            // 設定ファイルから該当する Import Setting の情報を取得します
            var settings = preprocessorSettings
                .Where( x => !string.IsNullOrWhiteSpace( x.Path ) )
                .FirstOrDefault( x => assetPath.StartsWith( x.Path ) );

            if ( settings == null ) return;
            if ( settings.Settings == null ) return;

            // Import Settings を自動で設定します
            settings.Settings.Apply( ( TextureImporter )assetImporter );
        }
    }
}