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
		// 変数(static)
		//================================================================================
		private static TexturePreprocessorSettings m_settings;

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

			// 設定ファイルをまだ読み込んでいない場合は読み込みます
			if ( m_settings == null )
			{
				m_settings = AssetDatabase
						.FindAssets( "t:TexturePreprocessorSettings" )
						.Select( x => AssetDatabase.GUIDToAssetPath( x ) )
						.Select( x => AssetDatabase.LoadAssetAtPath<TexturePreprocessorSettings>( x ) )
						.FirstOrDefault()
					;
			}

			// 設定ファイルが存在しない場合は何もしません
			if ( m_settings == null ) return;

			// 設定ファイルから該当する Import Setting の情報を取得します
			var settings = m_settings.List
				.Where( x => !string.IsNullOrWhiteSpace( x.Path ) )
				.FirstOrDefault( x => assetPath.StartsWith( x.Path ) );

			if ( settings == null ) return;
			if ( settings.Settings == null ) return;

			var textureImporter = ( TextureImporter ) assetImporter;

			// Import Settings を自動で設定します
			settings.Settings.Apply( textureImporter );
		}
	}
}