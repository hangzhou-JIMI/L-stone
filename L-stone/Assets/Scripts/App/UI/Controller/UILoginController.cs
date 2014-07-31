using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Resource;
using Game.Media;

//	GUILogin.cs
//	Author: Lu Zexi
//	2014-07-16



/// <summary>
/// GUI login.
/// </summary>
public class UILoginController : UIControllerBase<UILoginController>
{
	private const string MAIN_RES = "GUILogin";
	private UIViewLogin m_cView;	//view

	/// <summary>
	/// Show this instance.
	/// </summary>
	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);

		this.m_cMain = GameObject.Instantiate(ResourcesManager.LoadResources(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);

		this.m_cView = this.m_cMain.GetComponent<UIViewLogin>();

		tk2dUIItem start1 = this.m_cView.start1;
		start1.OnClick += OnClickStart1;
		tk2dUIItem start2 = this.m_cView.start2;
		start2.OnClick += OnClickStart2;
		tk2dUIItem setting = this.m_cView.setting;
		setting.OnClick += OnClickSetting;

		this.m_cView.other.OnClick += OnClickOther;
		MediaMgr.sInstance.PlayBGM(GUI_DEFINE.BGM_login,true);
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
	/// Raises the click start1 event.
	/// </summary>
	private void OnClickStart1()
	{
		Hiden();
		UIGameController.sInstance.Show();
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}

	/// <summary>
	/// Raises the click start2 event.
	/// </summary>
	private void OnClickStart2()
	{
		Hiden();
		UIGameFinalController.sInstance.Show();
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}

	/// <summary>
	/// Raises the click other event.
	/// </summary>
	private void OnClickOther()
	{
		WapsUnitySDK.sInstance.offerShowAction();
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}

	/// <summary>
	/// Raises the click setting event.
	/// </summary>
	private void OnClickSetting()
	{
		Hiden();
		UISettingController.sInstance.Show();
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}
}
