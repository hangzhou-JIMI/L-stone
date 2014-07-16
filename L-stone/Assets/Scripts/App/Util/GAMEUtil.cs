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
		pc = Random.Range(0,3);
		if(pc == self)
			return 0;
		else if(pc > self)
			return 1;
		else
			return -1;
	}
}

