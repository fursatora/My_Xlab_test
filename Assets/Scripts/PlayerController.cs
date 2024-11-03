using System;
using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        float speedMove = 100f;
        public Stick stick;
        

        private bool isMouseHeld = false;

        private void FixedUpdate()
        {

            if (Input.GetMouseButton(0))
            {
                stick.Down();
            }
            else
            {
                stick.Up();
            }
            //Debug.Log(angle.z);
        }
    }
}
