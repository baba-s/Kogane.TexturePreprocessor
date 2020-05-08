using System;
using UnityEngine;

namespace UniTexturePreprocessor
{
	/// <summary>
	/// アセットのパスごとに SpriteAtlas の Import Settings を管理するクラス
	/// </summary>
	[CreateAssetMenu( fileName = "SpriteAtlasPreprocessorSettings", menuName = "UniTexturePreprocessor/SpriteAtlasPreprocessorSettings", order = 10069 )]
	internal sealed class SpriteAtlasPreprocessorSettings : PreprocessorSettingsBaseT<SpriteAtlasPreprocessorSetting>
	{
	}

	/// <summary>
	/// アセットのパスに紐づく SpriteAtlas の Import Settings を管理するクラス
	/// </summary>
	[Serializable]
	internal sealed class SpriteAtlasPreprocessorSetting : PreprocessorSettingBaseT<SpriteAtlasImporterSettings>
	{
	}
}