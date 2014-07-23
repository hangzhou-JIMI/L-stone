using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Resource;


//	GUISetting.cs
//	Author: Lu Zexi
//	2014-07-16



/// <summary>
/// GUI setting.
/// </summary>
public class GUISetting : GUIBase<GUISetting>
{
	private const string MAIN_RES = "GUISetting";
	private const string MUSIC_BTN_PATH = "music";
	private const string PRODUCER_BTN_PATH = "producer";
	private const string BACK_BTN_PATH = "backbtn";

	/// <summary>
	/// Show this instance.
	/// </summary>
	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(ResourcesManager.LoadResources(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);

		//
		tk2dUIItem musci = FIND<tk2dUIItem>(this.m_cMain , MUSIC_BTN_PATH);
		musci.OnClick += OnClickMusci;
		tk2dUIItem producer = FIND<tk2dUIItem>(this.m_cMain , PRODUCER_BTN_PATH);
		producer.OnClick += OnClickProducer;
		tk2dUIItem back = FIND<tk2dUIItem>(this.m_cMain , BACK_BTN_PATH);
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
		GUIMusic.sInstance.Show();
	}

	/// <summary>
	/// Raises the click producer event.
	/// </summary>
	private void OnClickProducer()
	{
		Hiden();
		GUIProducer.sInstance.Show();
	}

	/// <summary>
	/// Raises the click back event.
	/// </summary>
	private void OnClickBack()
	{
		Hiden();
		GUILogin.sInstance.Show();
	}
}
