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

        public Button playBtn;

        private void OnEnable()
        {
            playBtn.onClick.AddListener(Play);
            mainmenuUI.SetActive(true);
            musicController.StopSound(musicController.audioSourceGameOver);
            scoreText.text = $"TOP SCORE: {GameInstance.score}";
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




    }
}
