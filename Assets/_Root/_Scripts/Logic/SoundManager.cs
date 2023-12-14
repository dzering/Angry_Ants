using UnityEngine;

namespace _Root._Scripts.Logic
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
        
        public AudioSource enemySource;
        public AudioSource backgroundSource;

        public AudioClip slapClip;
        public AudioClip backgroundClip;
        
        private void Awake()
        {
            if(instance != null)
                Destroy(gameObject);
            else
            {
                instance = this;
            }

            backgroundSource.clip = backgroundClip;
            PlayBackground();
        }

        private void PlayBackground() => backgroundSource.Play();
        public void PlaySlap() => 
            enemySource.PlayOneShot(slapClip, 0.7f);
    }
}
