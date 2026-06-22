using UnityEngine;
using UnityEditor;

public class BuildSettingsSetup
{
	[MenuItem("Tools/Setup Build Settings")]
	static void SetupBuildSettings()
	{
		EditorBuildSettingsScene[] scenes = new EditorBuildSettingsScene[]
		{
			new EditorBuildSettingsScene("Assets/Scenes/menu.unity", true),
			new EditorBuildSettingsScene("Assets/Scenes/game.unity", true),
			new EditorBuildSettingsScene("Assets/Scenes/game 1.unity", true),
			new EditorBuildSettingsScene("Assets/Scenes/MyFPS2.unity", true),
		};
		EditorBuildSettings.scenes = scenes;
		Debug.Log("Build settings updated: " + scenes.Length + " scenes added.");
	}
}
