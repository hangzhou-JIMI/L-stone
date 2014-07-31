using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Resource;
using Game.Media;

//	GUITittle.cs
//	Author: Lu Zexi
//	2014-07-16



/// <summary>
/// GUI tittle.
/// </summary>
public class UITittleController : UIControllerBase<UITittleController>
{
	private const string MAIN_RES = "GUITittle";	//the main res path.2
	private UIViewTittle m_cView;	//view

	/// <summary>
	/// Show this instance.
	/// </summary>
	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);

		this.m_cMain = GameObject.Instantiate(ResourcesManager.LoadResources(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);

		this.m_cView = this.m_cMain.GetComponent<UIViewTittle>();
		this.m_cView.back.OnClick += OnClickBackground;

		MediaMgr.sInstance.PlayBGM(GUI_DEFINE.BGM_login);
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
	/// Raises the click background event.
	/// </summary>
	private void OnClickBackground()
	{
		Hiden();
		UILoginController.sInstance.Show();

		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}
}
