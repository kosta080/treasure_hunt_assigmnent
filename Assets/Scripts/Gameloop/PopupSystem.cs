using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.Gameloop
{ 
	public class PopupSystem : MonoBehaviour
	{
        [SerializeField]
        private Transform popupCanvas;

        [SerializeField]
        private Object roundPopup;

        public GameObject activePopup;

        public static PopupSystem Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);

            else
                Instance = this;
        }

        public void ShowRoundPopup()
        {
            
            activePopup = (GameObject)Instantiate(roundPopup, popupCanvas);
        }
        public void CloseActivePopup()
        {
            Destroy(activePopup);
        }


    }
}
