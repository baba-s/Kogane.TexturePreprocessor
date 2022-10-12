using System.Linq;
using UnityEditor;

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
            // Mac だと Unity Hub から起動した場合も
            // Application.isBatchMode が true になってしまうためコメントアウト
            // // バッチモードの場合は何もしません
            // if ( Application.isBatchMode ) return;

            // MacBook Pro 16 インチ 2021 だと
            // シングルトンな ScriptableObject を OnPreprocessTexture で参照すると
            // 変更された設定が反映されていない古い ScriptableObject が返ってきてしまうため
            // 強制的に .json ファイルの内容を読み込んで使用するようにしています
            var preprocessorSettings = TexturePreprocessorSettings.GetInstance( true );

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