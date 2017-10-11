using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class MovingTarget:MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject,10f);
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
        }
    }
}
