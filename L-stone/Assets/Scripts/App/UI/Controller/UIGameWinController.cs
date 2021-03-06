using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using Game.Media;

//	UIGameWinController.cs
//	Author: Lu Zexi
//	2014-07-24



/// <summary>
/// Game Win Controller
/// </summary>
public class UIGameWinController : UIControllerBase<UIGameWinController>
{
	private const string MAIN_RES = "GUIGameWin";	//main res
	private UIViewGameWin m_cView;	//view
	private float m_fStartTime;	//start time

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

		this.m_cView = this.m_cMain.GetComponent<UIViewGameWin>();
		this.m_cView.back.OnClick += OnClickBackground;
		this.m_cView.play.OnClick += OnClickBackground;
		this.m_cView.share.OnClick += OnClickShare;

		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_win);
		this.m_fStartTime = Time.fixedTime;
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
	/// Raises the click share event.
	/// </summary>
	private void OnClickShare()
	{
		Debug.Log("share");
		MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);

		string str = "我已经到了"+GameData.s_iLevel+"层,这个游戏根本停不下来. 乐石斗: https://itunes.apple.com/us/app/le-shi-dou-shi-tou-jian-dao-bu/id907729227?l=zh&ls=1&mt=8";
		if(UIGameFinalController.sInstance.IsShow)
			str = "突破终结模式"+UIGameFinalController.sInstance.m_iLevel+"层,这个游戏根本停不下来. 乐石斗: https://itunes.apple.com/us/app/le-shi-dou-shi-tou-jian-dao-bu/id907729227?l=zh&ls=1&mt=8";
		//string str = "你好";

//		byte[] data = Encoding.Convert(Encoding.Unicode , Encoding.UTF8 , Encoding.Unicode.GetBytes(str));
//		char[] chars = new char[Encoding.UTF8.GetCharCount(data)];
//		chars = Encoding.UTF8.GetChars(data);
//		str = new string(chars);
		//Debug.Log("你好");
		Debug.Log(str);
		str = Uri.EscapeUriString(str);
		Debug.Log(str);
		WeiboShare.sInstance.Share(str,GUI_DEFINE.SHARE_IMG);
	}

	/// <summary>
	/// Raises the click background event.
	/// </summary>
	private void OnClickBackground()
	{
		if( Time.fixedTime - this.m_fStartTime < 1f)
			return;


		Hiden();
		if(UIGameController.sInstance.IsShow)
			UIGameController.sInstance.StartGame();
		else if(UIGameFinalController.sInstance.IsShow)
			UIGameFinalController.sInstance.StartGame();
		//MediaMgr.sInstance.PlaySE(GUI_DEFINE.SE_btn);
	}
}

