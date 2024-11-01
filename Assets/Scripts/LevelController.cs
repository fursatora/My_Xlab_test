using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public StoneSpawner stoneSpawner;
    private float m_timer;
    [SerializeField] private float m_delay = 2f;
    
    public void Start()
    {
        m_timer=Time.time;
    }

    public void Update()
    {
        if (Time.time> m_timer+m_delay)
        {
            stoneSpawner.Spawn();
            m_timer=Time.time;
        }
    }
}
