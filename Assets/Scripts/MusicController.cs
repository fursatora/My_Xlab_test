using UnityEngine;

namespace Golf
{
    public class MusicController : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play(); 
            }
        }
    }
}
