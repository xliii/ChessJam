using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ItemConfig))]
public class ItemConfigDrawer : PropertyDrawer {
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        
        var typeRect = new Rect(position.x, position.y, 100, position.height);
        var positionRect = new Rect(position.x + 105, position.y, 100, position.height);
        EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("pieceType"), GUIContent.none);
        EditorGUI.PropertyField(positionRect, property.FindPropertyRelative("position"), GUIContent.none);
        
        EditorGUI.EndProperty();
    }
}
