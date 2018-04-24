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

	public static bool LastLevel
	{
		get
		{
			return CurrentLevel == The.config.campaign.Size - 1;	
		}
	}

	public static void NextLevel()
	{
		var nextLevel = CurrentLevel + 1;
		UnlockLevel(nextLevel);
		SetLevel(nextLevel);
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
