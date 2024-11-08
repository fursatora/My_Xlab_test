using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        public GameObject mainmenuUI;
        public GamePlayState gamePlayState;
        public TextMeshProUGUI scoreText;
        public MusicController musicController;

        
        public Button musicOnButton;  // Кнопка включения музыки
        public Button musicOffButton; // Кнопка выключения музыки
 
        public Button playBtn;

        private void OnEnable()
        {
            playBtn.onClick.AddListener(Play);

            musicOnButton.onClick.AddListener(SoundOn);
            musicOffButton.onClick.AddListener(SoundOff);
        
            mainmenuUI.SetActive(true);
            musicController.StopSound(musicController.audioSourceGameOver);
            scoreText.text = $"Best score: {GameInstance.score}";
        }

        private void OnDisable()
        {
            if (mainmenuUI)
            {
                mainmenuUI.SetActive(false);
            }

        }

        public void Play()
        {
            this.gameObject.SetActive(false);
            gamePlayState.gameObject.SetActive(true);
        }

        public void SoundOn()
        {
                musicController.gameObject.SetActive(true);
                musicOnButton.gameObject.SetActive(false);
                musicOffButton.gameObject.SetActive(true);
        }

        public void SoundOff()
        {
                musicController.gameObject.SetActive(false);
                musicOffButton.gameObject.SetActive(false);
                musicOnButton.gameObject.SetActive(true);
        }





    }
}
