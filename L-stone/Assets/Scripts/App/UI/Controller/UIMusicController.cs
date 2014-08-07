using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Media;


/// <summary>
/// GUI music.
/// </summary>
public class UIMusicController : UIControllerBase<UIMusicController>
{
	private const string MAIN_RES = "GUIMusic";
	private UIViewMusic m_cView;	//view

	/// <summary>
	/// Show this instance.
	/// </summary>
	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(Resources.Load(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);

		this.m_cView = this.m_cMain.GetComponent<UIViewMusic>();

		tk2dUIItem back = this.m_cView.backbtn;
		back.OnClick += OnClickBack;
	}

	/// <summary>
	/// Hiden this instance.
	/// </summary>
	public override void Hiden ()
	{
		base.Hiden ();
		Destroy();
	}

	private void OnClickBack()
	{
		Hiden();
		UISettingController.sInstance.Show();
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}

}
