using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundDataModel", menuName = "ScriptableObjects/RoundDataModel")]
public class RoundDataModel : ScriptableObject
{
	public int RoundNumber;
	public int ChestIndex;


	public void IncreaseRoundNumber()
	{
		RoundNumber++;
	}
}
