using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameloop
{
    public class TreasureController : MonoBehaviour
    {
        private List<Transform> treasureChests = new List<Transform>();

        
        private void Awake()
        {
            Debug.Log("Treasure controller");
            foreach (Transform childObject in transform)
            {
                if (childObject.GetComponent<chestPickability>())
                {
                    treasureChests.Add(childObject);
                    childObject.gameObject.SetActive(false);
                }
            }
        }

        public void hideAllChests()
        {
            for (int i = 0; i < treasureChests.Count; i++)
            {
                treasureChests[i].gameObject.SetActive(false);
            }
        }
        public void ShowRandomChest(int randomChest)
        {
            treasureChests[randomChest].gameObject.SetActive(true);
        }

        public int ChestCount => treasureChests.Count;
    }
}