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

