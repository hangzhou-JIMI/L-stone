using UnityEngine;
using System;
using System.Collections;

//	CApplication.cs
//	Author: Lu Zexi
//	2014-07-16


/// <summary>
/// windows Application.
/// </summary>
public class CApplication : MonoBehaviour
{
	void Awake()
	{
		//
	}

	// Use this for initialization
	void Start ()
	{
		CScene.Switch<TittleScene>();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnApplicationPause(bool pause)
	{
		if(pause)
		{
			NotificationServices.CancelAllLocalNotifications();
			int randLevel = GameData.s_iLevel + UnityEngine.Random.Range(1,20);
			PushMsg.sInstance.PushLocalMsg(DateTime.Now.AddDays(1),"萌呆,你的小伙伴已经"+randLevel+"层了，快来继续攀登高峰");
			PushMsg.sInstance.PushLocalMsg(DateTime.Now.AddDays(3),"Hello,你在干嘛呢?");
			PushMsg.sInstance.PushLocalMsg(DateTime.Now.AddDays(7),"萌呆,"+GameData.s_iLevel+"层是你的极限了吗?");
			PushMsg.sInstance.PushLocalMsg(DateTime.Now.AddMonths(1),"我被你遗弃了 T_T");
		}
	}
}

