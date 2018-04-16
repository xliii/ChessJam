using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Config/Level")]
public class Level : ScriptableObject
{
    public Vector2Int size;

    public Vector2Int finish;
    
    public BoardDirection direction;

    public ItemConfig[] items;
    
    public bool OutOfRange(Vector2Int pos)
    {
        return pos.y < 0 || pos.x < 0 || pos.x >= size.x || pos.y >= size.y;
    }

    public bool Invalid(out HashSet<string> messages)
    {
        messages = new HashSet<string>();
        bool violation = false;

        if (size.x <= 0 || size.y <= 0)
        {
            messages.Add("Size should be positive");
            return true;
        }
        
        if (OutOfRange(finish))
        {
            messages.Add("Finish out of bounds");
            violation = true;
        }

        bool kingFound = false;
        HashSet<Vector2Int> usedPositions = new HashSet<Vector2Int>();
        foreach (var item in items)
        {
            if (OutOfRange(item.position))
            {
                messages.Add(item.pieceType + " out of range: " + item.position);
                violation = true;
            }
            
            if (usedPositions.Contains(item.position))
            {
                messages.Add("Multiple items at " + item.position);
                violation = true;
            }

            usedPositions.Add(item.position);
            
            if (item.pieceType == PieceType.KING)
            {
                if (kingFound)
                {
                    messages.Add("Multiple Kings not allowed");
                    violation = true;
                }

                if (item.position == finish)
                {
                    messages.Add("King may not start on finish square");
                    violation = true;
                }

                kingFound = true;
            }
        }

        if (!kingFound)
        {
            messages.Add("King must be present");
            violation = true;
        }

        return violation;
    }
}
