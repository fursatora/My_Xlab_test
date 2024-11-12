using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class SettingsState : MonoBehaviour
    {
        public GameObject rootUI;
        public MainMenuState mainMenuState;

        public List<Sprite> soundVolumeSprites;
        public List<Sprite> musicVolumeSprites;
        public Image soundVolumeImage;
        public Image musicVolumeImage;

        public Button soundDecreaseButton;
        public Button soundIncreaseButton;
        public Button musicDecreaseButton;
        public Button musicIncreaseButton;

        public Button muteButton;
        public Sprite muteOnSprite; 
        public Sprite muteOffSprite; 

        public SoundController soundController;
        public MusicController musicController;

        public Button menuBtn;

        private bool isMuted = false; 
        private int soundVolumeIndex = 2; 
        private int musicVolumeIndex = 2; 

        private void Start()
        {
            UpdateSoundVolume();
            UpdateMusicVolume();
            UpdateMuteButton();

            soundDecreaseButton.onClick.AddListener(DecreaseSoundVolume);
            soundIncreaseButton.onClick.AddListener(IncreaseSoundVolume);
            musicDecreaseButton.onClick.AddListener(DecreaseMusicVolume);
            musicIncreaseButton.onClick.AddListener(IncreaseMusicVolume);
            muteButton.onClick.AddListener(ToggleMute);
            menuBtn.onClick.AddListener(BackToMenu);
        }

        private void OnEnable()
        {
            rootUI.SetActive(true);
            UpdateMuteButton(); 
        }

        private void OnDisable()
        {
            rootUI.SetActive(false);
        }

        public void BackToMenu()
        {
            gameObject.SetActive(false);
            mainMenuState.gameObject.SetActive(true);
        }

        private void DecreaseSoundVolume()
        {
            if (isMuted || soundVolumeIndex <= 0) return;

            soundVolumeIndex--;
            UpdateSoundVolume();
        }

        private void IncreaseSoundVolume()
        {
            if (isMuted || soundVolumeIndex >= soundVolumeSprites.Count - 1) return;

            soundVolumeIndex++;
            UpdateSoundVolume();
        }

        private void DecreaseMusicVolume()
        {
            if (isMuted || musicVolumeIndex <= 0) return;

            musicVolumeIndex--;
            UpdateMusicVolume();
        }

        private void IncreaseMusicVolume()
        {
            if (isMuted || musicVolumeIndex >= musicVolumeSprites.Count - 1) return;

            musicVolumeIndex++;
            UpdateMusicVolume();
        }

        private void UpdateSoundVolume()
        {
            soundVolumeImage.sprite = soundVolumeSprites[soundVolumeIndex];
            if (!isMuted)
            {
                soundController.SetVolume(soundVolumeIndex); 
            }
        }

        private void UpdateMusicVolume()
        {
            musicVolumeImage.sprite = musicVolumeSprites[musicVolumeIndex];
            if (!isMuted)
            {
                musicController.SetVolume(musicVolumeIndex);
            }
        }

        private void ToggleMute()
        {
            isMuted = !isMuted;

            soundController.gameObject.SetActive(!isMuted);
            musicController.gameObject.SetActive(!isMuted);

            UpdateMuteButton();

            soundDecreaseButton.interactable = !isMuted;
            soundIncreaseButton.interactable = !isMuted;
            musicDecreaseButton.interactable = !isMuted;
            musicIncreaseButton.interactable = !isMuted;

            if (isMuted)
            {
                soundVolumeImage.sprite = soundVolumeSprites[0];
                musicVolumeImage.sprite = musicVolumeSprites[0];
            }
            else
            {
                UpdateSoundVolume();
                UpdateMusicVolume();
            }
        }

        private void UpdateMuteButton()
        {
            muteButton.image.sprite = isMuted ? muteOffSprite : muteOnSprite;
        }
    }
}
