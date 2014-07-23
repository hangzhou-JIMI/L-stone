using UnityEngine;
using System.Collections;
using Game.MVC;
using Game.Resource;

//	GUITittle.cs
//	Author: Lu Zexi
//	2014-07-16



/// <summary>
/// GUI tittle.
/// </summary>
public class GUITittle : GUIBase<GUITittle>
{
	private const string MAIN_RES = "GUITittle";	//the main res path.
	private const string BACK_PATH = "back";	//background

	/// <summary>
	/// Show this instance.
	/// </summary>
	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);

		this.m_cMain = GameObject.Instantiate(ResourcesManager.LoadResources(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);

		tk2dUIItem btn = this.m_cMain.GetComponent<tk2dUIItem>();
		btn.OnClick += OnClickBackground;
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
		GUILogin.sInstance.Show();
	}
}
