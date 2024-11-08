using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Golf
{
    public class GamePlayState : MonoBehaviour
    {
        public GameOverState gameOverState;
        public GameObject rootUI;
        public PlayerController playerController;
        public MusicController musicController;
        public LevelController levelController;
        public TextMeshProUGUI scoreText;

        public List<GameObject> hearts;

        private void OnEnable()
        {
            rootUI.SetActive(true);
            playerController.enabled = true;
            levelController.enabled = true;
            musicController.PlayBackgroundMusic();
            musicController.StopSound(musicController.audioSourceGameOver);

            levelController.onGameOver += OnGameOver;
            levelController.onScoreInc += OnScoreInc;
            levelController.onLifeLost += UpdateHeartsUI;

            OnScoreInc(0);
            ResetHeartsUI();
        }

        private void OnDisable()
        {
            if (rootUI)
            {
                rootUI.SetActive(false);
            }

            if (playerController)
            {
                playerController.enabled = false;
                levelController.musicController.StopBackgroundMusic();
            }

            if (levelController)
            {
                levelController.enabled = false;
                levelController.onGameOver -= OnGameOver;
                levelController.onScoreInc -= OnScoreInc;
                levelController.onLifeLost -= UpdateHeartsUI;
            }
        }

        private void OnScoreInc(int score)
        {
            scoreText.text = $"SCORE: {score}";
        }

        private void OnGameOver(int score)
        {
            int bestScore = Mathf.Max(GameInstance.score, score);
            GameInstance.score = bestScore;

            GameInstance.score = Mathf.Max(GameInstance.score, score);
            gameObject.SetActive(false);

            gameOverState.SetScore(score, bestScore);
            
            gameOverState.gameObject.SetActive(true);
        }

        private void ResetHeartsUI()
        {
            foreach (var heart in hearts)
            {
                heart.gameObject.SetActive(true);
            }
        }

        private void UpdateHeartsUI(int life)
        {
            if (life >= 0 && life < hearts.Count)
            {
                hearts[life].gameObject.SetActive(false);

            }
        }
    }
}
