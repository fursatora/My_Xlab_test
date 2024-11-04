using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        public StoneSpawner stoneSpawner;
        private float m_timer;
        [SerializeField] private float m_delay = 2f;
        [SerializeField] private float  m_destroyDelay = 1f;
        [SerializeField] private float  m_chickenProbabiluty;
        [SerializeField] private int  m_life=3;
        public AudioSource audioSource;
        public AudioClip chickenSound;
        public AudioClip duckSound;



        private uint m_score = 0;
        
        private List<Stone> m_stones = new List<Stone>();
        private List<Chicken> m_chickens = new List<Chicken>();


        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            stick.onCollisionStone += OnCollisionStoneHit;
            stick.onCollisionChicken += OnCollisionChickenHit;
        }

        private void OnDisable()
        {
            if (stick)
            {
                stick.onCollisionStone -= OnCollisionStoneHit;
                stick.onCollisionChicken -= OnCollisionChickenHit;
            }
        }

        private void Update()
        {
            if (Time.time > m_timer + m_delay)
            {
                m_timer = Time.time;

                GameObject go;

                if (UnityEngine.Random.value < m_chickenProbabiluty)
                {
                    go = stoneSpawner.SpawnChicken();
                }
                else
                {
                    go = stoneSpawner.SpawnStone();
                }

                if (go == null) return;

                if (go.GetComponent<Stone>() != null)
                {
                    var stone = go.GetComponent<Stone>();
                    stone.onCollisionStone += OnCollisionStone;
                    m_stones.Add(stone);
                    //Debug.Log($"колво камней: {m_stones.Count}");
                }
                else if (go.GetComponent<Chicken>() != null)
                {
                    var chicken = go.GetComponent<Chicken>();
                    chicken.onCollisionChicken += OnCollisionChicken;
                    m_chickens.Add(chicken);
                }
            }
        }

        private void OnCollisionStoneHit()
        {
            m_score++;
            Debug.Log($"score: {m_score}");
            DestroyAfterDelay.DestroyObjectsInList(m_stones, m_destroyDelay);
        }

        private void OnCollisionChickenHit()
        {
            if (m_life>1){
                m_life--;
                Debug.Log($"life: {m_life}");
            }
            else
            {
                Debug.Log("GAME OVER!!!!");
            }
            DestroyAfterDelay.DestroyObjectsInList(m_chickens, m_destroyDelay);
        }

        private void OnCollisionStone()
        {
            if (m_life>1){
                m_life--;
                Debug.Log($"life: {m_life}");
            }
            else 
            {
                Debug.Log("GAME OVER!!!!");
            }
            DestroyAfterDelay.DestroyObjectsInList(m_stones, m_destroyDelay);
        }

        private void OnCollisionChicken()
        {
            DestroyAfterDelay.DestroyObjectsInList(m_chickens, m_destroyDelay);
        }

        public void PlaySound(AudioClip clip)
        {
            if (audioSource != null && clip != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
