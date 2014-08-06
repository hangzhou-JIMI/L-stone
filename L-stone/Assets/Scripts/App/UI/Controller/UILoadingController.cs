using UnityEngine;
using System.Collections;
using Game.MVC;


//	UILoadingController.cs
//	Author: Lu Zexi
//	2014-08-06



/// <summary>
/// User interface loading controller.
/// </summary>
public class UILoadingController : UIControllerBase<UILoadingController>
{
	private const string MAIN_RES = "GUILoading";
	private UIViewLoading m_cView;	//view

	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(Resources.Load(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);
		this.m_cMain.transform.localPosition = new Vector3(0,0,-110);
		this.m_cView = this.m_cMain.GetComponent<UIViewLoading>();
	}

	public override void Hiden ()
	{
		base.Hiden ();
		Destroy();
	}
}

