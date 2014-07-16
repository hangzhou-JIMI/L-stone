using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Resource;


/// <summary>
/// GUI music.
/// </summary>
public class GUIMusic : GUIBase<GUIMusic>
{
	private const string MAIN_RES = "GUIMusic";
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

	private void OnClickBack()
	{
		Hiden();
		GUISetting.sInstance.Show();
	}

}
