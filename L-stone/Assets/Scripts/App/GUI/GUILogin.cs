using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Resource;

//	GUILogin.cs
//	Author: Lu Zexi
//	2014-07-16



/// <summary>
/// GUI login.
/// </summary>
public class GUILogin : GUIBase<GUILogin>
{
	private const string MAIN_RES = "GUILogin";
	private const string START1_BTN_PATH = "start1";
	private const string START2_BTN_PATH = "start2";
	private const string SETTING_BTN_PATH = "setting";

	/// <summary>
	/// Show this instance.
	/// </summary>
	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);

		this.m_cMain = GameObject.Instantiate(ResourcesManager.LoadResources(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);

		tk2dUIItem start1 = FIND<tk2dUIItem>(this.m_cMain , START1_BTN_PATH);
		start1.OnClick += OnClickStart1;
		tk2dUIItem start2 = FIND<tk2dUIItem>(this.m_cMain , START2_BTN_PATH);
		start2.OnClick += OnClickStart2;
		tk2dUIItem setting = FIND<tk2dUIItem>(this.m_cMain , SETTING_BTN_PATH);
		setting.OnClick += OnClickSetting;
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
		GUIGame.sInstance.Show();
	}

	/// <summary>
	/// Raises the click start2 event.
	/// </summary>
	private void OnClickStart2()
	{
		Debug.Log("onclick start2");
	}

	/// <summary>
	/// Raises the click setting event.
	/// </summary>
	private void OnClickSetting()
	{
		Hiden();
		GUISetting.sInstance.Show();
	}
}
