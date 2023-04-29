using Scripts.Gameloop;
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
        public AudioClip uiClick;

        public static AudioSource[] allAudioSources;
        public static SoundManager Instance { get; private set; }

        [SerializeField]
        private GameObject sfx;

        public void OnStart()
        {
            musicAudioSource.clip = music;
            musicAudioSource.Play();
            
            chestPickability.TreasureFound += playCollectSound;

            allAudioSources = FindObjectsOfType<AudioSource>();
            Debug.Log(allAudioSources.Length + " AudioSource found in snene");
        }

        public void playUiClick()
        {
            createAndPlaySound(uiClick);
        }

        public static void SoundeffectsEnabled(bool state)
        {
            foreach (AudioSource audios in allAudioSources)
            {
                if (audios.transform.tag == "Music")
                {
                    //Debug.Log("<color=yellow> ignoring "+ audios.transform.name + "</color>");
                    return;
                }
                //Debug.Log("<color=green> setting " + audios.transform.name +" - "+ state + "</color>");
                audios.enabled = state;
            }
        }
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);

            else
                Instance = this;
        }
		private void playCollectSound()
        {
            createAndPlaySound(chestOpening);
        }
        private void createAndPlaySound(AudioClip clip)
        {
            GameObject sfxGo = Instantiate(sfx, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
            AudioSource _audios = sfxGo.GetComponent<AudioSource>();
            _audios.clip = clip;
            _audios.Play();
            Destroy(_audios, clip.length);
        }
    }
}