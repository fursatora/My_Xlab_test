using System;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        public StoneSpawner stoneSpawner;
        public SoundController soundController;
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
        private int m_life = 3;
        private float m_initialDelay = m_delay;

        private List<Stone> m_stones = new List<Stone>();
        private List<Chicken> m_chickens = new List<Chicken>();

        private bool isGameOver = false;  // Флаг состояния игры

        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            stick.onCollisionStone += OnCollisionStoneHit;
            stick.onCollisionChicken += OnCollisionChickenHit;

            m_score = 0;
            m_life = 3;
            m_delay = m_initialDelay;
            isGameOver = false;  // Сброс состояния игры
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
            if (isGameOver) return;  // Прекращаем обновление, если игра окончена

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
            if (isGameOver) return;  // Проверяем состояние игры

            m_score++;
            onScoreInc?.Invoke(m_score);

            soundController.PlayStoneSound();
            DestroyAfterDelay.DestroyObjectsInList(m_stones, m_destroyDelay);
        }

        private void OnCollisionChickenHit()
        {
            if (isGameOver) return;  // Проверяем состояние игры

            if (m_life > 1)
            {
                m_life--;
                onLifeLost?.Invoke(m_life);
            }
            else
            {
                TriggerGameOver();  // Завершение игры
                return;
            }

            if (UnityEngine.Random.value < 0.5f)
            {
                soundController.PlayChickenSound();
            }
            else
            {
                soundController.PlayDuckSound();
            }
            DestroyAfterDelay.DestroyObjectsInList(m_chickens, 0.1f);
        }

        private void OnCollisionStone()
        {
            if (isGameOver) return;  // Проверяем состояние игры

            if (m_life > 1)
            {
                m_life--;
                onLifeLost?.Invoke(m_life);
            }
            else
            {
                TriggerGameOver();  // Завершение игры
            }
            DestroyAfterDelay.DestroyObjectsInList(m_stones, 0.5f * m_destroyDelay);
        }

        private void OnCollisionChicken()
        {
            DestroyAfterDelay.DestroyObjectsInList(m_chickens, m_destroyDelay);
        }

        private void TriggerGameOver()
        {
            if (isGameOver) return;  // Предотвращаем повторное выполнение

            isGameOver = true;
            onGameOver?.Invoke(m_score);
        }
    }
}
