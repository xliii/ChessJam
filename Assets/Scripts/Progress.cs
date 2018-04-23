using UnityEngine;

public class Progress
{
	private static readonly string PREFS_CURRENT_LEVEL = "CurrentLevel";
	private static readonly string PREFS_UNLOCKED_LEVEL = "UnlockedLevel";

	public static int CurrentLevel
	{
		get
		{
			return PlayerPrefs.GetInt(PREFS_CURRENT_LEVEL, 0);	
		}
	}

	public static int UnlockedLevel
	{
		get
		{
			return PlayerPrefs.GetInt(PREFS_UNLOCKED_LEVEL, 0);			
		}
	}

	/**
	 * Returns true if next level is available, false otherwise (game is completed)
	 */
	public static bool NextLevel()
	{
		var nextLevel = CurrentLevel + 1;
		if (nextLevel >= The.config.campaign.Size)
		{
			return false;
		}
		UnlockLevel(nextLevel);
		SetLevel(nextLevel);
		return true;
	}

	private static void UnlockLevel(int level)
	{
		if (level > UnlockedLevel)
		{
			PlayerPrefs.SetInt(PREFS_UNLOCKED_LEVEL, level);
		}
	}

	private static void SetLevel(int level)
	{
		PlayerPrefs.SetInt(PREFS_CURRENT_LEVEL, level);
	}
}
