using UnityEngine;
using System;
using System.Text;
using System.Collections;
using Game.Media;


//	UIGameLoseExController.cs
//	Author: Lu Zexi
//	2014-07-24



/// <summary>
/// Game Lose Extend Controller
/// </summary>
public class UIGameLoseExController : UIControllerBase<UIGameLoseExController>
{
	private const string MAIN_RES = "GUIGameLoseEx";	//main res
	private UIViewGameLoseEx m_cView;	//view
	private static int s_iLoseNum = 0;
	private float m_fStartTime;
	
	/// <summary>
	/// Show view
	/// </summary>
	public override void Show ()
	{
		if(IsShow) return;
		base.Show ();
		SET_PARENT(sInstance , GUI_DEFINE.ANCHOR_CENTER);
		
		this.m_cMain = GameObject.Instantiate(Resources.Load(MAIN_RES)) as GameObject;
		SET_PARENT(this.m_cMain , sInstance);
		this.m_cMain.transform.localPosition = new Vector3(0,0,-100);
		
		this.m_cView = this.m_cMain.GetComponent<UIViewGameLoseEx>();
		this.m_cView.backbtn.OnClick += OnClickBack;
		this.m_cView.sharebtn.OnClick += OnClickShare;
		
		this.m_fStartTime = Time.fixedTime;
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_lose);
		
		s_iLoseNum++;
		
		if( s_iLoseNum % 8 == 0)
		{
			WapsUnitySDK.sInstance.popShowAction();
		}
	}
	
	/// <summary>
	/// Hiden view
	/// </summary>
	public override void Hiden ()
	{
		base.Hiden ();
		Destroy();
	}
	
	/// <summary>
	/// Raises the click background event.
	/// </summary>
	private void OnClickBack()
	{
		if( Time.fixedTime - this.m_fStartTime < 1f)
			return;
		Hiden();

		UIGameFinalController.sInstance.Hiden();
		UILoginController.sInstance.Show();
	}
	
	/// <summary>
	/// Raises the click share event.
	/// </summary>
	private void OnClickShare()
	{
		//
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
		
		string str = "我已经到了"+GameData.s_iLevel+"层，这个游戏根本停不下来。http://www.luzexi.com";
		if(UIGameFinalController.sInstance.IsShow)
			str = "突破终结模式"+UIGameFinalController.sInstance.m_iLevel+"层,这个游戏根本停不下来.http://www.luzexi.com";
		//string str = "你好";
		//		byte[] data = Encoding.Convert(Encoding.Unicode , Encoding.UTF8 , Encoding.Unicode.GetBytes(str));
		//		char[] chars = new char[Encoding.UTF8.GetCharCount(data)];
		//		chars = Encoding.UTF8.GetChars(data);
		//		str = new string(chars);
		//Debug.Log("你好");
		Debug.Log(str);
		str = Uri.EscapeUriString(str);
		Debug.Log(str);
		WeiboShare.sInstance.Share( str ,GUI_DEFINE.SHARE_IMG);
	}
}
