using UnityEngine;
using System.Collections;
using Game.MVC;



/// <summary>
/// User interface message controller.
/// </summary>
public class UIMessageController: UIControllerBase<UIMessageController>
{
	private const string MAIN_RES = "GUIMessage";
	private UIViewMessage m_cView;	//view

	/// <summary>
	/// Show this instance.
	/// </summary>
	public override void Show ()
	{
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(Resources.Load(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);
		this.m_cView = this.m_cMain.GetComponent<UIViewMessage>();
		this.m_cMain.transform.localPosition = new Vector3(0,0,-110);
		this.m_cView.m_cOkBtn.OnClick += OnOkBtn;
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
	/// Raises the ok button event.
	/// </summary>
	private void OnOkBtn()
	{
		Hiden();
	}
}

