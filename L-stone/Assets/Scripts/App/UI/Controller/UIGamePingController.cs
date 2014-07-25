using UnityEngine;
using System.Collections;
using Game.Resource;


//	UIGamePingController.cs
//	Author: Lu Zexi
//	2014-07-24


/// <summary>
/// Game Ping Controller
/// </summary>
public class UIGamePingController : UIControllerBase<UIGamePingController>
{
	private const string MAIN_RES = "GUIGamePing";	//main res
	private UIViewGamePing m_cView;	//view
	private static int s_iPingNum = 0;
	
	/// <summary>
	/// Show view
	/// </summary>
	public override void Show ()
	{
		if(IsShow) return;
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(ResourcesManager.LoadResources(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);
		this.m_cMain.transform.localPosition = new Vector3(0,0,-100);
		
		this.m_cView = this.m_cMain.GetComponent<UIViewGamePing>();
		this.m_cView.back.OnClick += OnClickBackground;
		this.m_cView.share.OnClick += OnClickShare;

		s_iPingNum++;
		if(s_iPingNum % 3 == 0)
		{
			WapsUnitySDK.sInstance.showBanner();
		}
	}
	
	/// <summary>
	/// Hiden view
	/// </summary>
	public override void Hiden ()
	{
		base.Hiden ();
		Destroy();
	}

	/// <summary>
	/// Raises the click background event.
	/// </summary>
	private void OnClickBackground()
	{
		Hiden();
		if(UIGameController.sInstance.IsShow)
			UIGameController.sInstance.StartGame();
		else if(UIGameFinalController.sInstance.IsShow)
			UIGameFinalController.sInstance.StartGame();
	}

	/// <summary>
	/// Raises the click share event.
	/// </summary>
	private void OnClickShare()
	{
		//
	}
}

