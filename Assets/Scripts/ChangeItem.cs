using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeItem : MonoBehaviour
{
    public GameObject[] tools;

    private void Start()
    {
        Change();
    }

    public void Change()
    {
        Debug.Log("Ch");
        var index = Random.Range(0, tools.Length);
        for (int i = 0; i < tools.Length; i++)
        {
            tools[i].SetActive(i == index);
        }
    }
}
