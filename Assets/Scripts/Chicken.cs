using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Golf
{
    public class Chicken : MonoBehaviour
    {
        public event Action onCollisionChicken;
        public bool isDirty =false;
        private void OnCollisionEnter(Collision other)
        {
            if (isDirty)
            {
                return;
            }

            if (other.gameObject.GetComponent<Chicken>())
            {
                onCollisionChicken?.Invoke();
            }
        }
    }
}
