using System;
using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// アセットのパスごとにオーディオの Import Settings を管理するクラス
    /// </summary>
    [CreateAssetMenu( fileName = "AudioPreprocessorSettings", menuName = "UniTexturePreprocessor/AudioPreprocessorSettings", order = 10049 )]
    internal sealed class AudioPreprocessorSettings : PreprocessorSettingsBaseT<AudioPreprocessorSetting>
    {
    }

    /// <summary>
    /// アセットのパスに紐づくオーディオの Import Settings を管理するクラス
    /// </summary>
    [Serializable]
    internal sealed class AudioPreprocessorSetting : PreprocessorSettingBaseT<AudioImporterSettings>
    {
    }
}