using UnityEngine;
using System;
using System.IO;
using System.Collections;

//	TittleScene.cs
//	Author: Lu Zexi
//	2014-07-16



/// <summary>
/// Tittle scene.
/// </summary>
public class TittleScene : CScene
{
	/// <summary>
	/// Raises the enter event.
	/// </summary>
	public override void OnEnter ()
	{
		base.OnEnter ();
		Texture2D tex = Resources.Load("SHARE_IMG") as Texture2D;
		byte[] data = tex.EncodeToPNG();
		File.WriteAllBytes(GUI_DEFINE.SHARE_IMG , data);
		WeiboShare.sInstance.Init();
		GameData.Load();
		UITittleController.sInstance.Show();
	}
	
	/// <summary>
	/// Raises the exit event.
	/// </summary>
	public override void OnExit ()
	{
		base.OnExit ();
		UITittleController.sInstance.Hiden();
	}
}

