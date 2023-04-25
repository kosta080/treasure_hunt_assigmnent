using Scripts.Gameloop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infra
{
    public class SoundManager : MonoBehaviour
    {
        //private chestPickability _chestPickability;
        void Start()
        {
            
            //Debug.Log(GameObject.FindObjectsOfType<chestPickability>().Length);
            //Debug.Log(GameObject.FindObjectsOfType<chestPickability>());
            //_chestPickability = GameObject.FindObjectsOfType<chestPickability>()[0];
            chestPickability.TreasureFound += playCollectSound;
        }

        private void playCollectSound()
        {
            Debug.Log("hu playCollectSound ");
        }
    }
}