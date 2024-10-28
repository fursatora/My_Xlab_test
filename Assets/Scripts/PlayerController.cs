using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private FreeCamera freeCamera;
    public GameObject ui;
    public StoneSpawner stoneSpawner;
    public CloudController cloudController;
    public ToolsChangerController toolsChangerController;

    private void Update()
    {
        if (ui.activeSelf)
        {
            return;
        }

        if (freeCamera!=null)
        {
            freeCamera.Move();
        }


        if(stoneSpawner != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                stoneSpawner.Spawn();
            }

        }

        if(cloudController != null)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                cloudController.MoveNext();
            }

        }

        if(toolsChangerController != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                toolsChangerController.Change();
            }

        }

    }

    private void MoveCamera()
    {
        

    }
}