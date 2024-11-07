using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        public GameObject rootUI;
        public MainMenuState mainMenuState;
        public GamePlayState gamePlayState;
        public MusicController musicController;

        private void OnEnable()
        {
            rootUI.SetActive(true);
            musicController.PlayGameoverSound();

        }

        private void OnDisable()
        {
            if (rootUI)
            {
                rootUI.SetActive(false);

            }
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
