using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Stage2Boss : MonoBehaviour
    {
        bool incoming;
        // Use this for initialization
        void Start()
        {
            incoming = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.down;
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }

        void Movement()
        {
            if (incoming && GetComponent<Transform>().position.y <= 3.5f)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Transform>().position = new Vector3(0, 3.5f, 0);
                incoming = false;
            }

        }
    }
}
