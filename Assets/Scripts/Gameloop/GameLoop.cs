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
        private float roundTime;

        public GameObject FogOfWar;

        [Header("Game Settings")]
        public bool ShowHintPopups;
        public bool EnableFogOfWar;

        void Start()
        {
            //Session preperation
            chestCount = treasureController.ChestCount;
            chestPickability.TreasureFound += prepareRound;
            roundData.RoundNumber = 0;

            //Impliment game settings
            if (FogOfWar!=null)
            {
                FogOfWar.SetActive(EnableFogOfWar);
            }
            
            //Round Preperation
            prepareRound();
        }

        private void prepareRound()
        {
            chooseRandomChest();
            roundData.IncreaseRoundNumber();
            treasureController.hideAllChests();
            treasureController.ShowRandomChest(randomChest);

            //Derived from game settings
            if (ShowHintPopups)
            {
                PopupSystem.Instance.ShowRoundPopup();
            }
        }

        private void chooseRandomChest()
        {
            //generate random number that is different from the previously generated one
            while (randomChestStore == randomChest)
            {
                randomChest = Random.Range(0, chestCount);
            }
            randomChestStore = randomChest;
        }

		private void Update()
		{
            //timer should not run if popup is showing or if round did not start yet
            if (PopupSystem.Instance.activePopup)
                return;
            
            roundTime += Time.deltaTime;
            int seconds = (int)roundTime % 60;

            if (roundTimer)
            {
                roundTimer.text = seconds.ToString();
            }

        }
	}
}