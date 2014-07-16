using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Resource;


//	GUIGame.cs
//	Author: Lu Zexi
//	2014-06-16


/// <summary>
/// GUI game.
/// </summary>
public class GUIGame : GUIBase<GUIGame>
{
	private const string MAIN_RES = "GUIGame";
	private const string BACK_BTN_PATH = "backbtn";	//back btn
	private const string SELF_SP_PATH = "selfAnimatedSprite";	//self sprite
	private const string PC_SP_PATH = "pcAnimatedSprite";	//pc sprite
	private const string STOP_BTN_PATH = "play";	//stop
	private const string LEVEL_PATH = "level";	//level

	private tk2dSpriteAnimator m_cSelfAni;	//self animation
	private tk2dSprite m_cSelfSp;	//self sprite
	private tk2dSpriteAnimator m_cPcAni;	//pc animation
	private tk2dSprite m_cPcSP;	//pc sprite
	private tk2dTextMesh m_cLevel;	//level

	/// <summary>
	/// Show this instance.
	/// </summary>
	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(ResourcesManager.LoadResources(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);

		tk2dUIItem backBtn = FIND<tk2dUIItem>(this.m_cMain , BACK_BTN_PATH);
		backBtn.OnClick += OnClickBack;

		tk2dUIItem stopBtn = FIND<tk2dUIItem>(this.m_cMain , STOP_BTN_PATH);
		stopBtn.OnClick += OnClickStop;

		this.m_cSelfAni = FIND<tk2dSpriteAnimator>(this.m_cMain , SELF_SP_PATH);
		this.m_cSelfSp = FIND<tk2dSprite>(this.m_cMain , SELF_SP_PATH);
		this.m_cPcAni = FIND<tk2dSpriteAnimator>(this.m_cMain , PC_SP_PATH);
		this.m_cPcSP = FIND<tk2dSprite>(this.m_cMain , PC_SP_PATH);

		this.m_cSelfAni.Play();
		this.m_cPcAni.Play();

		this.m_cLevel = FIND<tk2dTextMesh>(this.m_cMain , LEVEL_PATH);
		this.m_cLevel.text = "" + GameData.s_iLevel;
	}

	/// <summary>
	/// Hiden this instance.
	/// </summary>
	public override void Hiden ()
	{
		base.Hiden ();
		Destroy();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		//
	}

	/// <summary>
	/// Raises the click stop event.
	/// </summary>
	private void OnClickStop()
	{
		this.m_cSelfAni.Stop();
		this.m_cPcAni.Stop();
		int self , pc;
		int win =GAMEUtil.StoneCalculate(GameData.s_iLevel , out self , out pc);
		switch(win)
		{
		case 0:
			Debug.Log("ping");
			break;
		case 1:
			GameData.s_iLevel++;
			Debug.Log("win");
			break;
		case -1:
			GameData.s_iLevel--;
			Debug.Log("lose");
			break;
		}
		this.m_cLevel.text = "" + GameData.s_iLevel;

		switch( self )
		{
		case 0:	//stone
			this.m_cSelfSp.SetSprite("L2_0004_男石头");
			break;
		case 1:	//jian
			this.m_cSelfSp.SetSprite("L2_0003_男剪刀");
			break;
		case 2:	//bu
			this.m_cSelfSp.SetSprite("L2_0002_男布");
			break;
		}
		switch( pc )
		{
		case 0:	//stone
			this.m_cPcSP.SetSprite("L2_0004_男石头");
			break;
		case 1:	//jian
			this.m_cPcSP.SetSprite("L2_0003_男剪刀");
			break;
		case 2:	//bu
			this.m_cPcSP.SetSprite("L2_0002_男布");
			break;
		}
	}

	/// <summary>
	/// Raises the click back event.
	/// </summary>
	private void OnClickBack()
	{
		Hiden();
		GUILogin.sInstance.Show();
	}

}
