using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	public Level level;

	public Transform items;

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

	void Start()
	{
		Events.RegisterEvent(Events.EventType.LEVEL_START, OnLevelStart);
		
		Events.TriggerEvent(Events.EventType.LEVEL_START);
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

	void OnLevelStart()
	{
		level = The.config.campaign.GetLevel(Progress.CurrentLevel);
		Generate();
	}

	public void Generate()
	{
		Clear();
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
		
		foreach (var item in level.items)
		{
			var piece = The.config.prefabConfig.white.GetPiece(item.pieceType);
			var pos = item.position;
			Instantiate(piece, new Vector3(pos.x, items.position.y, pos.y), Quaternion.identity, items);
		}
	}

	void Clear()
	{
		objects.Clear();
		moveMarkers.Clear();
		ClearChildren(transform);
		ClearChildren(items);
	}

	private void ClearChildren(Transform container)
	{
		for (var i = container.childCount - 1; i >= 0; i--)
		{
			var child = container.GetChild(i);
			DestroyImmediate(child.gameObject);
		}
	}

	private GameObject prefab(int x, int y)
	{
		return (x + y) % 2 == 0 ? The.config.prefabConfig.blackSquare : The.config.prefabConfig.whiteSquare;
	}
}
