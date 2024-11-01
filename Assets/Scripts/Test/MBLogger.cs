using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBLogger : MonoBehaviour
{
    private void Awake()
    {
        Log("Awake");
    }

     private void OnEnable()
     {
        Log("OnEmable");
     }

     private void Start()
     {
        Log("Start");
     }

     private void Update()
     {
     }

     private void FixedUpdate()
     {

     }

     private void LateUptade()
     {

     }

     private void OnDisable()
     {
        Log("OnDisable");
     }

     private void OnDistroy()
     {
        Log("OnDistroy");
     }

    private void Log(string msg)
    {
            Debug.Log($"{name}.{msg} - frame{Time.frameCount}");
    }
}
