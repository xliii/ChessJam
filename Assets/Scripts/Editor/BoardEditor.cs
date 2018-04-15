using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Board))]
public class BoardEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		Board board = (Board) target;

		string message;
		bool invalid = board.level.Invalid(out message);
		EditorGUI.BeginDisabledGroup(invalid);
		if (GUILayout.Button("Generate"))
		{
			board.Clear();
			board.Generate();
		}
		EditorGUI.EndDisabledGroup();

		if (invalid)
		{
			EditorGUILayout.HelpBox(message, MessageType.Error);
		}
	}
}
