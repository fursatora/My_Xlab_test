using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform m_point;

    [SerializeField]
    private GameObject[] m_stonePrefabs;

    [SerializeField]
    private GameObject[] m_chickenPrefabs;


    private void Start()
    {
        if(m_point == null)
        m_point = transform;
    }

    public GameObject Spawn(GameObject[] m_prefabs)
    {
        if (m_prefabs == null || m_prefabs.Length == 0)
        {
            Debug.LogWarning("Prefab array is empty or missing.");
            return null;
        }
        int index = Random.Range(0, m_prefabs.Length);
        return Instantiate(m_prefabs[index], m_point.position, m_point.rotation);
        
    }

    public GameObject SpawnStone()
    {
        return Spawn(m_stonePrefabs);
    }

    public GameObject SpawnChicken()
    {
        return Spawn(m_chickenPrefabs);
    }
}
