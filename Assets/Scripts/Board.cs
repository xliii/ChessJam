using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	public Vector2Int size;

	public GameObject white;

	public GameObject black;

	public BoardDirection direction;

	void Awake()
	{
		The.Board = this;
	}

	private Dictionary<Vector2Int, Piece> objects = new Dictionary<Vector2Int, Piece>();

	private List<MoveMarker> moveMarkers = new List<MoveMarker>();

	public void ShowMoveMarkers(List<Vector2Int> positions)
	{
		for (int i = 0; i < positions.Count; i++)
		{
			var position = new Vector3(positions[i].x, 0, positions[i].y);
			if (i < moveMarkers.Count)
			{
				var marker = moveMarkers[i];
				marker.transform.position = position;
				marker.SetActive(true);
				
			}
			else
			{
				var marker = Instantiate(The.config.prefabConfig.moveMarker, position, Quaternion.identity, transform);
				moveMarkers.Add(marker);	
			}
		}
	}

	public void RegisterPiece(Piece piece)
	{
		objects[piece.Position] = piece;
	}

	public void ClearPiece(Piece piece)
	{
		objects.Remove(piece.Position);
	}

	public bool OutOfRange(Vector2Int pos)
	{
		return pos.y < 0 || pos.x < 0 || pos.x >= size.x || pos.y >= size.y;
	}

	public bool Empty(Vector2Int pos)
	{
		return !objects.ContainsKey(pos);
	}

	public void HideMoveMarkers()
	{
		foreach (var marker in moveMarkers)
		{
			marker.SetActive(false);
		}
	}

	public void Generate()
	{
		for (var x = 0; x < size.x; x++)
		{
			for (var y = 0; y < size.y; y++)
			{
				Instantiate(prefab(x, y), new Vector3(x, transform.position.y, y), Quaternion.identity, transform);
			}
		}
	}

	public void Clear()
	{
		for (var i = transform.childCount - 1; i >= 0; i--)
		{
			var child = transform.GetChild(i);
			DestroyImmediate(child.gameObject);
		}
	}

	private GameObject prefab(int x, int y)
	{
		return (x + y) % 2 == 0 ? black : white;
	}
}
