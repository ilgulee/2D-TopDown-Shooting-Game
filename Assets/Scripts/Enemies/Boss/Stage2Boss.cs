using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Stage2Boss : MonoBehaviour
    {
        bool incoming;
        Vector3 posStarting;
        // Use this for initialization
        void Start()
        {
            incoming = true;
            posStarting = new Vector3(0, 3.5f, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.down;
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }

        void Movement()
        {
            // reset movement
            if (incoming && GetComponent<Transform>().position.y <= 3.5f)
            {
                GetComponent<Transform>().position = new Vector3(0, 3.5f, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(1, 1);
                incoming = false;
            }
            else if(!incoming)
            {
                if(GetComponent<Transform>().position.x >= 2)
                    GetComponent<Rigidbody2D>().velocity += new Vector2(-1, 0);
                else if(GetComponent<Transform>().position.x <= -2)
                    GetComponent<Rigidbody2D>().velocity += new Vector2(1, 0);

                if (GetComponent<Transform>().position.y >= 4.5f)
                    GetComponent<Rigidbody2D>().velocity += new Vector2(0, -1);
                else if (GetComponent<Transform>().position.y <= 2.5f)
                    GetComponent<Rigidbody2D>().velocity += new Vector2(0, 1);
            }
        }
    }
}
