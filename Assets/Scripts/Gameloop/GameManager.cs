using Scripts.Infra;
using Scripts.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Gameloop
{
    public class GameManager : MonoBehaviour
    {
        public GameObject FogOfWar;

        [Header("Game Settings")]
        public bool ShowHintPopups;
        public bool EnableFogOfWar;
        public float sessionTime;
        public float timeBonus;


        private float secondsPlayed;

        [SerializeField]
        private TreasureController treasureController;

        [SerializeField]
        private PlayerMovement playerMovement;

        [SerializeField]
        private RoundDataModel roundData;

        [SerializeField]
        private Text roundTimer;

        private int chestCount;
        private int randomChest;
        private int randomChestStore;

        private int RandRetrys = 0;
        private int RandRetrys_max = 100;

        public static GameManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);

            else
                Instance = this;

            Application.targetFrameRate = 120;
        }
        
        void Start()
        {
            SoundManager.Instance.OnStart();
            initSession();
            useGameSettings();
            initRound();
        }
        private void initSession()
        {
            chestCount = treasureController.ChestCount;
            chestPickability.TreasureFound += handleTreasureFound;
            roundData.InitSessionData();
        }
        private void useGameSettings()
        {
            if (FogOfWar != null)
            {
                FogOfWar.SetActive(EnableFogOfWar);
            }
        }
        private void handleTreasureFound()
        {
            GiveTimeBonus();
            roundData.IncreaseTreasuresFound();
            StartCoroutine(waitAndPrepareRound());
        }
        private IEnumerator waitAndPrepareRound()
        {
            //get animation duration ...
            yield return new WaitForSeconds(2f);
            initRound();
        }
        private void initRound()
        {
            chooseRandomChest();
            roundData.ChestIndex = randomChest;
            roundData.IncreaseRoundNumber();
            treasureController.hideAllChests();
            treasureController.ShowRandomChest(roundData.ChestIndex);

            //Derived from game settings
            if (ShowHintPopups)
            {
                PopupSystem.Instance.ShowPopup("Round");
            }
        }

        private void chooseRandomChest()
        {
            if (chestCount < 2)
            {
                Debug.LogError("Cannot run the game with less then 2 chests");
                return;
            }
            //generate random number that is different from the previously generated one
            //replace this with shuffle
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
            //prevent this if
            //if (PopupSystem.Instance.activePopup)                return;

            
            sessionTime -= Time.deltaTime;
            secondsPlayed += Time.deltaTime;
            if (sessionTime < 0)
            {
                sessionTime = 0;
                roundData.StoreSecondsPlayed(secondsPlayed);
                PopupSystem.Instance.ShowPopup("Summary");
            }
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

        public void PauseGame()
        {
            Time.timeScale = 0;
            playerMovement.enabled = false;
            SoundManager.SoundeffectsEnabled(false);
        }
        public void UnPauseGame()
        {
            Time.timeScale = 1;
            playerMovement.enabled = true;
            SoundManager.SoundeffectsEnabled(true);
        }
    }
}