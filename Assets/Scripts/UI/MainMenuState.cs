using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class MainMenuState : MonoBehaviour
    {
        public GamePlayState gamePlayState;
        public TMPro.TextMeshPro scoreText;
        public TextMeshProUGUI ScoreText;

        public void Play()
        {
            this.gameObject.SetActive(false);
           //gamePlayState.Play();
        }
        
        void OnEnable()
        {
           // scoreText.text = GameInstance.score.ToString();
        }

        void OnDisable()
        {
            
        }
    }
}
