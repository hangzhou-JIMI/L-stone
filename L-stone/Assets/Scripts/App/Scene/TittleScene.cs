using UnityEngine;
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

