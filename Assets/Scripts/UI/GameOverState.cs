using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        public GameObject rootUI;
        public MainMenuState mainMenuState;
        public GamePlayState gamePlayState;
        public SoundController soundController;
        public MusicController musicController;


        public TextMeshProUGUI currentScoreText;
        public TextMeshProUGUI bestScoreText;

        private void OnEnable()
        {
            rootUI.SetActive(true);

            soundController.PlayGameOverSound();
            musicController.StopBackgroundMusic();
        }

        private void OnDisable()
        {
            if (rootUI)
            {
                rootUI.SetActive(false);
                soundController.StopSound();
            }
        }

        public void SetScore(int currentScore, int bestScore)
        {
            currentScoreText.text = $"Current score: {currentScore}";
            bestScoreText.text = $"Best score: {bestScore}";
        }

        public void Restart()
        {
            gameObject.SetActive(false);
            gamePlayState.gameObject.SetActive(true);

        }

        public void BackToMenu()
        {
            gameObject.SetActive(false);
            mainMenuState.gameObject.SetActive(true);
        }
    }
}
