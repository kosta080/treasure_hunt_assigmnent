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

        

        void Start()
        {
            chestCount = treasureController.ChestCount;
            chooseRandomChest();
            roundData.IncreaseRoundNumber();
            //PopupSystem.Instance.ShowRoundPopup();
            treasureController.ShowRandomChest(randomChest);
            
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