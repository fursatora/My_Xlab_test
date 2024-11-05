using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {

        public float maxAngle = 30;
        public float speed = 360f; 
        public float power = 1f;
        public Transform point;
        public event System.Action onCollisionStone;
        public event System.Action onCollisionChicken;

        private Vector3 m_lastPointPosition;
        private Vector3 m_dir; //не работает
        private bool m_isDown = false;
        private Rigidbody m_rigidbody;
        

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
        }


        public void Down()
        {
            m_isDown = true;
        }

        public void Up()
        {
            m_isDown = false;
        }

        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            Vector3 angle = transform.localEulerAngles;
            if (m_isDown)
            {   
                angle.z = Mathf.MoveTowardsAngle(angle.z, -maxAngle, speed * Time.deltaTime);
            }
            else
            {
                angle.z = Mathf.MoveTowardsAngle(angle.z, maxAngle, speed * Time.deltaTime);
            }
            transform.localEulerAngles = angle;

            m_dir = (point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = point.position;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Stone>(out var stone) && !stone.isDirty)
            {
                stone.isDirty = true;
                var contact = other.contacts[0];
                other.rigidbody.AddForce(-contact.normal * power, ForceMode.Impulse);
                onCollisionStone?.Invoke();
            }
            else if (other.gameObject.TryGetComponent<Chicken>(out var chicken) && !chicken.isDirty)
            {
                chicken.isDirty = true;
                var contact = other.contacts[0];
                other.rigidbody.AddForce(-contact.normal * power, ForceMode.Impulse);
                onCollisionChicken?.Invoke();
            }
        }

    }

}

