using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Golf
{
    public class InformationState : MonoBehaviour
    {
        public GameObject rootUI;
        public MainMenuState mainMenuState;

        private void OnEnable()
        {
            rootUI.SetActive(true);
        }

        private void OnDisable()
        {
            if (rootUI)
            {
                rootUI.SetActive(false);
            }
        }

        public void BackToMenu()
        {
            gameObject.SetActive(false);
            mainMenuState.gameObject.SetActive(true);
        }
    }
}
