using UnityEngine;

[CreateAssetMenu(fileName = "Campaign", menuName = "Config/Campaign")]
public class Campaign : ScriptableObject
{
	public Level[] levels;

	public Level GetLevel(int index)
	{
		return levels[index];
	}

	public int Size
	{
		get { return levels.Length; }
	}
}
