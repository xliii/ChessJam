using UnityEngine;

[CreateAssetMenu(fileName = "Campaign", menuName = "Config/Campaign")]
public class Campaign : ScriptableObject
{
	public Level[] levels;
}
