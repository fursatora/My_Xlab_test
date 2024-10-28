using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform m_point;

    [SerializeField]
    private GameObject[] m_prefabs;

    private void Start()
    {
        if(m_point == null)
        m_point = transform;
    }

    public void Spawn()
    {
        int index = Random.Range(0, m_prefabs.Length);
        Instantiate(m_prefabs[index], m_point.position, m_point.rotation);
        
    }
}
