using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GlowObjectCmd))]
public abstract class Piece : MonoBehaviour
{
    private GlowObjectCmd glowSelector;
    
    private void Awake()
    {
        glowSelector = GetComponent<GlowObjectCmd>();
    }

    private void Start()
    {
        The.Board.RegisterPiece(this);
    }

    public void Select()
    {
        glowSelector.Select();
        The.Board.ShowMoveMarkers(Moves());
    }

    public void Deselect()
    {
        glowSelector.Deselect();
        The.Board.HideMoveMarkers();
    }

    protected abstract List<Vector2Int> Moves();

    public abstract PieceType Type();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (The.Board == null) return;
        
        foreach (var pos in Moves())
        {            
            Gizmos.DrawSphere(new Vector3(pos.x, transform.position.y, pos.y), 0.2f);            
        }
    }

    public Vector2Int Position
    {
        get
        {
            return new Vector2Int((int) transform.position.x, (int) transform.position.z);
        }
    }

    public virtual IEnumerator Move(MoveMarker marker)
    {
        transform.position = marker.transform.position;
        yield return The.config.movementAnimation.Move(marker);
    }
}
