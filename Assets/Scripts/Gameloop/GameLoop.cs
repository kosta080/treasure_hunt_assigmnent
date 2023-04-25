using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Gameloop
{
    public class GameLoop : MonoBehaviour
    {
        [SerializeField]
        private TreasureController treasureController;

        [SerializeField]
        private RoundDataModel roundData;

        [SerializeField]
        private Text roundTimer;

        private int chestCount;
        private int randomChest;
        private int randomChestStore;
        

        public GameObject FogOfWar;

        [Header("Game Settings")]
        public bool ShowHintPopups;
        public bool EnableFogOfWar;
        public float sessionTime;
        public float timeBonus;

        void Start()
        {
           
            //Session preperation
            chestCount = treasureController.ChestCount;
            chestPickability.TreasureFound += handleTreasureFound;
            roundData.RoundNumber = 0;

            //Impliment game settings
            if (FogOfWar!=null)
            {
                FogOfWar.SetActive(EnableFogOfWar);
            }
            
            //Round Preperation
            prepareRound();
        }
        private void handleTreasureFound()
        {
            GiveTimeBonus();
            StartCoroutine(waitAndPrepareRound());
        }
        private IEnumerator waitAndPrepareRound()
        {
            yield return new WaitForSeconds(2f);
            prepareRound();
        }
        private void prepareRound()
        {
            chooseRandomChest();
            roundData.ChestIndex = randomChest;
            roundData.IncreaseRoundNumber();
            treasureController.hideAllChests();
            treasureController.ShowRandomChest(roundData.ChestIndex);

            //Derived from game settings
            if (ShowHintPopups)
            {
                PopupSystem.Instance.ShowRoundPopup();
            }
        }

        int RandRetrys = 0;
        int RandRetrys_max = 100;
        private void chooseRandomChest()
        {
            if (chestCount < 2)
            {
                Debug.LogError("Cannot run the game with less then 2 chests");
                return;
            }
            //generate random number that is different from the previously generated one
            RandRetrys = 0;
            while (randomChestStore == randomChest && RandRetrys < RandRetrys_max)
            {
                randomChest = Random.Range(0, chestCount);
                RandRetrys++;
            }
            randomChestStore = randomChest;
        }

		private void Update()
		{
            //timer should not run if popup is showing or if round did not start yet
            if (PopupSystem.Instance.activePopup)
                return;

            sessionTime -= Time.deltaTime;
            int minutes = (int)Mathf.Floor(sessionTime / 60);
            int seconds = (int)sessionTime % 60;
            int totalSeconds = (int)Mathf.Floor(sessionTime);

            if (roundTimer)
            {
                roundTimer.text = totalSeconds.ToString();
            }
        }
        private void GiveTimeBonus()
        {
            sessionTime += timeBonus;
        }
	}
}