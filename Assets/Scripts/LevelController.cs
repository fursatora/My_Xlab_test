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
        private uint m_score = 0;

        private List<Stone> m_stones = new List<Stone>();
        private List<Chicken> m_chickens = new List<Chicken>();

        public void OnEnable()
        {
            m_timer = Time.time - m_delay;
            stick.onCollisionStone += OnCollisionStick;
            stick.onCollisionChicken += OnCollisionStick;
        }
        private void OnDisable()
        {
            if (stick)
            {
                stick.onCollisionStone -= OnCollisionStone;
                stick.onCollisionChicken -= OnCollisionChicken;
            }
        }

        private void Update()
        {
            if (Time.time > m_timer + m_delay)
            {
                m_timer = Time.time;

                var go = stoneSpawner.SpawnStone();
                var stone = go.GetComponent<Stone>();

                stone.onCollisionStone += OnCollisionStone;

                m_stones.Add(stone);
            }

        }



        private void OnCollisionStick()
        {
            m_score++;
            Debug.Log($"score: {m_score}");
        }

        private void OnCollisionStone()
        {
            Debug.Log("GAME OVER!!!!");
        }

        private void OnCollisionChicken()
        {
            m_score--;
            Debug.Log($"score: {m_score}");
        }
    }

}
