using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Board))]
public class BoardEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		Board board = (Board) target;

		bool invalid = board.OutOfRange(board.finish);

		EditorGUI.BeginDisabledGroup(invalid);
		if (GUILayout.Button("Generate"))
		{
			board.Clear();
			board.Generate();
		}
		EditorGUI.EndDisabledGroup();

		if (invalid)
		{
			EditorGUILayout.HelpBox("Finish out of bounds", MessageType.Error);
		}
	}
}
