using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	public LevelConfig level;

	public BoardDirection Direction
	{
		get { return level.direction; }
	}

	public Vector2Int Finish
	{
		get { return level.finish; }
	}

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
		return level.OutOfRange(pos);
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
		for (var x = 0; x < level.size.x; x++)
		{
			for (var y = 0; y < level.size.y; y++)
			{
				if (Finish == new Vector2Int(x, y))
				{
					Instantiate(The.config.prefabConfig.finishSquare, new Vector3(x, transform.position.y, y), Quaternion.identity, transform);
				}
				else
				{
					Instantiate(prefab(x, y), new Vector3(x, transform.position.y, y), Quaternion.identity, transform);	
				}
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
		return (x + y) % 2 == 0 ? The.config.prefabConfig.blackSquare : The.config.prefabConfig.whiteSquare;
	}
}
