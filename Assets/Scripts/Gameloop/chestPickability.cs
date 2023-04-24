using UnityEngine;

namespace Scripts.Gameloop
{ 
	public class chestPickability : MonoBehaviour
	{
		private void OnTriggerEnter(Collider collider)
		{
			if (collider.transform.tag == "Player")
			{
				transform.GetComponent<Animator>().SetTrigger("open");

			}
		}
	}
}