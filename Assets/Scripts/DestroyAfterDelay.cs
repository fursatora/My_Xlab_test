using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class DestroyAfterDelay : MonoBehaviour
    {
        public static void DestroyObject<T>(GameObject obj, float delay,List<T> list) where T: MonoBehaviour
        {
            if (obj != null)
            {
                T component =obj.GetComponent<T>();
                if (component!= null)
                {
                    list.Remove(component);
                }
                Destroy(obj, delay);
            }
        }
    }
}
