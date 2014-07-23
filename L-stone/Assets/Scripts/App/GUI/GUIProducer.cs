using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Resource;


//	GUIProducer.cs
//	Author: Lu Zexi
//	2014-07-16



/// <summary>
/// GUI producer.
/// </summary>
public class GUIProducer : GUIBase<GUIProducer>
{
	private const string MAIN_RES = "GUIProducer";	//the main resources
	private const string BACK_BTN_PATH = "backbtn";	//back btn

	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(ResourcesManager.LoadResources(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);

		tk2dUIItem back = FIND<tk2dUIItem>(this.m_cMain , BACK_BTN_PATH);
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
		GUISetting.sInstance.Show();
	}
}
