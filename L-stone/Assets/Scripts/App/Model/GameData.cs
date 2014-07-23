using UnityEngine;
using System.Collections;



/// <summary>
/// Game data.
/// </summary>
public class GameData
{
	public static int s_iLevel = 1;	//the level of the lstone

	public void Save()
	{
		PlayerPrefs.SetInt("level",s_iLevel);
	}

	public void Load()
	{
		s_iLevel = PlayerPrefs.GetInt("level");
	}
}

