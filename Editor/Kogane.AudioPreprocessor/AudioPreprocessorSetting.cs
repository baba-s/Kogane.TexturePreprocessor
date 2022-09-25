using System;

namespace Kogane.Internal
{
    /// <summary>
    /// アセットのパスに紐づくオーディオの Import Settings を管理するクラス
    /// </summary>
    [Serializable]
    internal sealed class AudioPreprocessorSetting : PreprocessorSettingBase<AudioImporterSettings>
    {
    }
}