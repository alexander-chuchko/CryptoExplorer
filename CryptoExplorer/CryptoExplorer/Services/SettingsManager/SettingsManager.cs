
namespace CryptoExplorer.Services.SettingsManager
{
    public class SettingsManager : ISettingsManager
    {
        public bool IsDarkTheme
        {
            get => Properties.Settings.Default.isDarkTheme;
            set => Properties.Settings.Default.isDarkTheme = value;
        }
    }
}
