using System.Linq;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace Elly.Multiplayer
{
    public sealed class MultiplayerSettingIMGUIRegister : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            var settings = MultiplayerSettingProvider.CurrentSettings;
            var settingsType = settings.GetType();
            var preloadedAssets = PlayerSettings.GetPreloadedAssets().ToList();
            // Removes all references from SceneLoaderSettings.
            preloadedAssets.RemoveAll(settings => settings.GetType() == settingsType);
            // Adds the Current SceneLoaderSettings.
            preloadedAssets.Add(settings);

            PlayerSettings.SetPreloadedAssets(preloadedAssets.ToArray());
        }
    }
}
