using System;

namespace Kogane.Internal
{
    /// <summary>
    /// アセットのパスに紐づく SpriteAtlas の Import Settings を管理するクラス
    /// </summary>
    [Serializable]
    internal sealed class SpriteAtlasPreprocessorSetting :
        PreprocessorSettingBase<SpriteAtlasImporterSettings>
    {
    }
}