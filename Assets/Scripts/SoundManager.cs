using Scripts.Gameloop;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infra
{
    public class SoundManager : MonoBehaviour
    {
        [Header("Audio sources")]
        public AudioSource musicAudioSource;
        public AudioSource soundeffectsAudioSource;

        [Header("Audio clips")]
        public AudioClip music;
        public AudioClip chestOpening;

        //private chestPickability _chestPickability;
        void Start()
        {
            musicAudioSource.PlayOneShot(music);
            chestPickability.TreasureFound += playCollectSound;
        }

        private void playCollectSound()
        {
            soundeffectsAudioSource.PlayOneShot(chestOpening);
        }
    }
}