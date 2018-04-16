using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		EditorGUI.BeginChangeCheck();
		DrawDefaultInspector();

		Level level = (Level) target;

		HashSet<string> violations;
		
		bool invalid = level.Invalid(out violations); 
		
		if (invalid)
		{
			foreach (var violation in violations)
			{
				EditorGUILayout.HelpBox(violation, MessageType.Error);	
			}
		}

		if (EditorGUI.EndChangeCheck())
		{
			if (!invalid)
			{
				if (The.Board.level == level)
				{
					The.Board.Generate();	
				}
			}				
		}
	}
}
