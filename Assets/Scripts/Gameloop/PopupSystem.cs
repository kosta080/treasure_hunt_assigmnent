using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Gameloop
{
    [Serializable]
    public class popup
    {
        public string Name;
        public GameObject Object;
    }
    public class PopupSystem : MonoBehaviour
	{
        [SerializeField]
        private Transform popupCanvas;

        [SerializeField]
        private List<popup> popups;

        private GameObject roundPopup;

        private GameObject activePopup;

        public static PopupSystem Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);

            else
                Instance = this;
        }

        //make generic function that gets key (editor scripy)
        public void ShowPopup(string popupName)
        {
            if (popups.Count < 1)
            {
                Debug.LogError("there are no popups, please configure popupSystem Game object");
                return;
            }
            for (var i=0;i< popups.Count;i++)
            {
                if (popups[i].Name == popupName)
                {
                    GameManager.Instance.PauseGame();
                    activePopup = Instantiate(popups[i].Object, popupCanvas);
                    return;
                }
            }
            Debug.LogError("no popup with the name "+ popupName + " was found");
        }

        public void CloseActivePopup()
        {
            Debug.Log("CloseActivePopup");
            GameManager.Instance.UnPauseGame();
            Destroy(activePopup);
        }


    }

}
