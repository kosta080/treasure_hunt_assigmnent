using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Gameloop
{
    public class treasureController : MonoBehaviour
    {
        private List<Transform> treasureChests = new List<Transform>();

        private int randomChest;
        private int randomChestStore;

        public void ShowRandomChest()
        {
            hideAllChests();
            showRandomChest();
        }
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
        private void showRandomChest()
        {
            //generate random number that is different from the previously generated one
            while (randomChestStore == randomChest)
            {
                randomChest = Random.Range(0, treasureChests.Count);
            }
            randomChestStore = randomChest;

            treasureChests[randomChest].gameObject.SetActive(true);
        }
    }
}