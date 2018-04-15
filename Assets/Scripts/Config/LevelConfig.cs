using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Config/Level")]
public class LevelConfig : ScriptableObject
{

    public Vector2Int size;

    public BoardDirection direction;

    public Vector2Int finish;
}
