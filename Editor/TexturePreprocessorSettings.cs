using System;
using UnityEngine;

namespace UniTexturePreprocessor
{
	/// <summary>
	/// アセットのパスごとにテクスチャの Import Settings を管理するクラス
	/// </summary>
	[CreateAssetMenu( fileName = "TexturePreprocessorSettings", menuName = "UniTexturePreprocessor/TexturePreprocessorSettings", order = 10049 )]
	internal sealed class TexturePreprocessorSettings : PreprocessorSettingsBaseT<TexturePreprocessorSetting>
	{
	}

	/// <summary>
	/// アセットのパスに紐づくテクスチャの Import Settings を管理するクラス
	/// </summary>
	[Serializable]
	internal sealed class TexturePreprocessorSetting : PreprocessorSettingBaseT<TextureImporterSettings>
	{
	}
}