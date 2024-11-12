using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        public GameObject rootUI;

        public GamePlayState gamePlayState;
        public SettingsState settingsState;
        public InformationState informationState;

        public TextMeshProUGUI scoreText;

        public SoundController soundController;
        public MusicController musicController;

        public Button playBtn;
        public Button settingsBtn;
        public Button informationButton;

        private void OnEnable()
        {
            playBtn.onClick.AddListener(Play);
            settingsBtn.onClick.AddListener(Settings);

            rootUI.SetActive(true);
            soundController.StopSound();
            scoreText.text = $"Best score: {GameInstance.score}";
        }

        private void OnDisable()
        {
            if (rootUI)
            {
                rootUI.SetActive(false);
            }
        }

        public void Play()
        {
            this.gameObject.SetActive(false);
            gamePlayState.gameObject.SetActive(true);
        }

        public void Settings()
        {
            
            this.gameObject.SetActive(false);
            settingsState.gameObject.SetActive(true); 
        }

        public void Information()
        {
            this.gameObject.SetActive(false);
            informationState.gameObject.SetActive(true); 
        }


    }
}
