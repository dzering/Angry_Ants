using UnityEngine;

namespace _Root._Scripts.Logic
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [SerializeField] private AudioSource _enemySource;
        [SerializeField] private AudioSource _backgroundSource;

        [SerializeField] private AudioClip _slapClip;
        [SerializeField] private AudioClip _backgroundClip;
        
        private void Awake()
        {
            if(Instance != null)
                Destroy(gameObject);
            else
            {
                Instance = this;
            }

            _backgroundSource.clip = _backgroundClip;
            PlayBackground();
        }

        private void PlayBackground() => _backgroundSource.Play();
        public void PlaySlap() => 
            _enemySource.PlayOneShot(_slapClip, 0.7f);
    }
}
