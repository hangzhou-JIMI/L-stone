using UnityEngine;
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
}

