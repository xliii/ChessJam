using UnityEditor;
using UnityEngine;

public class PlayerPrefsTool {

	[MenuItem("PlayerPrefs/Clear All")]
	static void ClearPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("PlayerPrefs Cleared");
	}
}
