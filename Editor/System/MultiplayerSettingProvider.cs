using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Ellyality.RPG
{
    public sealed class MultiplayerSettingProvider : AssetSettingsProvider
    {
        private string searchContext;
        private VisualElement rootElement;

        [SettingsProvider]
        private static SettingsProvider CreateProjectSettingsMenu() => new MultiplayerSettingProvider();

        public MultiplayerSettingProvider(string settingsWindowPath, Func<UnityEngine.Object> settingsGetter) 
            : base(settingsWindowPath, settingsGetter) 
        {
            CurrentSettings = FindSceneLoaderSettings();
            keywords = GetSearchKeywordsFromGUIContentProperties<MultiplayerSetting>();
        }

        /// <summary>
        /// The current SceneLoaderSettings used for this project.
        /// <para>
        /// This instance will be available in editor while playing and in any other player builds.
        /// To do so, this CurrentSettings needs to be an asset to be added to the Preloaded Assets
        /// list during the build process.
        /// </para>
        /// <para>See how this is done on <see cref="SceneLoaderBuildPlayer"/>.</para>
        /// </summary>
        public static MultiplayerSetting CurrentSettings
        {
            get
            {
                EditorBuildSettings.TryGetConfigObject(MultiplayerSetting.CONFIG_NAME, out MultiplayerSetting settings);
                return settings;
            }
            set
            {
                var remove = value == null;
                if (remove)
                {
                    EditorBuildSettings.RemoveConfigObject(MultiplayerSetting.CONFIG_NAME);
                }
                else
                {
                    EditorBuildSettings.AddConfigObject(MultiplayerSetting.CONFIG_NAME, value, overwrite: true);
                }
            }
        }

        public MultiplayerSettingProvider()
        : base("Project/Multiplayer", () => CurrentSettings)
        {
            CurrentSettings = FindSceneLoaderSettings();
            keywords = GetSearchKeywordsFromGUIContentProperties<MultiplayerSetting>();
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            this.rootElement = rootElement;
            this.searchContext = searchContext;
            base.OnActivate(searchContext, rootElement);
        }

        public override void OnGUI(string searchContext)
        {
            DrawCurrentSettingsGUI();
            EditorGUILayout.Space();

            var invalidSettings = CurrentSettings == null;
            if (invalidSettings) DisplaySettingsCreationGUI();
            else base.OnGUI(searchContext);
        }

        private void DrawCurrentSettingsGUI()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUI.indentLevel++;
            var settings = EditorGUILayout.ObjectField("Current Settings", CurrentSettings,
                typeof(MultiplayerSetting), allowSceneObjects: false) as MultiplayerSetting;
            if (settings) DrawCurrentSettingsMessage();
            EditorGUI.indentLevel--;

            var newSettings = EditorGUI.EndChangeCheck();
            if (newSettings)
            {
                CurrentSettings = settings;
                RefreshEditor();
            }
        }

        private void RefreshEditor() => base.OnActivate(searchContext, rootElement);

        private void DisplaySettingsCreationGUI()
        {
            const string message = "You have no Scene Loader Settings. Would you like to create one?";
            EditorGUILayout.HelpBox(message, MessageType.Info, wide: true);
            var openCreationdialog = GUILayout.Button("Create");
            if (openCreationdialog)
            {
                CurrentSettings = SaveSceneLoaderAsset();
            }
        }

        private void DrawCurrentSettingsMessage()
        {
            const string message = "This is the current Scene Loader Settings and " +
                "it will be automatically included into any builds.";
            EditorGUILayout.HelpBox(message, MessageType.Info, wide: true);
        }

        private static MultiplayerSetting FindSceneLoaderSettings()
        {
            var filter = $"t:{typeof(MultiplayerSetting).Name}";
            var guids = AssetDatabase.FindAssets(filter);
            var hasGuids = guids.Length > 0;
            var path = hasGuids ? AssetDatabase.GUIDToAssetPath(guids[0]) : string.Empty;

            return AssetDatabase.LoadAssetAtPath<MultiplayerSetting>(path);
        }

        private static MultiplayerSetting SaveSceneLoaderAsset()
        {
            var path = EditorUtility.SaveFilePanelInProject(
                title: "Save Scene Loader Settings", defaultName: "DefaultMultiplayerSettings", extension: "asset",
                message: "Please enter a filename to save the projects Scene Loader settings.");
            var invalidPath = string.IsNullOrEmpty(path);
            if (invalidPath) return null;

            var settings = ScriptableObject.CreateInstance<MultiplayerSetting>();
            AssetDatabase.CreateAsset(settings, path);
            AssetDatabase.SaveAssets();

            Selection.activeObject = settings;
            return settings;
        }
    }
}
