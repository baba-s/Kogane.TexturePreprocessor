using UnityEditor;

namespace Kogane.Internal
{
    [FilePath( "ProjectSettings/Kogane/TexturePreprocessorSettings.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class TexturePreprocessorSettings :
        PreprocessorSettingsBase<TexturePreprocessorSettings, TexturePreprocessorSetting>
    {
    }
}