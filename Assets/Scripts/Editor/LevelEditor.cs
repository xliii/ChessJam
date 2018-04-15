using System;
using UnityEditor;

[CustomEditor(typeof(LevelConfig))]
public class LevelEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		LevelConfig level = (LevelConfig) target;

		String message;
		if (level.Invalid(out message))
		{
			EditorGUILayout.HelpBox(message, MessageType.Error);
		}
	}
}
