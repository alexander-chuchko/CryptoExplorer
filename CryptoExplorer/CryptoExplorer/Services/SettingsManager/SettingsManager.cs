
namespace CryptoExplorer.Services.SettingsManager
{
    public class SettingsManager : ISettingsManager
    {
        public bool IsDarkTheme
        {
            get { return Properties.Settings.Default.isDarkTheme; }
            set 
            {
                Properties.Settings.Default.isDarkTheme = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
