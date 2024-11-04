using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class DestroyAfterDelay : MonoBehaviour
    {
        private class DelayedDestroyData
        {
            public GameObject obj;
            public float destroyTime;

            public DelayedDestroyData(GameObject obj, float delay)
            {
                this.obj = obj;
                this.destroyTime = Time.time + delay;
            }
        }

        private static List<DelayedDestroyData> destroyQueue = new List<DelayedDestroyData>();

        public static void DestroyObjectWithDelay<T>(GameObject obj, float delay, List<T> list) where T : MonoBehaviour
        {
            if (obj != null)
            {
                T component = obj.GetComponent<T>();
                if (component != null)
                {
                    list.Remove(component);
                }
                destroyQueue.Add(new DelayedDestroyData(obj, delay));
            }
        }

        public static void DestroyObjectsInList<T>(List<T> list, float delay) where T : MonoBehaviour
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var item = list[i];
                DestroyObjectWithDelay(item.gameObject, delay, list);
            }
        }

        private void Update()
        {
            for (int i = destroyQueue.Count - 1; i >= 0; i--)
            {
                if (Time.time >= destroyQueue[i].destroyTime)
                {
                    Destroy(destroyQueue[i].obj);
                    destroyQueue.RemoveAt(i);
                }
            }
        }
    }
}
