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

            /*if (Input.GetMouseButton(0))
            {
                PointerDown();
            }
            else
            {
                PointerUp();
            }*/
            
        }

        public void PointerDown()
        {
            stick.Down();
        }

        public void PointerUp()
        {
            stick.Up();
        }
    }
}
