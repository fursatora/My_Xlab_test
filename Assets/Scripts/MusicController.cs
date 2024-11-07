using UnityEngine;

namespace Golf
{
    public class MusicController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSourceBackground;
        [SerializeField] private AudioSource audioSourceBackgroundLoop;
        public AudioSource audioSourceGameOver;
        [SerializeField] private AudioSource audioSourceAnimalSounds;

        [SerializeField] private AudioClip chickenSound;
        [SerializeField] private AudioClip duckSound;
        [SerializeField] private AudioClip stoneSound;

        [SerializeField] private AudioClip music;
        [SerializeField] private AudioClip musicLoop;
        [SerializeField] private AudioClip musicGameOver;

        public void PlayChickenSound()
        {
            PlayAudioClip(chickenSound, audioSourceAnimalSounds);
        }

        public void PlayDuckSound()
        {
            PlayAudioClip(duckSound, audioSourceAnimalSounds);
        }

        public void PlayStoneSound()
        {
            PlayAudioClip(stoneSound, audioSourceAnimalSounds);
        }

        public void PlayBackgroundMusic()
        {
            double firstStartTime = AudioSettings.dspTime;
            audioSourceBackground.loop = false;
            PlayAudioClip(music, audioSourceBackground, firstStartTime);


            double seconStartTime = AudioSettings.dspTime + music.length;
            audioSourceBackgroundLoop.loop = true;
            PlayAudioClip(musicLoop, audioSourceBackgroundLoop, seconStartTime);
        }

        public void StopSound(AudioSource audioSource)
        {
            audioSource.Stop();
        }

        public void StopBackgroundMusic()
        {
            if (audioSourceBackground.isPlaying)
            {
                audioSourceBackground.Stop();
            }

            if (audioSourceBackgroundLoop.isPlaying)
            {
                audioSourceBackgroundLoop.Stop();
            }
        }
        public void PlayGameoverSound()
        {
            PlayAudioClip(musicGameOver, audioSourceGameOver);
        }

        private void PlayAudioClip(AudioClip clip, AudioSource audioSource)
        {
            if (audioSource != null)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
        }

        private void PlayAudioClip(AudioClip clip, AudioSource audioSource, double startTime)
        {
            if (audioSource != null)
            {
                audioSource.clip = clip;
                audioSource.PlayScheduled(startTime);
            }

        }


    }
}
