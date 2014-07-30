using UnityEngine;
using System.Collections;



/// <summary>
/// Game data.
/// </summary>
public class GameData
{
	public static int s_iLevel = 1;	//the level of the lstone

	public static void Save()
	{
		PlayerPrefs.SetInt("level",s_iLevel);
	}

	public static void Load()
	{
		s_iLevel = PlayerPrefs.GetInt("level");
	}
}

