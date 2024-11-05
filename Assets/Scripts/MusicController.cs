using UnityEngine;

namespace Golf
{
    public class MusicController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSourceBackground;
        [SerializeField] private AudioSource audioSourceAnimalSounds;

        [SerializeField] private AudioClip chickenSound;
        [SerializeField] private AudioClip duckSound;
        [SerializeField] private AudioClip music;

        private void Awake()
        {
            audioSourceBackground = GetComponent<AudioSource>();
            audioSourceAnimalSounds = GetComponent<AudioSource>();

        }

        public void PlayChickenSound()
        {
            PlayAudioClip(chickenSound,audioSourceAnimalSounds);
        }

        public void PlayDuckSound()
        {
            PlayAudioClip(duckSound,audioSourceAnimalSounds);
        }

        public void PlayBackgroundMusic()
        {
            PlayAudioClip(music,audioSourceBackground);
        }

        private void PlayAudioClip(AudioClip clip, AudioSource audioSource)
        {
            if (audioSource != null)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}
