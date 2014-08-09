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

		UpdateSE();
		UpdateBMG();
		this.m_cView.SEbtn.OnClick += OnClickSE;
		this.m_cView.BMGbtn.OnClick += OnClickBMG;
	}

	/// <summary>
	/// Hiden this instance.
	/// </summary>
	public override void Hiden ()
	{
		base.Hiden ();
		Destroy();
	}

	private void UpdateSE()
	{
		this.m_cView.SEbtn.GetComponent<tk2dSprite>().SetSprite(GameData.s_bSE?"L4_0001_yes":"L4_0000_no");
	}

	private void UpdateBMG()
	{
		this.m_cView.BMGbtn.GetComponent<tk2dSprite>().SetSprite(GameData.s_bBMG?"L4_0001_yes":"L4_0000_no");
	}

	private void OnClickSE()
	{
		GameData.s_bSE = !GameData.s_bSE;
		GameData.Save();
		UpdateSE();

		if(!GameData.s_bSE)
			MediaMgr.sInstance.StopENV();
	}

	private void OnClickBMG()
	{
		GameData.s_bBMG = !GameData.s_bBMG;
		GameData.Save();
		UpdateBMG();
		if(!GameData.s_bBMG)
			MediaMgr.sInstance.StopBGM();
	}

	private void OnClickBack()
	{
		Hiden();
		UISettingController.sInstance.Show();
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}

}
