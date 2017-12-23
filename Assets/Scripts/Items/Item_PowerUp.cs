using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Item_PowerUp : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, 8f);
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 3;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.tag == "Player")
            {
                Debug.Log("got powerup");
                coll.GetComponent<MovePlayer>().PowerUp = true;
                Destroy(gameObject);
            }
        }
    }
}
