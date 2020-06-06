using System;
using UnityEngine;

namespace Kogane.Internal
{
	/// <summary>
	/// テクスチャや SpriteAtlas の設定の基底クラス
	/// </summary>
	internal abstract class PreprocessorSettingsBaseT<T> : PreprocessorSettingsBase
	{
		//================================================================================
		// 変数(SerializeField)
		//================================================================================
		[SerializeField] private T[] m_list = default;

		//================================================================================
		// プロパティ
		//================================================================================
		public T[] List => m_list;
	}
	
	/// <summary>
	/// テクスチャや SpriteAtlas の個別の設定の基底クラス
	/// </summary>
	[Serializable]
	internal abstract class PreprocessorSettingBaseT<T> : PreprocessorSettingBase
	{
		//================================================================================
		// 変数(SerializeField)
		//================================================================================
		[SerializeField] private string m_path     = default;
		[SerializeField] private T      m_settings = default;

		//================================================================================
		// プロパティ
		//================================================================================
		public string Path     => m_path;
		public T      Settings => m_settings;
	}
}