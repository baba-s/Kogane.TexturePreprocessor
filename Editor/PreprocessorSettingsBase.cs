using System;
using UnityEngine;

namespace UniTexturePreprocessor
{
	/// <summary>
	/// テクスチャや SpriteAtlas の設定の基底クラス
	/// Inspector のエディタ拡張を共通化するために必要
	/// </summary>
	internal abstract class PreprocessorSettingsBase : ScriptableObject
	{
	}
	
	/// <summary>
	/// テクスチャや SpriteAtlas の個別の設定の基底クラス
	/// Inspector のエディタ拡張を共通化するために必要
	/// </summary>
	[Serializable]
	internal abstract class PreprocessorSettingBase
	{
	}
}