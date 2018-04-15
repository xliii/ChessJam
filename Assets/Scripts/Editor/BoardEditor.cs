using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Board))]
public class BoardEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		Board board = (Board) target;

		HashSet<string> violations = new HashSet<string>();

		bool invalid;
		if (board.level == null)
		{
			invalid = true;
			violations.Add("Level config missing");
		}
		else
		{
			invalid = board.level.Invalid(out violations);
		}
		
		EditorGUI.BeginDisabledGroup(invalid);
		if (GUILayout.Button("Generate"))
		{
			board.Clear();
			board.Generate();
		}
		EditorGUI.EndDisabledGroup();

		if (invalid)
		{
			foreach (var violation in violations)
			{
				EditorGUILayout.HelpBox(violation, MessageType.Error);	
			}
		}
	}
}
