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
        // 変数(static)
        //================================================================================
        private static AudioPreprocessorSettings m_settings;

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

            // 設定ファイルをまだ読み込んでいない場合は読み込みます
            if ( m_settings == null )
            {
                m_settings = AssetDatabase
                        .FindAssets( $"t:{nameof( AudioPreprocessorSettings )}" )
                        .Select( x => AssetDatabase.GUIDToAssetPath( x ) )
                        .Select( x => AssetDatabase.LoadAssetAtPath<AudioPreprocessorSettings>( x ) )
                        .FirstOrDefault()
                    ;
            }

            // 設定ファイルが存在しない場合は何もしません
            if ( m_settings == null ) return;

            // 設定ファイルから該当する Import Setting の情報を取得します
            var settings = m_settings.List
                    .Where( x => !string.IsNullOrWhiteSpace( x.Path ) )
                    .FirstOrDefault( x => assetPath.StartsWith( x.Path ) )
                ;

            if ( settings == null ) return;
            if ( settings.Settings == null ) return;

            var audioImporter = ( AudioImporter )assetImporter;

            // Import Settings を自動で設定します
            settings.Settings.Apply( audioImporter );
        }
    }
}