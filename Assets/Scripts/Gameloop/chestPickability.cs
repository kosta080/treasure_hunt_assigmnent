using System;
using UnityEngine;

namespace Scripts.Gameloop
{ 
	public class chestPickability : MonoBehaviour
	{

		public static event Action TreasureFound;

		private void OnTriggerEnter(Collider collider)
		{
			if (collider.transform.tag == "Player")
			{
				transform.GetComponent<Animator>().SetTrigger("open");
				TreasureFound?.Invoke();
			}
		}
	}
}