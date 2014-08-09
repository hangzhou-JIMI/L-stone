using UnityEngine;
using System.Collections;



/// <summary>
/// Game data.
/// </summary>
public class GameData
{
	public static int s_iLevel = 1;	//the level of the lstone
	public static bool s_bSE = true;
	public static bool s_bBMG = true;

	public static void Save()
	{
		PlayerPrefs.SetInt("level",s_iLevel);
		PlayerPrefs.SetInt("SE_Switch",s_bSE?1:0);
		PlayerPrefs.SetInt("BMG_Switch",s_bBMG?1:0);
	}

	public static void Load()
	{
		s_iLevel = PlayerPrefs.GetInt("level");
		if(s_iLevel<=0 )
			s_iLevel = 1;
		if(PlayerPrefs.HasKey("SE_Switch"))
		{
			s_bSE = PlayerPrefs.GetInt("SE_Switch")>0?true:false;
		}
		if(PlayerPrefs.HasKey("BMG_Switch"))
		{
			s_bBMG = PlayerPrefs.GetInt("BMG_Switch")>0?true:false;
		}

	}
}

