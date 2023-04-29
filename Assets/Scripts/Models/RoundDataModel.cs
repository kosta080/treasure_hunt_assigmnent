using System;
using UnityEngine;

namespace Scripts.Data
{
	[CreateAssetMenu(fileName = "RoundDataModel", menuName = "ScriptableObjects/RoundDataModel")]
	public class RoundDataModel : ScriptableObject
	{

		public int ChestIndex;

		[SerializeField]
		private int treasuresFound;

		[SerializeField]
		private int roundNumber;

		[SerializeField]
		private int secondsPlayed;
		public void InitSessionData()
		{
			roundNumber = 0;
			treasuresFound = 0;
			secondsPlayed = 0;
		}
		public void IncreaseRoundNumber()
		{
			roundNumber++;
		}
		public void IncreaseTreasuresFound()
		{
			treasuresFound++;
		}
		public void StoreSecondsPlayed(float seconds)
		{
			secondsPlayed = (int)MathF.Floor(seconds);
		}

		public int SecondsPlayed => secondsPlayed;
		public int RoundNumber => roundNumber;
		public int TreasuresFound => treasuresFound;

	}
}
