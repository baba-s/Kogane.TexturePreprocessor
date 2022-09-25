using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// オーディオをインポートする時に設定を適用するエディタ拡張
    /// </summary>
    internal sealed class AudioPreprocessor : AssetPostprocessor
    {
        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// オーディオをインポートする時に呼び出されます
        /// </summary>
        private void OnPreprocessAudio()
        {
            // バッチモードの場合は何もしません
            if ( Application.isBatchMode ) return;

            var preprocessorSettings = AudioPreprocessorSettings.instance;

            // 設定ファイルが存在しない場合は何もしません
            if ( preprocessorSettings == null ) return;

            // 設定ファイルから該当する Import Setting の情報を取得します
            var settings = preprocessorSettings
                    .Where( x => !string.IsNullOrWhiteSpace( x.Path ) )
                    .FirstOrDefault( x => assetPath.StartsWith( x.Path ) )
                ;

            if ( settings == null ) return;
            if ( settings.Settings == null ) return;

            // Import Settings を自動で設定します
            settings.Settings.Apply( ( AudioImporter )assetImporter );
        }
    }
}