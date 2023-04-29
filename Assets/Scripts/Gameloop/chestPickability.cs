using System;
using UnityEngine;

namespace Scripts.Gameloop
{ 
	public class chestPickability : MonoBehaviour
	{

		public static event Action TreasureFound;
		[SerializeField]
		private ParticleSystem glowParticles;


		private void OnTriggerEnter(Collider collider)
		{
			if (collider.transform.tag == "Player")
			{
				glowParticles.Emit(40);
				transform.GetComponent<Animator>().SetTrigger("open");
				TreasureFound?.Invoke();
			}
		}
	}
}