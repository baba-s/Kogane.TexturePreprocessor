using System;

namespace Kogane.Internal
{
    /// <summary>
    /// アセットのパスに紐づくテクスチャの Import Settings を管理するクラス
    /// </summary>
    [Serializable]
    internal sealed class TexturePreprocessorSetting :
        PreprocessorSettingBase<TextureImporterSettings>
    {
    }
}