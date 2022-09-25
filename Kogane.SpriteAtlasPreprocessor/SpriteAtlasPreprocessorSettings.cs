using UnityEditor;

namespace Kogane.Internal
{
    [FilePath( "ProjectSettings/Kogane/SpriteAtlasPreprocessorSettings.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class SpriteAtlasPreprocessorSettings :
        PreprocessorSettingsBase<SpriteAtlasPreprocessorSettings, SpriteAtlasPreprocessorSetting>
    {
    }
}