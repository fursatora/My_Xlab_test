using UnityEngine;

namespace Golf
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSourceSounds;

        [SerializeField] private AudioClip chickenSound;
        [SerializeField] private AudioClip duckSound;
        [SerializeField] private AudioClip stoneSound;
        [SerializeField] private AudioClip gameOverSound;

        private bool isMuted = false; 
        private float currentVolume = 1f; 

        private void Start()
        {
            audioSourceSounds.volume = currentVolume;
        }

        public void PlayChickenSound() => PlaySound(chickenSound);
        public void PlayDuckSound() => PlaySound(duckSound);
        public void PlayStoneSound() => PlaySound(stoneSound);
        public void PlayGameOverSound() => PlaySound(gameOverSound);

        private void PlaySound(AudioClip clip)
        {
            if (isMuted || clip == null) return;

            if (audioSourceSounds.isPlaying)
                audioSourceSounds.Stop();

            audioSourceSounds.clip = clip;
            audioSourceSounds.Play();
        }

        public void StopSound()
        {
            audioSourceSounds.Stop();
            audioSourceSounds.clip = null;
        }

        public void ToggleMute()
        {
            isMuted = !isMuted;
            audioSourceSounds.mute = isMuted;
        }

        public void SetVolume(int volumeIndex)
        {
            volumeIndex = Mathf.Clamp(volumeIndex, 0, 5);

            float[] volumeLevels = { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f };

            currentVolume = volumeLevels[volumeIndex];
            audioSourceSounds.volume = currentVolume;
        }
    }
}
