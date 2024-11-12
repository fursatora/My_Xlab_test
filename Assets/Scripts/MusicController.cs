using UnityEngine;
using System.Collections;

namespace Golf
{
    public class MusicController : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSourceBackground;
        [SerializeField] private AudioClip introMusic;
        [SerializeField] private AudioClip loopMusic;

        private Coroutine switchToLoopCoroutine;
        private bool isMuted = false;
        private float currentVolume = 1f; 

        private void Start()
        {
            audioSourceBackground.volume = currentVolume;
        }

   
        public void PlayBackgroundMusic()
        {
            if (isMuted || !gameObject.activeInHierarchy || !audioSourceBackground.isActiveAndEnabled) return;

            audioSourceBackground.loop = false; 
            audioSourceBackground.clip = introMusic;
            audioSourceBackground.Play();

            switchToLoopCoroutine = StartCoroutine(SwitchToLoop());
        }

        private IEnumerator SwitchToLoop()
        {
            yield return new WaitForSeconds(introMusic.length);

            audioSourceBackground.clip = loopMusic;
            audioSourceBackground.loop = true;
            audioSourceBackground.Play();
        }

        public void StopBackgroundMusic()
        {
            if (switchToLoopCoroutine != null)
            {
                StopCoroutine(switchToLoopCoroutine);
                switchToLoopCoroutine = null;
            }

            if (audioSourceBackground.isPlaying)
            {
                audioSourceBackground.Stop();
                audioSourceBackground.clip = null;
            }
        }

        public void PlayMusic()
        {
            if (!isMuted)
            {
                PlayBackgroundMusic();
            }
        }

        public void StopMusic()
        {
            StopBackgroundMusic();
        }

        public void SetVolume(int volumeIndex)
        {
            volumeIndex = Mathf.Clamp(volumeIndex, 0, 5);

            float[] volumeLevels = { 0f, 0.2f, 0.4f, 0.6f, 0.8f, 1f };
            currentVolume = volumeLevels[volumeIndex];

            if (!isMuted)
                audioSourceBackground.volume = currentVolume; 
        }

        public void ToggleMute()
        {
            isMuted = !isMuted;

            if (isMuted)
            {
                audioSourceBackground.volume = 0; 
            }
            else
            {
                audioSourceBackground.volume = currentVolume; 
            }
        }
    }
}
