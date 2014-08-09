using UnityEngine;
using System.Collections;


//	GAMEAlgorithm.cs
//	Author: Lu Zexi
//	2014-07-16



/// <summary>
/// GAME algorithm.
/// </summary>
public class GAMEUtil
{
	/// <summary>
	/// Calculate the specified level, self and pc.
	/// </summary>
	/// <param name="level">Level.</param>
	/// <param name="self">Self.</param>
	/// <param name="pc">Pc.</param>
	public static int StoneCalculate(int level , out int self , out int pc )
	{
		self = Random.Range(0,3);
		pc = self;
		float winRate = 0.5f-(CubicIn(level/100f,0,1,1)>1f?1f:CubicIn(level/100f,0,1,1))*0.2f;
		float pingRate = (1-winRate)-0.25f;
		Debug.Log(pingRate + " - " + winRate);
		int result = BET( pingRate , winRate );
		switch( result )
		{
		case 1: //win
			pc = (self + 1 )%3;
			break;
		case 0:	//ping
			pc = self;
			break;
		case -1://lose
			pc = self - 1 < 0? 2 : self - 1;
			break;
		}
		return result;
	}

	public static int StoneCalculateEx(int level , out int self , out int pc )
	{
		self = Random.Range(0,3);
		pc = self;
		float winRate = 0.5f-(CubicIn(level/100f,0,1,1)>1f?1f:CubicIn(level/100f,0,1,1))*0.1f;
		float pingRate = (1-winRate)-0.1f;
		Debug.Log(pingRate + " - " + winRate);
		int result = BET( pingRate , winRate );
		switch( result )
		{
		case 1: //win
			pc = (self + 1 )%3;
			break;
		case 0:	//ping
			pc = self;
			break;
		case -1://lose
			pc = self - 1 < 0? 2 : self - 1;
			break;
		}
		return result;
	}

	/// <summary>
	/// 三次方内曲线
	/// </summary>
	/// <param name="t">初始值与最大值之间的值</param>
	/// <param name="b">初始值</param>
	/// <param name="c">初始值与最大值间隔</param>
	/// <param name="d">最大值</param>
	/// <returns></returns>
	public static float CubicIn(float t, float b, float c, float d)
	{
		return c * (t /= d) * t * t + b;
	}

	/// <summary>
	/// 由概率集得到1次随机落在何处
	/// </summary>
	/// <param name="perLst"></param>
	/// <returns></returns>
	public static int BET(params float[] perLst)
	{
		return RANDOM_BET(1, perLst)[0];
	}
	
	/// <summary>
	/// 由指定概率集得到N次随机落在何处
	/// </summary>
	/// <param name="num"></param>
	/// <param name="perLst"></param>
	/// <returns></returns>
	public static int[] BET(int num, params float[] perLst)
	{
		return RANDOM_BET(num, perLst);
	}
	
	/// <summary>
	/// 由指定概率集得到N次随机落在何处
	/// </summary>
	/// <param name="num"></param>
	/// <param name="perLst"></param>
	/// <returns></returns>
	public static int[] RANDOM_BET(int num, float[] perLst)
	{
		if (perLst == null || num <= 0)
			return null;
		
		int typeNum = perLst.Length;
		int[] selectPos = new int[num];
		float[] vecRandom = new float[num];
		
		for (int i = 0; i < num; i++)
		{
			selectPos[i] = -1;
			vecRandom[i] = RANDOM_ONE();
		}
		
		for (int i = 0; i < num; i++)
		{
			float sumPos = 0;
			for (int j = RANDOM(0,typeNum) , k = 0; k < perLst.Length; k++, j++)
			{
				sumPos += perLst[j % typeNum];
				//Debug.Log("sum + " + sumPos + " -- " + perLst[j % typeNum] + " -- " + vecRandom[i]);
				if (sumPos >= vecRandom[i])
				{
					selectPos[i] = j % typeNum;
					break;
				}
			}
			
		}
		
		return selectPos;
	}

	/// <summary>
	/// 随机圆内点
	/// </summary>
	/// <returns></returns>
	public static Vector2 RANDOM_IN_CIRCLE()
	{
		return UnityEngine.Random.insideUnitCircle;
	}
	
	/// <summary>
	/// 随机球内点
	/// </summary>
	/// <returns></returns>
	public static Vector3 RANDOM_IN_SPHERE()
	{
		return UnityEngine.Random.insideUnitSphere;
	}
	
	/// <summary>
	/// 随机球上点
	/// </summary>
	/// <returns></returns>
	public static Vector3 RANDOM_ON_SPHERE()
	{
		return UnityEngine.Random.onUnitSphere;
	}
	
	/// <summary>
	/// 随机0-1浮点数
	/// </summary>
	/// <returns></returns>
	public static float RANDOM_ONE()
	{
		return RANDOM(0f, 1f);
	}
	
	/// <summary>
	/// 随机范围内浮点数
	/// </summary>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns></returns>
	public static float RANDOM(float min, float max)
	{
		return UnityEngine.Random.Range(min, max);
	}
	
	/// <summary>
	/// 随机范围内整数
	/// </summary>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns></returns>
	public static int RANDOM(int min, int max)
	{
		return UnityEngine.Random.Range(min, max);
	}
}

