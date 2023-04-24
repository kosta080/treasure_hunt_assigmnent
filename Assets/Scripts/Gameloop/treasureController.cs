using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameloop
{
    public class TreasureController : MonoBehaviour
    {
        private List<Transform> treasureChests = new List<Transform>();

        
        private void Start()
        {
            foreach (Transform childObject in transform)
            {
                if (childObject.GetComponent<chestPickability>())
                {
                    treasureChests.Add(childObject);
                    childObject.gameObject.SetActive(false);
                }
            }
            hideAllChests();
        }

        private void hideAllChests()
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