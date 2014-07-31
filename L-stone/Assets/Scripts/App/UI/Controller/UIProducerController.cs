using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Resource;
using Game.Media;


//	GUIProducer.cs
//	Author: Lu Zexi
//	2014-07-16



/// <summary>
/// GUI producer.
/// </summary>
public class UIProducerController : UIControllerBase<UIProducerController>
{
	private const string MAIN_RES = "GUIProducer";	//the main resources
	private UIViewProducer m_cView;	//view

	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(ResourcesManager.LoadResources(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);

		this.m_cView = this.m_cMain.GetComponent<UIViewProducer>();

		tk2dUIItem back = this.m_cView.backbtn;
		back.OnClick +=OnClickBack;
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
	/// Raises the click back event.
	/// </summary>
	private void OnClickBack()
	{
		Hiden();
		UISettingController.sInstance.Show();
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}
}
