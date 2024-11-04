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
                    Debug.Log($"колво камней: {m_stones.Count}");
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

            for (int i = m_stones.Count - 1; i >= 0; i--)
            {
                var stone = m_stones[i];
                DestroyAfterDelay.DestroyObject<Stone>(stone.gameObject, m_destroyDelay, m_stones);
            }
        }

        private void OnCollisionChickenHit()
        {
            m_score--;
            Debug.Log($"score: {m_score}");

            for (int i = m_chickens.Count - 1; i >= 0; i--)
            {
                var chicken = m_chickens[i];
                DestroyAfterDelay.DestroyObject<Chicken>(chicken.gameObject, m_destroyDelay, m_chickens);
            }
        }

        private void OnCollisionStone()
        {
            Debug.Log("GAME OVER!!!!");
            for (int i = m_stones.Count - 1; i >= 0; i--)
            {
                var stone = m_stones[i];
                DestroyAfterDelay.DestroyObject<Stone>(stone.gameObject, m_destroyDelay, m_stones);
            }
        }

        private void OnCollisionChicken()
        {
            for (int i = m_chickens.Count - 1; i >= 0; i--)
            {
                var chicken = m_chickens[i];
                DestroyAfterDelay.DestroyObject<Chicken>(chicken.gameObject, m_destroyDelay, m_chickens);
            }

        }
    }
}
