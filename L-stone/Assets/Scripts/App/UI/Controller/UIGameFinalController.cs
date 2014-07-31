using UnityEngine;
using System.Collections;
using Game.Resource;
using Game.Media;


//	UIGameFinalController.cs
//	Author: Lu Zexi
//	2014-07-25



/// <summary>
/// game final controller
/// </summary>
public class UIGameFinalController : UIControllerBase<UIGameFinalController>
{
	private const string MAIN_RES = "GUIGame";
	private UIViewGame m_cView;	//view
	private int m_iLevel;
	
	/// <summary>
	/// Starts the game.
	/// </summary>
	public void StartGame()
	{
		this.m_cView.selfAni.Play();
		this.m_cView.pcAni.Play();
		
	}
	
	/// <summary>
	/// Show this instance.
	/// </summary>
	public override void Show ()
	{
		if(IsShow)	return;
		base.Show();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(ResourcesManager.LoadResources(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);
		
		this.m_cView = this.m_cMain.GetComponent<UIViewGame>();
		
		tk2dUIItem backBtn = m_cView.backbtn;
		backBtn.OnClick += OnClickBack;
		
		tk2dUIItem stopBtn = m_cView.play;
		stopBtn.OnClick += OnClickStop;

		this.m_iLevel = 1;
		this.m_cView.level.text = "" + this.m_iLevel;
		WapsUnitySDK.sInstance.showBanner();
		StartGame();

		MediaMgr.sInstance.PlayBGM(GUI_DEFINE.BGM_game);
	}
	
	/// <summary>
	/// Hiden this instance.
	/// </summary>
	public override void Hiden ()
	{
		base.Hiden ();
		Destroy();
		WapsUnitySDK.sInstance.closeBanner();
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
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_playbtn);

		this.m_cView.selfAni.Stop();
		this.m_cView.pcAni.Stop();
		int self , pc;
		int win =GAMEUtil.StoneCalculate(this.m_iLevel , out self , out pc);
		switch(win)
		{
		case 0:
			Debug.Log("ping");
			UIGamePingController.sInstance.Show();
			break;
		case 1:
			this.m_iLevel++;
			GameData.Save();
			Debug.Log("win");
			UIGameWinController.sInstance.Show();
			break;
		case -1:
			this.m_iLevel--;
			if(this.m_iLevel <= 0 )
				this.m_iLevel = 1;
			Debug.Log("lose");
			UIGameLoseController.sInstance.Show();
			break;
		}
		this.m_cView.level.text = "" + this.m_iLevel;
		
		switch( self )
		{
		case 0:	//stone
			this.m_cView.selfAnimatedSprite.SetSprite("L2_0004_shitou");
			break;
		case 1:	//jian
			this.m_cView.selfAnimatedSprite.SetSprite("L2_0003_jiandao");
			break;
		case 2:	//bu
			this.m_cView.selfAnimatedSprite.SetSprite("L2_0002_bu");
			break;
		}
		switch( pc )
		{
		case 0:	//stone
			this.m_cView.pcAnimatedSprite.SetSprite("L2_0004_shitou");
			break;
		case 1:	//jian
			this.m_cView.pcAnimatedSprite.SetSprite("L2_0003_jiandao");
			break;
		case 2:	//bu
			this.m_cView.pcAnimatedSprite.SetSprite("L2_0002_bu");
			break;
		}
	}
	
	/// <summary>
	/// Raises the click back event.
	/// </summary>
	private void OnClickBack()
	{
		Hiden();
		UILoginController.sInstance.Show();

		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}
}

