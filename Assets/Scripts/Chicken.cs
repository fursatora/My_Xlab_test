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
        public static bool hasCollidedWithGround = false;
        private void OnCollisionEnter(Collision other)
        {
            if (isDirty)
            {
                return;
            }

            if (other.gameObject.TryGetComponent<Chicken>(out var chicken))
            {
                chicken.isDirty = true;
                hasCollidedWithGround=true;
                onCollisionChicken?.Invoke();
                var levelController = FindObjectOfType<LevelController>();
             
            }
        }
    }
}
