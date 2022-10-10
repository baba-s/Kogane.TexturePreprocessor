namespace Kogane.Internal
{
    internal sealed class TexturePreprocessorSettings :
        PreprocessorSettingsBase<TexturePreprocessorSettings, TexturePreprocessorSetting>
    {
        private const string PATH = "ProjectSettings/Kogane/TexturePreprocessorSettings.json";

        public static TexturePreprocessorSettings Instance => GetInstance( PATH );

        public void Save()
        {
            SaveToJson( PATH );
        }
    }
}