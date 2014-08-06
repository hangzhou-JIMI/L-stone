using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Media;


//	GUISetting.cs
//	Author: Lu Zexi
//	2014-07-16



/// <summary>
/// GUI setting.
/// </summary>
public class UISettingController : UIControllerBase<UISettingController>
{
	private const string MAIN_RES = "GUISetting";
	private UIViewSetting m_cView;	//view

	/// <summary>
	/// Show this instance.
	/// </summary>
	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(Resources.Load(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);

		this.m_cView = this.m_cMain.GetComponent<UIViewSetting>();
		//
		tk2dUIItem musci = this.m_cView.music;
		musci.OnClick += OnClickMusci;
		tk2dUIItem producer = this.m_cView.producer;
		producer.OnClick += OnClickProducer;
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

	/// <summary>
	/// Raises the click musci event.
	/// </summary>
	private void OnClickMusci()
	{
		Hiden();
		UIMusicController.sInstance.Show();
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}

	/// <summary>
	/// Raises the click producer event.
	/// </summary>
	private void OnClickProducer()
	{
		Hiden();
		UIProducerController.sInstance.Show();
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
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
