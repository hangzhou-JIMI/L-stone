using UnityEngine;
using System.Collections;

//	UIViewGame.cs
//	Author: Lu Zexi
//	2014-07-24

/// <summary>
/// Game View
/// </summary>
public class UIViewGame : UIViewBase
{
	public tk2dUIItem backbtn;	//back btn
	public tk2dSprite selfAnimatedSprite;	//self sprite
	public tk2dSpriteAnimator selfAni;	//self animation
	public tk2dSprite pcAnimatedSprite;	//pc sprite
	public tk2dSpriteAnimator pcAni;	//pc animation
	public tk2dUIItem play;	//stop
	public tk2dTextMesh level;	//level
}

