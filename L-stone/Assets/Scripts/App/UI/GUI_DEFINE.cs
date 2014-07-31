using UnityEngine;
using System.Collections;


//	GUI_DEFINE.cs
//	Author: Lu Zexi
//	2014-07-16


/// <summary>
/// GU i_ DEFIN.
/// </summary>
public class GUI_DEFINE
{
	public const string BGM_login ="Music/BGM_login";
	public const string BGM_game = "Music/BGM_game";
	public const string SE_btn = "Music/SE_btn";
	public const string SE_playbtn = "Music/SE_playbtn";
	public const string SE_win = "Music/SE_win";
	public const string SE_lose = "Music/SE_lose";
	public const string SE_ping = "Music/SE_ping";
	public const string SE_gundong = "Music/SE_gundong";

	private const string ANCHOR_CENTER_PATH = "root/center";
	private static GameObject sANCHOR_CENTER = null;
	public static GameObject ANCHOR_CENTER
	{
		get
		{
			if( sANCHOR_CENTER == null)
			{
				sANCHOR_CENTER = GameObject.Find(ANCHOR_CENTER_PATH);
			}
			return sANCHOR_CENTER;
		}
	}
}

