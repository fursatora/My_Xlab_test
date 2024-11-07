using UnityEngine;

namespace Golf
{
    public class DifficultyController : MonoBehaviour
    {
        [SerializeField] private float m_initialDelay = 2f; // Изначальная задержка
        [SerializeField] private float m_minDelay = 0.5f;    // Минимальная задержка
        [SerializeField] private float m_delayDecreaseRate = 0.01f; // Темп уменьшения задержки

        private float m_currentDelay;

        private void Start()
        {
            m_currentDelay = m_initialDelay; // Начальная задержка
        }

        // Метод, который возвращает текущую задержку для спавнера
        public float GetSpawnDelay()
        {
            // Уменьшаем задержку, если она больше минимальной
            if (m_currentDelay > m_minDelay)
            {
                m_currentDelay -= m_delayDecreaseRate;
            }
            return m_currentDelay;
        }
    }
}
