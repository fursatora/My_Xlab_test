using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsChangerController : MonoBehaviour
{
    public ChangeItem[] vllagers;

    public void Change()
    {
        foreach (var vllager in vllagers)
        {
            vllager.Change();
        }
    }
}
