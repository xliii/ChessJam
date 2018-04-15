using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(LevelConfig))]
public class LevelEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		LevelConfig level = (LevelConfig) target;

		HashSet<string> violations;
		if (level.Invalid(out violations))
		{
			foreach (var violation in violations)
			{
				EditorGUILayout.HelpBox(violation, MessageType.Error);	
			}
		}
	}
}
