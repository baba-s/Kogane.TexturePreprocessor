namespace Kogane.Internal
{
    internal sealed class TexturePreprocessorSettings :
        PreprocessorSettingsBase<TexturePreprocessorSettings, TexturePreprocessorSetting>
    {
        private const string PATH = "ProjectSettings/Kogane/TexturePreprocessorSettings.json";

        public static TexturePreprocessorSettings GetInstance( bool force = false )
        {
            return GetInstance( PATH, force );
        }

        public void Save()
        {
            SaveToJson( PATH );
        }
    }
}