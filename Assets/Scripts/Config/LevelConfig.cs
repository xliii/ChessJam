using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Config/Level")]
public class LevelConfig : ScriptableObject
{
    public Vector2Int size;

    public BoardDirection direction;

    public Vector2Int finish;
    
    public bool OutOfRange(Vector2Int pos)
    {
        return pos.y < 0 || pos.x < 0 || pos.x >= size.x || pos.y >= size.y;
    }

    public bool Invalid(out string message)
    {
        message = "";

        if (size.x <= 0 || size.y <= 0)
        {
            message = "Size should be positive";
            return true;
        }
        
        if (OutOfRange(finish))
        {
            message = "Finish out of bounds";
            return true;
        }
        
        return false;
    }
}
