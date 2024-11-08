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
        public MusicController musicController;
        private float m_timer;
        [SerializeField] private static float m_delay = 2f;
        [SerializeField] private float m_minDelay = 0.5f;  
        [SerializeField] private float m_delayDecreaseRate = 0.01f; 
     

        [SerializeField] private float m_destroyDelay = 1f;
        [SerializeField] private float m_chickenProbabiluty; 

        public event Action<int> onGameOver;
        public event Action<int> onScoreInc;
        public event Action<int> onLifeLost;
        




        private int m_score = 0;
        private int m_life = 100;
        private float m_initialDelay=m_delay;

        private List<Stone> m_stones = new List<Stone>();
        private List<Chicken> m_chickens = new List<Chicken>();


    
        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            stick.onCollisionStone += OnCollisionStoneHit;
            stick.onCollisionChicken += OnCollisionChickenHit;

            m_score =0;
            m_life=3;
            m_delay=m_initialDelay;
            ClearStones();
        }

        public void OnDisable()
        {
            if (stick)
            {
                stick.onCollisionStone -= OnCollisionStoneHit;
                stick.onCollisionChicken -= OnCollisionChickenHit;
            }
        }

        private void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone.gameObject);
            }
            m_stones.Clear();

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
                if (m_delay > m_minDelay)
                {
                    m_delay -= m_delayDecreaseRate;
                }                
            }
        }

        private void OnCollisionStoneHit()
        {
           
            m_score++;
            Debug.Log($"score: {m_score}");
            onScoreInc?.Invoke(m_score);
            
           
            musicController.PlayStoneSound();
            DestroyAfterDelay.DestroyObjectsInList(m_stones, m_destroyDelay);
        }

        private void OnCollisionChickenHit()
        {
            if (m_life > 1)
            {
                 m_life--;
                Debug.Log($"life: {m_life}");
                onLifeLost?.Invoke(m_life);
                
            }
            else 
            {
                Debug.Log("GAME OVER!!!!");
                onGameOver?.Invoke(m_score);
            }
            if (UnityEngine.Random.value < 0.5f)
            {
                musicController.PlayChickenSound();
            }
            else
            {
                musicController.PlayDuckSound();
            }
            DestroyAfterDelay.DestroyObjectsInList(m_chickens, 0.1f);
        }

        private void OnCollisionStone()
        {
            if (m_life > 1)
            {
                m_life--;
                Debug.Log($"life: {m_life}");
                onLifeLost?.Invoke(m_life);
            }
            else
            {
                Debug.Log("GAME OVER!!!!");
                onGameOver?.Invoke(m_score);
            }
            DestroyAfterDelay.DestroyObjectsInList(m_stones, 0.5f*m_destroyDelay);
        }

        private void OnCollisionChicken()
        {
            DestroyAfterDelay.DestroyObjectsInList(m_chickens, m_destroyDelay);
        }
    }
}
